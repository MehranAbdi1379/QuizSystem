import {
  useColorMode,
  Container,
  List,
  Heading,
  Card,
  CardHeader,
  CardBody,
  CardFooter,
  Button,
  Box,
  Text,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { Link, useLocation } from "react-router-dom";
import DescriptiveQuestionService from "../../services/DescriptiveQuestionService";
import MultipleChoiceQuestionService from "../../services/MultipleChoiceQuestionService";
import { Question } from "../../services/QuestionService";
import GradedQuestionService from "../../services/GradedQuestionService";

const ProfessorAllQuestionsPage = () => {
  const { GetByCourseAndProfessorId, Delete } =
    new DescriptiveQuestionService();
  const {
    GetByCourseAndProfessorId: GetMultipleQuestions,
    DeleteMultipleChoiceQuestionAndAnswers,
  } = new MultipleChoiceQuestionService();
  const [descriptiveQuestions, setDescriptiveQuestions] =
    useState<Question[]>();
  const [multipleChoiceQuestions, setMultipleChoiceQuestions] =
    useState<Question[]>();
  const [error, setError] = useState();
  const state = useLocation().state;
  const { colorMode } = useColorMode();
  const [deleteCounter, setDeleteCounter] = useState(0);

  useEffect(() => {
    GetByCourseAndProfessorId(
      state.courseId,
      localStorage.getItem("userId"),
      setDescriptiveQuestions,
      setError
    );
    GetMultipleQuestions(
      state.courseId,
      localStorage.getItem("userId"),
      setMultipleChoiceQuestions,
      setError
    );
  }, [state, deleteCounter]);
  return (
    <Container marginTop={10} maxWidth={600}>
      <List spacing={5}>
        <Box
          p={5}
          bg={colorMode == "dark" ? "gray.600" : "gray.100"}
          borderRadius={20}
        >
          <Heading fontSize={28}>Descriptive Questions: </Heading>
          {descriptiveQuestions?.map((descriptiveQuestion) => (
            <Card key={descriptiveQuestion.id} margin={5}>
              <CardHeader>
                <Heading fontSize={24}>{descriptiveQuestion.title}</Heading>
              </CardHeader>
              <CardBody>
                <Text>{descriptiveQuestion.description}</Text>
              </CardBody>
              <CardFooter>
                <Link
                  state={{
                    courseId: descriptiveQuestion.courseId,
                    questionId: descriptiveQuestion.id,
                    title: descriptiveQuestion.title,
                    description: descriptiveQuestion.description,
                    professorId: descriptiveQuestion.professorId,
                  }}
                  to={"/sign-in/professor/course/question/descriptive/edit"}
                >
                  <Button>Edit</Button>
                </Link>
                <Button
                  colorScheme="red"
                  marginLeft={5}
                  onClick={() => {
                    Delete(descriptiveQuestion.id)
                      .then(() => setDeleteCounter(deleteCounter + 1))
                      .catch((err) => setError(err.response.data));
                  }}
                >
                  Delete
                </Button>
              </CardFooter>
            </Card>
          ))}
        </Box>
        <Box
          p={5}
          borderRadius={20}
          bg={colorMode == "dark" ? "gray.600" : "gray.100"}
        >
          <Heading fontSize={28}>Multiple Choice Questions: </Heading>
          {multipleChoiceQuestions?.map((multipleChoiceQuestion) => (
            <Card key={multipleChoiceQuestion.id} margin={5}>
              <CardHeader>
                <Heading fontSize={24}>{multipleChoiceQuestion.title}</Heading>
              </CardHeader>
              <CardBody>
                <Text>{multipleChoiceQuestion.description}</Text>
              </CardBody>
              <CardFooter>
                <Link
                  state={{
                    courseId: multipleChoiceQuestion.courseId,
                    questionId: multipleChoiceQuestion.id,
                    title: multipleChoiceQuestion.title,
                    description: multipleChoiceQuestion.description,
                    professorId: multipleChoiceQuestion.professorId,
                  }}
                  to={"/sign-in/professor/course/question/multiple-choice/edit"}
                >
                  <Button>Edit</Button>
                </Link>
                <Button
                  colorScheme="red"
                  marginLeft={5}
                  onClick={() => {
                    DeleteMultipleChoiceQuestionAndAnswers(
                      multipleChoiceQuestion.id,
                      setError
                    ).then(() => setDeleteCounter(deleteCounter + 1));
                  }}
                >
                  Delete
                </Button>
              </CardFooter>
            </Card>
          ))}
        </Box>
      </List>
    </Container>
  );
};

export default ProfessorAllQuestionsPage;
