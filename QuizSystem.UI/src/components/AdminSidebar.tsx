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
import CourseService, { Course } from "../services/CourseService";
import { Link, NavLink, useParams } from "react-router-dom";
import ProfessorService, { Professor } from "../services/ProfessorService";
import StudentService, { Student } from "../services/StudentService";

const AdminSidebar = () => {
  const params = useParams();
  const { colorMode } = useColorMode();
  const [courses, setCourses] = useState<Course[]>();
  const [students, setStudents] = useState<Student[]>();
  const [professors, setProfessors] = useState<Professor[]>();
  const { GetAll: GetAllCourses } = new CourseService();
  const { GetAll: GetAllProfessors } = new ProfessorService();
  const { GetAll: GetAllStudents } = new StudentService();
  useEffect(() => {
    GetAllCourses(setCourses);
    GetAllStudents(setStudents);
    GetAllProfessors(setProfessors);
  }, []);

  return (
    <Box
      p={5}
      minHeight={{ base: "200px", md: "100vh" }}
      bg={colorMode == "dark" ? "gray.700" : "gray.100"}
      borderTopRightRadius={20}
    >
      <Flex>
        <Heading>Courses</Heading>
        <NavLink to={"/sign-in/" + params.id + "/admin/courses/create"}>
          <Button paddingLeft={4} paddingTop={3} variant="unstyled">
            New course
          </Button>
        </NavLink>
      </Flex>

      <List>
        {courses?.slice(0, 3).map((course) => (
          <ListItem key={course.id}>
            <Button variant={"ghost"}>
              <Link to={"course/" + course.id}>{course.title}</Link>
            </Button>
          </ListItem>
        ))}
        <ListItem>
          <Button>All Courses</Button>
        </ListItem>
      </List>

      <Heading paddingTop={5}>Professors</Heading>
      <List>
        {professors?.slice(0, 3).map((professor) => (
          <ListItem key={professor.id}>
            <Button variant={"ghost"}>
              <Link to={"professor/" + professor.id}>
                {professor.firstName + " "}
                {professor.lastName}
              </Link>
            </Button>
          </ListItem>
        ))}
        <ListItem>
          <Button>All Professors</Button>
        </ListItem>
      </List>

      <Heading paddingTop={5}>Students</Heading>
      <List>
        {students?.slice(0, 3).map((student) => (
          <ListItem key={student.id}>
            <Button variant={"ghost"}>
              <Link to={"student/" + student.id}>
                {student.firstName + " "}
                {student.lastName}
              </Link>
            </Button>
          </ListItem>
        ))}
        <ListItem>
          <Button>All Students</Button>
        </ListItem>
      </List>
    </Box>
  );
};

export default AdminSidebar;
