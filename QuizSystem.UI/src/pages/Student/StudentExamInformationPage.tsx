import {
  Box,
  Button,
  Container,
  Flex,
  HStack,
  Heading,
  Text,
  VStack,
  useColorMode,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { NavLink, Navigate, useLocation, useNavigate } from "react-router-dom";
import ExamService, { Exam } from "../../services/ExamService";
import GradedQuestionService from "../../services/GradedQuestionService";
import { Question } from "../../services/QuestionService";
import ExamStudentService from "../../services/ExamStudentService";

const StudentExamInformationPage = () => {
  const { colorMode } = useColorMode();
  const state = useLocation().state;
  const { GetById } = new ExamService();
  const navigate = useNavigate();
  const { Create, Exist } = new ExamStudentService();
  const [examStudent, setExamStudent] = useState<{ id: string }>();
  const [error, setError] = useState();
  const [exam, setExam] = useState<Exam>();
  const [gradedQuestions, setGradedQuestion] = useState<{ grade: number }[]>();
  const [examStarted, setExamStarted] = useState(false);
  const [exist, setExist] = useState();
  var totalGrade = 0;
  gradedQuestions?.forEach((element) => {
    totalGrade += element.grade;
  });
  const { GetAllByExamId } = new GradedQuestionService();
  useEffect(() => {
    GetById(state.examId, setExam);
    GetAllByExamId(state.examId, setGradedQuestion, setError);
    Exist(state.examId, setExist, setError);
  }, [state]);
  if (examStarted)
    return (
      <Navigate
        to={"/sign-in/student/course/exam/take"}
        state={{
          examId: state.examId,
          courseId: state.courseId,
        }}
      ></Navigate>
    );
  return (
    <Container>
      <Box
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        p={10}
        borderRadius={50}
      >
        <Heading>{exam && <Text>{exam.title}</Text>}</Heading>

        <Heading paddingTop={5} fontSize={22}>
          Description:{" "}
        </Heading>
        <Text>{exam?.description}</Text>

        <Flex align={"baseline"}>
          <Heading paddingTop={5} fontSize={22}>
            Questions:{" "}
          </Heading>
          <Heading fontSize={20} paddingLeft={2}>
            {gradedQuestions?.length}
          </Heading>
        </Flex>

        <Flex align={"baseline"}>
          <Heading paddingTop={5} fontSize={22}>
            Total Grade:{" "}
          </Heading>
          <Heading fontSize={20} paddingLeft={2}>
            {totalGrade}
          </Heading>
        </Flex>

        <Flex align={"baseline"}>
          <Heading paddingTop={5} fontSize={22}>
            Time:{" "}
          </Heading>
          <Heading fontSize={20} paddingLeft={2}>
            {exam?.time}
            {" minutes"}
          </Heading>
        </Flex>

        <Button
          onClick={() => {
            if (!exist) {
              Create(state.examId, setExamStudent, setError);
            }
            setExamStarted(true);
          }}
          marginTop={7}
        >
          Start the exam
        </Button>
      </Box>
    </Container>
  );
};

export default StudentExamInformationPage;
