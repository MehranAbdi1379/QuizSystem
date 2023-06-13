import {
  Container,
  List,
  FormControl,
  FormLabel,
  Input,
  Heading,
  Button,
  Box,
  useColorMode,
  RadioGroup,
  Radio,
  Text,
} from "@chakra-ui/react";
import React, { useState } from "react";
import { useForm } from "react-hook-form";
import {
  Form,
  Link,
  Navigate,
  useLocation,
  useNavigate,
} from "react-router-dom";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import QuestionService from "../../services/QuestionService";

const schema = z.object({
  title: z.string().min(3).max(20),
  description: z.string().min(5),
  type: z.string(),
  multipleChoiceAnswers: z.string().min(2).array().optional(),
  grade: z.number().min(0.1),
});

export type QuestionCreateFormData = z.infer<typeof schema>;

const ProfessorExamQuestionCreatePage = () => {
  const [submited, setSubmited] = useState(false);
  const navigate = useNavigate();
  const [type, setType] = useState<string>();
  const state = useLocation().state;
  const { colorMode } = useColorMode();
  const [answerCount, setAnswerCount] = useState<number>(2);
  const [multipleChoiceModeOn, setMultipleChoiceModeOn] = useState(false);
  const [error, setError] = useState();
  const { CreateAndAddQuestion } = new QuestionService();
  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm<QuestionCreateFormData>({ resolver: zodResolver(schema) });
  const answers = [];
  for (let i = 0; i < answerCount - 2; i++) {
    answers.push(
      <FormControl key={i}>
        <FormLabel>{i + 3}: </FormLabel>
        <Input
          {...register(`multipleChoiceAnswers.${i + 2}`)}
          type="text"
        ></Input>
      </FormControl>
    );
  }

  function handleCreateAndAddQuestion(data: QuestionCreateFormData) {
    CreateAndAddQuestion(data, state, setError, setSubmited, answerCount);
  }

  if (submited)
    return (
      <Navigate
        to={"../"}
        state={{ courseId: state.courseId, examId: state.examId }}
      ></Navigate>
    );
  return (
    <Form onSubmit={handleSubmit((data) => handleCreateAndAddQuestion(data))}>
      <Container
        marginTop={5}
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        padding="35px"
        borderRadius={50}
      >
        <List spacing={5}>
          <FormControl>
            <FormLabel>{"Title(Short): "}</FormLabel>
            <Input {...register("title")} type="text"></Input>
            {errors.title && (
              <Text color={"red.400"}>{errors.title.message}</Text>
            )}
          </FormControl>

          <FormControl>
            <FormLabel>Description: </FormLabel>
            <Input {...register("description")} type="text"></Input>
            {errors.description && (
              <Text color={"red.400"}>{errors.description.message}</Text>
            )}
          </FormControl>

          <FormControl>
            <FormLabel>Grade: </FormLabel>
            <Input
              step=".01"
              {...register("grade", { valueAsNumber: true })}
              type="number"
            ></Input>
            {errors.grade && (
              <Text color={"red.400"}>{errors.grade.message}</Text>
            )}
          </FormControl>

          {!multipleChoiceModeOn && (
            <FormControl>
              <RadioGroup
                onChange={(e) => {
                  setType(e);
                  setError(undefined);
                }}
              >
                <FormLabel>Question Type:</FormLabel>
                <Radio {...register("type")} value="Descriptive">
                  Descriptive
                </Radio>
                <Radio {...register("type")} value="Multiple Choice">
                  Multiple Choice
                </Radio>
              </RadioGroup>
            </FormControl>
          )}

          {type == "Multiple Choice" && !multipleChoiceModeOn && (
            <Box>
              <FormControl>
                <FormLabel>How many answers: </FormLabel>
                <Input
                  type="number"
                  onChange={(e) => {
                    if (parseInt(e.target.value) > 8) setAnswerCount(8);
                    else if (parseInt(e.target.value) < 2) setAnswerCount(2);
                    else setAnswerCount(parseInt(e.target.value));
                  }}
                ></Input>
                <Button
                  marginTop={3}
                  onClick={() => setMultipleChoiceModeOn(true)}
                >
                  Create Answers
                </Button>
              </FormControl>
            </Box>
          )}
          {multipleChoiceModeOn && (
            <List spacing={3}>
              <Heading>Answers: </Heading>
              <FormControl>
                <FormLabel>{"Right answer: "} </FormLabel>
                <Input
                  {...register("multipleChoiceAnswers.0")}
                  type="text"
                ></Input>
              </FormControl>
              <FormControl>
                <FormLabel>2: </FormLabel>
                <Input
                  {...register("multipleChoiceAnswers.1", {
                    required: true,
                  })}
                  type="text"
                ></Input>
              </FormControl>
              {answers}
              <FormControl>
                <Button type="submit">Submit</Button>
              </FormControl>
            </List>
          )}
          {type == "Descriptive" && (
            <FormControl>
              <Button type="submit">Submit</Button>
            </FormControl>
          )}
          {error && <Text color={"red.400"}>{error}</Text>}
        </List>
      </Container>
    </Form>
  );
};

export default ProfessorExamQuestionCreatePage;
