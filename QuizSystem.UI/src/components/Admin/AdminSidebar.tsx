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
import { Link, NavLink, useLocation, useParams } from "react-router-dom";
import CourseService, { Course } from "../../services/CourseService";
import StudentService, { Student } from "../../services/StudentService";
import ProfessorService, { Professor } from "../../services/ProfessorService";

const AdminSidebar = () => {
  const { colorMode } = useColorMode();
  const state = useLocation().state;
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
  }, [state]);

  return (
    <Box
      p={5}
      minHeight={{ base: "200px", md: "100%" }}
      height={{ base: "200px", md: "100vh" }}
      bg={colorMode == "dark" ? "gray.700" : "gray.50"}
      borderTopRightRadius={20}
    >
      <Flex>
        <Heading>Courses</Heading>
        <NavLink
          state={{ students: students, professors: professors }}
          to={"/sign-in/admin/course/create"}
        >
          <Button fontSize={15} variant={"ghost"}>
            New course
          </Button>
        </NavLink>
      </Flex>

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
          <Link to={"/sign-in/admin/course/all"}>
            <Button>All Courses</Button>
          </Link>
        </ListItem>
      </List>

      <Heading paddingTop={5}>Professors</Heading>
      <List>
        {professors?.slice(0, 3).map((professor) => (
          <ListItem key={professor.id}>
            <Button variant={"ghost"}>
              <Link state={{ professorId: professor.id }} to={"professor"}>
                {professor.firstName + " "}
                {professor.lastName}
              </Link>
            </Button>
          </ListItem>
        ))}
        <ListItem>
          <Link
            state={{ professors: professors }}
            to={"/sign-in/admin/professor/all"}
          >
            <Button>All Professors</Button>
          </Link>
        </ListItem>
      </List>

      <Heading paddingTop={5}>Students</Heading>
      <List>
        {students?.slice(0, 3).map((student) => (
          <ListItem key={student.id}>
            <Button variant={"ghost"}>
              <Link state={{ studentId: student.id }} to={"student"}>
                {student.firstName + " "}
                {student.lastName}
              </Link>
            </Button>
          </ListItem>
        ))}
        <ListItem>
          <Link
            state={{ students: students }}
            to={"/sign-in/admin/student/all"}
          >
            <Button>All Students</Button>
          </Link>
        </ListItem>
        <ListItem marginTop={4}>
          <Link to="/sign-in/admin/search">
            <Button>Search</Button>
          </Link>
        </ListItem>
      </List>
    </Box>
  );
};

export default AdminSidebar;
