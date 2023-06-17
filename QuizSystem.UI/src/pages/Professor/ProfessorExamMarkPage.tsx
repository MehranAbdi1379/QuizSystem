import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import { Question } from "../../services/QuestionService";
import GradedQuestionService from "../../services/GradedQuestionService";
import {
  Box,
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Container,
  GridItem,
  HStack,
  Heading,
  Input,
  List,
  SimpleGrid,
  Text,
  useColorMode,
} from "@chakra-ui/react";
import ExamStudentService from "../../services/ExamStudentService";
import DescriptiveQuestionService from "../../services/DescriptiveQuestionService";
import MultipleChoiceQuestionService from "../../services/MultipleChoiceQuestionService";
import ProfessorDescriptiveQuestionMark from "../../components/Professor/ProfessorDescriptiveQuestionMark";
import ProfessorMultipleChoiceQuestionMark from "../../components/Professor/ProfessorMultipleChoiceQuestionMark";

const ProfessorExamMarkPage = () => {
  const state: {
    courseId: string;
    examId: string;
    studentId: string;
  } = useLocation().state;

  const [examStudentQuestions, setExamStudentQuestions] = useState<
    {
      id: string;
      examStudentId: string;
      gradedQuestionId: string;
      grade: number;
      answer: string;
    }[]
  >();
  const { GetAllQuestionsByExamAndStudentId } = new ExamStudentService();

  const [error, setError] = useState();
  const { colorMode } = useColorMode();

  var gradeSum = 0;
  examStudentQuestions?.forEach((element) => {
    gradeSum += element.grade;
  });

  const [gradeSumCounter, setGradeSumCounter] = useState(0);

  useEffect(() => {
    gradeSum = 0;
    examStudentQuestions?.forEach((element) => {
      gradeSum += element.grade;
    });

    GetAllQuestionsByExamAndStudentId(
      state.examId,
      state.studentId,
      setExamStudentQuestions,
      setError
    );
  }, [state, gradeSumCounter]);
  return (
    <Container marginTop={10} maxWidth={1200}>
      <List spacing={5}>
        <Box
          paddingLeft={5}
          paddingTop={5}
          bg={colorMode == "dark" ? "gray.600" : "gray.100"}
          borderRadius={20}
        >
          <ProfessorDescriptiveQuestionMark
            gradeSumCounter={gradeSumCounter}
            setGradeSumCounter={setGradeSumCounter}
            examStudentQuestions={examStudentQuestions}
            setError={setError}
            state={state}
          />
        </Box>

        <Box
          p={5}
          bg={colorMode == "dark" ? "gray.600" : "gray.100"}
          borderRadius={20}
        >
          <ProfessorMultipleChoiceQuestionMark
            setError={setError}
            examStudentQuestions={examStudentQuestions}
            state={state}
          />
        </Box>
        <Box
          p={5}
          bg={colorMode == "dark" ? "gray.600" : "gray.100"}
          borderRadius={20}
        >
          <Heading fontSize={22}>Sum: {gradeSum}</Heading>
        </Box>
      </List>
    </Container>
  );
};

export default ProfessorExamMarkPage;
