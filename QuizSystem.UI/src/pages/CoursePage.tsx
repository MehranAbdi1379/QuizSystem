import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import CourseService, { Course } from "../services/CourseService";
import {
  Box,
  Container,
  Heading,
  List,
  ListItem,
  Text,
} from "@chakra-ui/react";
import { Student } from "../services/StudentService";
import CourseStudents from "../components/CourseStudents";

const AdminCoursePage = () => {
  const [course, setCourse] = useState<Course>();
  const [courseStudents, setCourseStudents] = useState<{ id: string }[]>();
  const params = useParams();
  const { GetById: GetWithId, GetStudentsWithCourseId } = new CourseService();
  useEffect(() => {
    GetWithId(params, setCourse);
    GetStudentsWithCourseId(params, setCourseStudents);
  }, []);

  return (
    <Box paddingLeft={5}>
      <Heading>{course && <Text>{course.title}</Text>}</Heading>
      <Heading fontSize={25}>Students</Heading>
      <Box>
        {courseStudents?.map((studentId) => (
          <CourseStudents studentId={studentId}></CourseStudents>
        ))}
      </Box>
    </Box>
  );
};

export default AdminCoursePage;
