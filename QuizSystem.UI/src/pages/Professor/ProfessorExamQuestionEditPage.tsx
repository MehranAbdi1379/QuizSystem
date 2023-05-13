import {
  Box,
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Container,
  Heading,
  List,
  Text,
  useColorMode,
  useStatStyles,
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
  const { GetAllByExamId } = new GradedQuestionService();
  const [gradedQuestions, setGradedQuestions] =
    useState<{ questionId: string; examId: string; grade: number }[]>();
  const [error, setError] = useState();
  const { colorMode } = useColorMode();

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
  });
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
                        <Text>Grade: {que.grade}</Text>
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
            borderRadius={20}
            bg={colorMode == "dark" ? "gray.600" : "gray.100"}
          >
            <Heading>Multiple Choice Questions: </Heading>
            {multipleChoiceQuestions
              ?.map((q) => q)
              .filter(function (q) {
                return gradedQuestions?.map((q) => q.questionId).includes(q.id);
              })
              .map((q) => (
                <Card margin={5} key={q.id}>
                  <CardHeader>
                    <Heading fontSize={24}>{q.title}</Heading>
                  </CardHeader>
                  <CardBody>
                    <Text>{q.description}</Text>
                  </CardBody>
                  <CardFooter>
                    <Button>Add</Button>
                  </CardFooter>
                </Card>
              ))}
          </Box>
        )}
      </List>
    </Container>
  );
};

export default ProfessorExamQuestionEditPage;
