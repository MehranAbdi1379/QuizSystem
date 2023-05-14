import {
  Box,
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Container,
  Heading,
  Input,
  List,
  Text,
  useColorMode,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import GradedQuestionService from "../../services/GradedQuestionService";
import DescriptiveQuestionService from "../../services/DescriptiveQuestionService";
import MultipleChoiceQuestionService from "../../services/MultipleChoiceQuestionService";
import { Question } from "../../services/QuestionService";

const ProfessorExamQuestionEditPage = () => {
  const state: {
    courseId: string;
    examId: string;
  } = useLocation().state;
  const { GetByCourseAndProfessorId } = new DescriptiveQuestionService();
  const { GetByCourseAndProfessorId: GetAllMultipleChoiceQuestions } =
    new MultipleChoiceQuestionService();
  const [descriptiveQuestions, setDescriptiveQuestions] =
    useState<Question[]>();
  const [multipleChoiceQuestions, setMultipleChoiceQuestions] =
    useState<Question[]>();
  const { GetAllByExamId, Update, Delete } = new GradedQuestionService();
  const [gradedQuestions, setGradedQuestions] =
    useState<
      { id: string; questionId: string; examId: string; grade: number }[]
    >();
  const [error, setError] = useState();
  const { colorMode } = useColorMode();
  var gradeSum: number = 0;
  gradedQuestions?.forEach((element) => {
    gradeSum += element.grade;
  });
  const [deleteCounter, setDeleteCounter] = useState(0);

  useEffect(() => {
    GetAllMultipleChoiceQuestions(
      state.courseId,
      localStorage.getItem("userId"),
      setMultipleChoiceQuestions,
      setError
    );
    GetByCourseAndProfessorId(
      state.courseId,
      localStorage.getItem("userId"),
      setDescriptiveQuestions,
      setError
    );
    GetAllByExamId(state.examId, setGradedQuestions, setError);
  }, [state, deleteCounter]);
  return (
    <Container marginTop={10} maxWidth={600}>
      <List spacing={5}>
        {descriptiveQuestions
          ?.map((q) => q)
          .filter(function (q) {
            return gradedQuestions?.map((q) => q.questionId).includes(q.id);
          }).length && (
          <Box
            p={5}
            bg={colorMode == "dark" ? "gray.600" : "gray.100"}
            borderRadius={20}
          >
            <Heading>Descriptive Questions: </Heading>
            {descriptiveQuestions
              ?.map((q) => q)
              .filter(function (q) {
                return gradedQuestions?.map((q) => q.questionId).includes(q.id);
              })
              .map((q) => (
                <Card key={q.id} margin={5}>
                  <CardBody>
                    <Heading fontSize={24}>{q.title}</Heading>
                    <Text>{q.description}</Text>
                    {gradedQuestions
                      ?.filter((question) => question.questionId == q.id)
                      .map((que) => (
                        <Box key={que.id}>
                          <Text>Grade: </Text>
                          <Input
                            type="number"
                            required
                            defaultValue={que.grade}
                            onChange={(e) => {
                              console.log(e);
                              if (e.target.value) {
                                Update(
                                  { id: que.id, grade: e.target.value },
                                  setError
                                );
                              }
                            }}
                          ></Input>
                          <Button
                            onClick={() => {
                              Delete(que.id, setError);
                              setDeleteCounter(deleteCounter + 1);
                            }}
                          >
                            Delete
                          </Button>
                        </Box>
                      ))}
                  </CardBody>
                </Card>
              ))}
          </Box>
        )}
        {multipleChoiceQuestions
          ?.map((q) => q)
          .filter(function (q) {
            return gradedQuestions?.map((q) => q.questionId).includes(q.id);
          }).length && (
          <Box
            p={5}
            bg={colorMode == "dark" ? "gray.600" : "gray.100"}
            borderRadius={20}
          >
            <Heading>Multiple Choice Questions: </Heading>
            {multipleChoiceQuestions
              ?.map((q) => q)
              .filter(function (q) {
                return gradedQuestions?.map((q) => q.questionId).includes(q.id);
              })
              .map((q) => (
                <Card key={q.id} margin={5}>
                  <CardBody>
                    <Heading fontSize={24}>{q.title}</Heading>
                    <Text>{q.description}</Text>
                    {gradedQuestions
                      ?.filter((question) => question.questionId == q.id)
                      .map((que) => (
                        <Box key={que.id}>
                          <Text>Grade: </Text>
                          <Input
                            type="number"
                            required
                            defaultValue={que.grade}
                            onChange={(e) => {
                              console.log(e);
                              if (e.target.value) {
                                Update(
                                  { id: que.id, grade: e.target.value },
                                  setError
                                );
                              }
                            }}
                          ></Input>
                          <Button
                            onClick={() => {
                              Delete(que.id, setError);
                              setDeleteCounter(deleteCounter + 1);
                            }}
                          >
                            Delete
                          </Button>
                        </Box>
                      ))}
                  </CardBody>
                </Card>
              ))}
          </Box>
        )}
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

export default ProfessorExamQuestionEditPage;
