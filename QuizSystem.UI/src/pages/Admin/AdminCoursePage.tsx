import React, { useEffect, useState } from "react";
import { Link, NavLink, Navigate, useLocation } from "react-router-dom";
import CourseService, { Course } from "../../services/CourseService";
import {
  Box,
  Button,
  Container,
  HStack,
  Heading,
  Text,
  useColorMode,
} from "@chakra-ui/react";
import UserFirstNameLastNameDisplay from "../../components/Global/UserFirstNameLastNameDisplay";

const AdminCoursePage = () => {
  const { colorMode } = useColorMode();
  const [course, setCourse] = useState<Course>();
  const [courseStudents, setCourseStudents] = useState<{ id: string }[]>();
  const state = useLocation().state;
  const [editPage, setEditPage] = useState(false);
  const { GetById: GetWithId, GetStudentsWithCourseId } = new CourseService();
  useEffect(() => {
    GetWithId(state.courseId, setCourse);
    GetStudentsWithCourseId(state.courseId, setCourseStudents);
  }, [state]);

  return (
    <Container>
      <Box
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        p={10}
        borderRadius={50}
      >
        <Heading>{course && <Text>{course.title}</Text>}</Heading>
        <HStack paddingTop={5}>
          <Heading fontSize={22}>Start Date: </Heading>
          <Text>{course?.timePeriod.startDate.toString().slice(0, 10)}</Text>
        </HStack>
        <HStack>
          <Heading fontSize={22}>End Date: </Heading>
          <Text>{course?.timePeriod.endDate.toString().slice(0, 10)}</Text>
        </HStack>
        <Heading marginTop={5} fontSize={22}>
          Professor
        </Heading>
        {course && (
          <Heading fontSize={25}>
            <UserFirstNameLastNameDisplay
              id={course.professorId}
            ></UserFirstNameLastNameDisplay>
          </Heading>
        )}

        <Heading marginTop={5} fontSize={22}>
          Students
        </Heading>

        <Box marginTop={1}>
          {courseStudents?.map((studentId) => (
            <UserFirstNameLastNameDisplay
              key={studentId.id}
              id={studentId.id}
            ></UserFirstNameLastNameDisplay>
          ))}
        </Box>

        <Link
          to="/sign-in/admin/course/edit"
          state={{ course: course, courseStudents: courseStudents }}
        >
          <Button marginTop={5} onClick={() => setEditPage(true)}>
            Edit course
          </Button>
        </Link>
      </Box>
    </Container>
  );
};

export default AdminCoursePage;
