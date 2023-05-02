import {
  Box,
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  GridItem,
  HStack,
  Heading,
  SimpleGrid,
  Text,
  VStack,
  useColorMode,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import CourseService, { Course } from "../../services/CourseService";
import { Link, useParams } from "react-router-dom";
import UserDisplay from "../../components/Global/UserDisplay";

const AdminAllCoursesPage = () => {
  const { GetAll } = new CourseService();
  const [courses, setCourses] = useState<Course[]>();
  const { colorMode } = useColorMode();

  useEffect(() => {
    GetAll(setCourses);
  }, []);
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
          <GridItem>
            <Card bg={colorMode == "dark" ? "gray.600" : "gray.100"}>
              <CardBody>
                <Link
                  to={"/sign-in/admin/course/"}
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
                <Box paddingTop={5} fontSize={20}>
                  <UserDisplay id={course.professorId}></UserDisplay>
                </Box>
              </CardBody>
            </Card>
          </GridItem>
        ))}
      </SimpleGrid>
    </Box>
  );
};

export default AdminAllCoursesPage;
