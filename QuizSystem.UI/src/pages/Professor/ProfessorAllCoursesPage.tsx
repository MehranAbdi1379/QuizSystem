import React, { useEffect, useState } from "react";
import CourseService, { Course } from "../../services/CourseService";
import { Link, useLocation } from "react-router-dom";
import {
  useColorMode,
  Heading,
  SimpleGrid,
  GridItem,
  Card,
  CardBody,
  Button,
  HStack,
  Box,
  Text,
} from "@chakra-ui/react";
import UserDisplay from "../../components/Global/UserDisplay";

const ProfessorAllCoursesPage = () => {
  const { GetByProfessorId } = new CourseService();
  const state = useLocation().state;
  const [courses, setCourses] = useState<Course[]>();
  const { colorMode } = useColorMode();

  useEffect(() => {
    GetByProfessorId(localStorage.getItem("userId"), setCourses);
  }, [state]);
  return (
    <Box paddingLeft={10} paddingTop={5} paddingRight={10}>
      <Heading paddingBottom={4}>Courses</Heading>

      <SimpleGrid
        columns={4}
        minChildWidth={260}
        spacing={"40px"}
        paddingTop={5}
      >
        {courses?.map((course) => (
          <GridItem key={course.id}>
            <Card bg={colorMode == "dark" ? "gray.600" : "gray.100"}>
              <CardBody>
                <Link
                  to={"/sign-in/professor/course"}
                  state={{ courseId: course.id }}
                >
                  <Button bg={colorMode == "dark" ? "gray.500" : "gray.300"}>
                    {course.title}
                  </Button>
                </Link>
                <HStack paddingTop={5}>
                  <Text>Start Date: </Text>
                  <Text>
                    {course.timePeriod.startDate.toString().slice(0, 10)}
                  </Text>
                </HStack>
                <HStack>
                  <Text>End Date: </Text>
                  <Text>
                    {course.timePeriod.endDate.toString().slice(0, 10)}
                  </Text>
                </HStack>
              </CardBody>
            </Card>
          </GridItem>
        ))}
      </SimpleGrid>
    </Box>
  );
};

export default ProfessorAllCoursesPage;
