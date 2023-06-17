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

const ProfessorExamMarkPage = () => {
  const state: {
    courseId: string;
    examId: string;
    studentId: string;
  } = useLocation().state;
  const [gradedDescriptiveQuestions, setGradedDescriptiveQuestions] =
    useState<
      { id: string; questionId: string; examId: string; grade: number }[]
    >();
  const [GradedMultipleChoiceQuestions, setGradedMultipleChoiceQuestions] =
    useState<
      { id: string; questionId: string; examId: string; grade: number }[]
    >();
  const [descriptiveQuestions, setDescriptiveQuestions] =
    useState<Question[]>();
  const [multipleChoiceQuestions, setMultipleChoiceQuestions] =
    useState<Question[]>();
  const { GetDescriptiveQuestionsOnly, GetMultipleChoiceQuestionsOnly } =
    new GradedQuestionService();

  const [examStudentQuestions, setExamStudentQuestions] = useState<
    {
      id: string;
      examStudentId: string;
      gradedQuestionId: string;
      grade: number;
      answer: string;
    }[]
  >();
  const { GetAllQuestionsByExamAndStudentId, UpdateQuestionGrade } =
    new ExamStudentService();
  const { GetAllByExamId: GetDescriptiveQuestionsByExamId } =
    new DescriptiveQuestionService();
  const { GetAllByExamId: GetMutlipleChoiceQuestionByExamId } =
    new MultipleChoiceQuestionService();
  const [error, setError] = useState();
  const { colorMode } = useColorMode();

  var gradedDescriptiveQuestionsDisplay: {
    gradedQuestionId: string;
    title: string;
    description: string;
    answer: string;
    questionId: string;
    examStudentQuestionId: string;
    grade: number;
    maxGrade: number;
  }[] = [];

  descriptiveQuestions?.forEach((descriptiveQuestion) => {
    var newGradeDescriptiveQuestion: {
      gradedQuestionId: string;
      title: string;
      description: string;
      answer: string;
      questionId: string;
      examStudentQuestionId: string;
      grade: number;
      maxGrade: number;
    } = {
      gradedQuestionId: "",
      answer: "",
      title: "",
      description: "",
      questionId: "",
      examStudentQuestionId: "",
      grade: 0,
      maxGrade: 0,
    };
    gradedDescriptiveQuestions?.forEach((gradedDescriptiveQuestion) => {
      if (gradedDescriptiveQuestion.questionId == descriptiveQuestion.id) {
        newGradeDescriptiveQuestion.gradedQuestionId =
          gradedDescriptiveQuestion.id;
        newGradeDescriptiveQuestion.maxGrade = gradedDescriptiveQuestion.grade;
        examStudentQuestions?.forEach((examStudentQuestion) => {
          if (
            examStudentQuestion.gradedQuestionId == gradedDescriptiveQuestion.id
          ) {
            newGradeDescriptiveQuestion.answer = examStudentQuestion.answer;
            newGradeDescriptiveQuestion.examStudentQuestionId =
              examStudentQuestion.id;
            newGradeDescriptiveQuestion.grade = examStudentQuestion.grade;
          }
        });
      }
    });
    newGradeDescriptiveQuestion.description = descriptiveQuestion.description;
    newGradeDescriptiveQuestion.title = descriptiveQuestion.title;
    newGradeDescriptiveQuestion.questionId = descriptiveQuestion.id;

    gradedDescriptiveQuestionsDisplay.push(newGradeDescriptiveQuestion);
  });

  var gradedMultipleChoiceQuestionsDisplay: {
    gradedQuestionId: string;
    title: string;
    description: string;
    answer: string;
    questionId: string;
    examStudentQuestionId: string;
    grade: number;
  }[] = [];

  multipleChoiceQuestions?.forEach((multipleChoiceQuestion) => {
    var newGradedMultipleChoiceQuestion: {
      gradedQuestionId: string;
      title: string;
      description: string;
      answer: string;
      questionId: string;
      examStudentQuestionId: string;
      grade: number;
    } = {
      gradedQuestionId: "",
      answer: "",
      title: "",
      description: "",
      questionId: "",
      examStudentQuestionId: "",
      grade: 0,
    };
    GradedMultipleChoiceQuestions?.forEach((gradedMultipleChoiceQuestion) => {
      if (
        gradedMultipleChoiceQuestion.questionId == multipleChoiceQuestion.id
      ) {
        newGradedMultipleChoiceQuestion.gradedQuestionId =
          gradedMultipleChoiceQuestion.id;
        examStudentQuestions?.forEach((examStudentQuestion) => {
          if (
            examStudentQuestion.gradedQuestionId ==
            gradedMultipleChoiceQuestion.id
          ) {
            newGradedMultipleChoiceQuestion.answer = examStudentQuestion.answer;
            newGradedMultipleChoiceQuestion.examStudentQuestionId =
              examStudentQuestion.id;
            newGradedMultipleChoiceQuestion.grade = examStudentQuestion.grade;
          }
        });
      }
    });
    newGradedMultipleChoiceQuestion.description =
      multipleChoiceQuestion.description;
    newGradedMultipleChoiceQuestion.title = multipleChoiceQuestion.title;
    newGradedMultipleChoiceQuestion.questionId = multipleChoiceQuestion.id;

    gradedMultipleChoiceQuestionsDisplay.push(newGradedMultipleChoiceQuestion);
  });

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
    GetDescriptiveQuestionsOnly(
      state.examId,
      setGradedDescriptiveQuestions,
      setError
    );
    GetMultipleChoiceQuestionsOnly(
      state.examId,
      setGradedMultipleChoiceQuestions,
      setError
    );
    GetAllQuestionsByExamAndStudentId(
      state.examId,
      state.studentId,
      setExamStudentQuestions,
      setError
    );
    GetDescriptiveQuestionsByExamId(
      state.examId,
      setDescriptiveQuestions,
      setError
    );
    GetMutlipleChoiceQuestionByExamId(
      state.examId,
      setMultipleChoiceQuestions,
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
          <Heading>Descriptive Questions: </Heading>

          <SimpleGrid columns={2} minChildWidth={300}>
            {gradedDescriptiveQuestionsDisplay.map((q) => (
              <Card
                key={q.questionId}
                marginTop={5}
                marginRight={5}
                marginBottom={5}
              >
                <CardHeader>
                  <Heading fontSize={24}>{q.title}</Heading>
                  <Text>{q.description}</Text>
                </CardHeader>
                <CardBody>
                  <Box>
                    <Text>Answer: </Text>
                    <Text>{q.answer}</Text>
                  </Box>
                </CardBody>
                <CardFooter>
                  <Box width={"100%"}>
                    <Text>Max Grade: {q.maxGrade}</Text>
                    <HStack marginTop={2}>
                      <Text>Grade: </Text>
                      <Input
                        type="number"
                        required
                        defaultValue={q.grade}
                        onChange={(e) => {
                          if (parseFloat(e.target.value) > q.maxGrade) {
                            alert("Grade can not be more than max grade.");
                            e.target.value = q.grade.toString();
                          } else if (parseFloat(e.target.value) < 0) {
                            alert("Grade can not be negative.");
                            e.target.value = q.grade.toString();
                          } else if (e.target.value) {
                            UpdateQuestionGrade(
                              q.examStudentQuestionId,
                              e.target.value,
                              setError
                            );
                            setGradeSumCounter(gradeSumCounter + 1);
                          }
                        }}
                      ></Input>
                    </HStack>
                  </Box>
                </CardFooter>
              </Card>
            ))}
          </SimpleGrid>
        </Box>

        <Box
          p={5}
          bg={colorMode == "dark" ? "gray.600" : "gray.100"}
          borderRadius={20}
        >
          <Heading>Multiple Choice Questions: </Heading>

          <SimpleGrid columns={2} minChildWidth={300}>
            {gradedMultipleChoiceQuestionsDisplay.map((q) => (
              <GridItem>
                <Card
                  key={q.questionId}
                  marginTop={5}
                  marginRight={5}
                  marginBottom={5}
                >
                  <CardHeader>
                    <Heading fontSize={24}>{q.title}</Heading>
                    <Text>{q.description}</Text>
                  </CardHeader>
                  <CardBody>
                    <Box>
                      <Text>Answer: </Text>
                      <Text>{q.answer}</Text>
                    </Box>
                  </CardBody>
                  <CardFooter>
                    <Box>
                      <Text>Grade: {q.grade}</Text>
                    </Box>
                  </CardFooter>
                </Card>
              </GridItem>
            ))}
          </SimpleGrid>
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
