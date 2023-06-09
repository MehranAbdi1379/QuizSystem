import {
  Box,
  Button,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  Container,
  FormControl,
  FormLabel,
  HStack,
  Heading,
  Input,
  List,
  Text,
  VStack,
  useColorMode,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import DescriptiveQuestionService from "../../services/DescriptiveQuestionService";
import MultipleChoiceQuestionService from "../../services/MultipleChoiceQuestionService";
import { Form, useLocation, useNavigate } from "react-router-dom";
import QuestionService, { Question } from "../../services/QuestionService";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import GradedQuestionService from "../../services/GradedQuestionService";

const schema = z.object({
  grade: z
    .number({ invalid_type_error: "Grade must be a number" })
    .min(0.1, "Please enter a valid number"),
});

type FormData = z.infer<typeof schema>;

const ProfessorExamQuestionAddFromBank = () => {
  const { GetByCourseAndProfessorId } = new DescriptiveQuestionService();
  const { GetByCourseAndProfessorId: GetMultipleQuestions } =
    new MultipleChoiceQuestionService();
  const [descriptiveQuestions, setDescriptiveQuestions] =
    useState<Question[]>();
  const [multipleChoiceQuestions, setMultipleChoiceQuestions] =
    useState<Question[]>();
  const [error, setError] = useState();
  const state = useLocation().state;
  const { colorMode } = useColorMode();
  const { Create, GetAllByExamId } = new GradedQuestionService();
  const [gradedQuestions, setGradedQuestions] =
    useState<
      { id: string; questionId: string; examId: string; grade: number }[]
    >();
  const {
    formState: { errors },
    handleSubmit,
    register,
  } = useForm<FormData>({ resolver: zodResolver(schema) });
  const [questionId, setQuestionId] = useState<string>();
  const [gradePageOn, setGradePageOn] = useState(false);
  const navigate = useNavigate();

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
    GetAllByExamId(state.examId, setGradedQuestions, setError);
  }, [state]);
  if (gradePageOn == true)
    return (
      <Box
        position={"fixed"}
        left={0}
        top={0}
        right={0}
        width={"100vw"}
        height={"100vh"}
        bg={"blackAlpha.700"}
        zIndex={0}
      >
        <Box paddingLeft={"45vw"} paddingTop={"40vh"} margin={"auto"}>
          <Form
            onSubmit={handleSubmit((data) => {
              Create(
                {
                  questionId: questionId,
                  examId: state.examId,
                  grade: data.grade,
                },
                setError
              );
              navigate("/sign-in/professor/course/exam/edit", {
                state: { courseId: state.courseId, examId: state.examId },
              });
            })}
          >
            <VStack align={"start"}>
              <FormControl>
                <FormLabel>Grade: </FormLabel>
                <Input
                  type="number"
                  step=".01"
                  maxWidth={200}
                  {...register("grade", { valueAsNumber: true })}
                ></Input>
                <Button colorScheme="green" type="submit">
                  Submit
                </Button>
              </FormControl>
              <Text color={"red.400"}>{errors.grade?.message}</Text>
              <Button onClick={() => setGradePageOn(false)}>Back</Button>
            </VStack>
          </Form>
        </Box>
      </Box>
    );
  return (
    <Container marginTop={10} maxWidth={600}>
      <List spacing={5}>
        <Box
          p={5}
          bg={colorMode == "dark" ? "gray.600" : "gray.100"}
          borderRadius={20}
        >
          <Heading fontSize={28}>Descriptive Questions: </Heading>
          {descriptiveQuestions
            ?.map((q) => q)
            .filter(function (q) {
              return !gradedQuestions?.map((q) => q.questionId).includes(q.id);
            })
            .map((q) => (
              <Card key={q.id} margin={5}>
                <CardHeader>
                  <Heading fontSize={24}>{q.title}</Heading>
                </CardHeader>
                <CardBody>
                  <Text>{q.description}</Text>
                </CardBody>
                <CardFooter>
                  <Button
                    onClick={() => {
                      setGradePageOn(true);
                      setQuestionId(q.id);
                    }}
                  >
                    Add
                  </Button>
                  <Text>{errors?.grade?.message}</Text>
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
          {multipleChoiceQuestions
            ?.map((q) => q)
            .filter(function (q) {
              return !gradedQuestions?.map((q) => q.questionId).includes(q.id);
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
                  <Button
                    onClick={() => {
                      setGradePageOn(true);
                      setQuestionId(q.id);
                    }}
                  >
                    Add
                  </Button>
                </CardFooter>
              </Card>
            ))}
        </Box>
      </List>
    </Container>
  );
};

export default ProfessorExamQuestionAddFromBank;
