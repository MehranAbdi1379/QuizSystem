import {
  useColorMode,
  Container,
  Heading,
  HStack,
  Button,
  Box,
  Text,
  VStack,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { useLocation, Link, useNavigate } from "react-router-dom";
import UserFirstNameLastNameDisplay from "../../components/Global/UserFirstNameLastNameDisplay";
import CourseService, { Course } from "../../services/CourseService";
import ExamService, { Exam } from "../../services/ExamService";

const StudentCoursePage = () => {
  const navigate = useNavigate();
  const { colorMode } = useColorMode();
  const [course, setCourse] = useState<Course>();
  const state = useLocation().state;
  const [editPage, setEditPage] = useState(false);
  const [exams, setExams] = useState<Exam[]>();
  const { GetById: GetWithId } = new CourseService();
  const { GetAllByCourseId } = new ExamService();
  useEffect(() => {
    GetWithId(state.courseId, setCourse);
    GetAllByCourseId(state.courseId, setExams);
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

        <HStack marginTop={5}>
          <Heading fontSize={22}>Professor:</Heading>
          {course?.professorId && (
            <Text fontSize={18}>
              <UserFirstNameLastNameDisplay
                id={course.professorId}
              ></UserFirstNameLastNameDisplay>
            </Text>
          )}
        </HStack>

        <Heading paddingTop={5} fontSize={22}>
          Exams
        </Heading>

        <VStack align={"start"}>
          {exams?.map((exam) => (
            <Button
              key={exam.id}
              onClick={() =>
                navigate("/sign-in/student/course/exam/information", {
                  state: { examId: exam.id, courseId: course?.id },
                })
              }
              variant={"ghost"}
            >
              {exam.title}
            </Button>
          ))}
        </VStack>
      </Box>
    </Container>
  );
};

export default StudentCoursePage;
