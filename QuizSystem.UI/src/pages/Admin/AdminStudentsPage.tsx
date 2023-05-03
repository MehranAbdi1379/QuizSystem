import React, { useEffect, useState } from "react";
import { Link, useLocation, useParams } from "react-router-dom";
import {
  Box,
  Button,
  Container,
  HStack,
  Heading,
  Text,
  VStack,
  useColorMode,
} from "@chakra-ui/react";
import StudentService, { Student } from "../../services/StudentService";
import CourseDisplay from "../../components/Global/CourseDisplay";
import CourseService, { Course } from "../../services/CourseService";

const AdminStudentsPage = () => {
  const { colorMode } = useColorMode();
  const state = useLocation().state;
  const { GetById: GetStudentWithId, Accept, Unaccept } = new StudentService();
  const [student, setStudent] = useState<Student>();
  const { GetAll } = new CourseService();
  const [courses, setCourses] = useState<Course[]>();

  useEffect(() => {
    GetStudentWithId(state.studentId, setStudent);
    GetAll(setCourses);
  }, [state]);

  return (
    <Container>
      <Box
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        p={10}
        borderRadius={50}
      >
        <Heading>
          {student && <Text>{student.firstName + " " + student.lastName}</Text>}
        </Heading>

        <Heading marginTop={5} fontSize={22}>
          Birth Date:
        </Heading>
        {student && (
          <Heading fontSize={20}>
            <Text>{student.birthDate.toString().slice(0, 10)}</Text>
          </Heading>
        )}

        <Heading marginTop={5} fontSize={22}>
          National Code:
        </Heading>
        {student && (
          <Heading fontSize={20}>
            <Text>{student.nationalCode}</Text>
          </Heading>
        )}
        {courses &&
          courses
            ?.map((x) => x)
            .filter(function (x) {
              return student?.courseIds.includes(x.id);
            }).length > 0 && (
            <Heading marginTop={5} marginBottom={2} fontSize={22}>
              Courses
            </Heading>
          )}

        <VStack marginBottom={5} align={"startZ"}>
          {courses
            ?.map((x) => x)
            .filter(function (x) {
              return student?.courseIds.includes(x.id);
            })
            .map((course) => (
              <Link to="/sign-in/admin/course" state={{ courseId: course.id }}>
                <Button variant={"ghost"}>{course.title}</Button>
              </Link>
            ))}
        </VStack>
        {student?.accepted && (
          <Button
            onClick={() => {
              Unaccept(student.id);
              setStudent({ ...student, accepted: false });
            }}
          >
            Unaccept
          </Button>
        )}
        {student?.accepted == false && (
          <Button
            onClick={() => {
              Accept(student.id);
              setStudent({ ...student, accepted: true });
            }}
          >
            Accept
          </Button>
        )}
      </Box>
    </Container>
  );
};

export default AdminStudentsPage;
