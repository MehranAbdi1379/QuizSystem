import React, { useEffect, useState } from "react";
import MultipleChoiceQuestionService, {
  Answer,
} from "../../services/MultipleChoiceQuestionService";
import { z } from "zod";
import {
  Box,
  Button,
  Container,
  FormControl,
  FormLabel,
  Heading,
  Input,
  List,
  Radio,
  RadioGroup,
  Text,
  useColorMode,
} from "@chakra-ui/react";
import { useForm } from "react-hook-form";
import { Form, useLocation, useNavigate } from "react-router-dom";
import { zodResolver } from "@hookform/resolvers/zod";

const schema = z.object({
  title: z.string().min(3).max(20, "Title should be shorter"),
  description: z.string().min(5),
});

type FormData = z.infer<typeof schema>;

const ProfessorMultipleChoiceQuestionEditPage = () => {
  const {
    Update,
    UpdateAnswer,
    CreateAnswer,
    DeleteAnswer,
    GetAnswerByQuestionId,
  } = new MultipleChoiceQuestionService();
  const [answers, setAnswers] = useState<Answer[]>();
  const { colorMode } = useColorMode();
  const state = useLocation().state;
  const [error, setError] = useState<string>();
  const navigate = useNavigate();
  const {
    formState: { errors },
    handleSubmit,
    register,
  } = useForm<FormData>({ resolver: zodResolver(schema) });
  useEffect(() => {
    GetAnswerByQuestionId(state.questionId, setError).then((res) =>
      setAnswers(res.data)
    );
  }, [state]);
  function handleQuestionUpdate(data: FormData) {
    Update(
      {
        id: state.questionId,
        title: data.title,
        description: data.description,
      },
      setError
    )
      .then(() => navigate(-1))
      .catch((err) => setError("Title is too long"));
  }
  return (
    <Form
      onSubmit={handleSubmit((data) => {
        handleQuestionUpdate(data);
      })}
    >
      <Container
        marginTop={5}
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        padding="35px"
        borderRadius={50}
      >
        <List spacing={5}>
          <FormControl>
            <FormLabel>{"Title(Short): "}</FormLabel>
            <Input
              {...register("title", { value: state.title })}
              type="text"
            ></Input>
            {errors.title && (
              <Text color={"red.400"}>{errors.title.message}</Text>
            )}
          </FormControl>

          <FormControl>
            <FormLabel>Description: </FormLabel>
            <Input
              {...register("description", { value: state.description })}
              type="text"
            ></Input>
            {errors.description && (
              <Text color={"red.400"}>{errors.description.message}</Text>
            )}
          </FormControl>

          <List spacing={3}>
            <Heading>Answers: </Heading>
            <FormControl>
              <FormLabel>{"Right answer: "} </FormLabel>
              <Input
                onChange={(e) => {
                  if (e.target.value.length > 2) {
                    UpdateAnswer(
                      {
                        ...answers?.filter((a) => a.rightAnswer == true)[0],
                        title: e.target.value,
                      },
                      setError
                    );
                  }
                }}
                type="text"
                defaultValue={
                  answers?.filter((a) => a.rightAnswer == true)[0].title
                }
              ></Input>
            </FormControl>
            <FormLabel>{"Other answers: "} </FormLabel>
            {answers
              ?.filter((a) => a.rightAnswer == false)
              .map((answer) => (
                <FormControl key={answer.id}>
                  <Input
                    onChange={(e) => {
                      if (e.target.value.length > 2) {
                        UpdateAnswer(
                          { ...answer, title: e.target.value },
                          setError
                        );
                      }
                    }}
                    defaultValue={answer.title}
                    type="text"
                  ></Input>
                </FormControl>
              ))}
          </List>
          <FormControl>
            <Button type="submit">Submit</Button>
          </FormControl>

          {error && <Text color={"red.400"}>{error}</Text>}
        </List>
      </Container>
    </Form>
  );
};

export default ProfessorMultipleChoiceQuestionEditPage;
