import React from "react";
import { Course } from "../../services/CourseService";
import {
  SimpleGrid,
  GridItem,
  Card,
  CardBody,
  Button,
  HStack,
  Text,
  Box,
} from "@chakra-ui/react";
import { Link } from "react-router-dom";
import UserFirstNameLastNameDisplay from "./UserFirstNameLastNameDisplay";

interface Props {
  courses: Course[];
  colorMode: string;
}

const AllCourses = ({ courses, colorMode }: Props) => {
  return (
    <SimpleGrid columns={4} minChildWidth={260} spacing={"40px"} paddingTop={5}>
      {courses?.map((course) => (
        <GridItem>
          <Card bg={colorMode == "dark" ? "gray.600" : "gray.100"}>
            <CardBody>
              <Link
                to={"/sign-in/admin/course"}
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
                <Text>{course.timePeriod.endDate.toString().slice(0, 10)}</Text>
              </HStack>
              <Box paddingTop={5} fontSize={20}>
                <UserFirstNameLastNameDisplay
                  id={course.professorId}
                ></UserFirstNameLastNameDisplay>
              </Box>
            </CardBody>
          </Card>
        </GridItem>
      ))}
    </SimpleGrid>
  );
};

export default AllCourses;
