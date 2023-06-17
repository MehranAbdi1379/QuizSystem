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
import UserFirstNameLastNameDisplay from "../../components/Global/UserFirstNameLastNameDisplay";
import AllCourses from "../../components/Global/AllCourses";

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

      {courses && (
        <AllCourses colorMode={colorMode} courses={courses}></AllCourses>
      )}
    </Box>
  );
};

export default ProfessorAllCoursesPage;
