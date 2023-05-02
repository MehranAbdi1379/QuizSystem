import {
  Box,
  Button,
  Flex,
  HStack,
  Heading,
  List,
  ListItem,
  Text,
  useColorMode,
  useStatStyles,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { Link, NavLink, useParams } from "react-router-dom";
import CourseService, { Course } from "../../services/CourseService";
import StudentService, { Student } from "../../services/StudentService";
import ProfessorService, { Professor } from "../../services/ProfessorService";

const ProfessorSidebar = () => {
  const { colorMode } = useColorMode();
  const id = localStorage.getItem("userId");
  const [courses, setCourses] = useState<Course[]>();
  const { GetByProfessorId } = new CourseService();
  useEffect(() => {
    GetByProfessorId(id, setCourses);
  }, []);

  return (
    <Box
      p={5}
      minHeight={{ base: "200px", md: "100vh" }}
      bg={colorMode == "dark" ? "gray.700" : "gray.50"}
      borderTopRightRadius={20}
    >
      <Heading>Courses</Heading>

      <List>
        {courses?.slice(0, 3).map((course) => (
          <ListItem key={course.id}>
            <Button variant={"ghost"}>
              <Link state={{ courseId: course.id }} to={"course"}>
                {course.title}
              </Link>
            </Button>
          </ListItem>
        ))}
        <ListItem>
          <Link to={"/sign-in/professor/courses/all"}>
            <Button>All Courses</Button>
          </Link>
        </ListItem>
      </List>
    </Box>
  );
};

export default ProfessorSidebar;
