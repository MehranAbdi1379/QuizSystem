import {
  Container,
  List,
  FormControl,
  FormLabel,
  Input,
  Select,
  SimpleGrid,
  HStack,
  Checkbox,
  Button,
  useColorMode,
  Text,
} from "@chakra-ui/react";
import { zodResolver } from "@hookform/resolvers/zod";
import React, { useState } from "react";
import { useForm } from "react-hook-form";
import { Form, Navigate, useLoaderData, useLocation } from "react-router-dom";
import { z } from "zod";
import ExamService, { Exam } from "../../services/ExamService";

const schema = z.object({
  title: z.string().min(3, "Title should have at least 3 characters"),
  description: z.string({
    invalid_type_error: "Descriptiong can not be empty.",
  }),
  time: z
    .number({ invalid_type_error: "Please enter a valid value." })
    .min(5, "Time should be more than 5 minutes."),
});

type FormData = z.infer<typeof schema>;

const ProfessorExamCreatePage = () => {
  const state = useLocation().state;
  const { colorMode } = useColorMode();
  const [submited, setSubmited] = useState(false);
  const [error, setError] = useState();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: zodResolver(schema),
  });
  const { Create } = new ExamService();
  function handleCreateCourse(data: FormData) {
    const newExam = {
      courseId: state.courseId,
      description: data.description,
      time: data.time,
      title: data.title,
    };
    Create(newExam, setError, setSubmited);
  }
  if (submited)
    return (
      <Navigate
        state={{ courseId: state.courseId, examCreated: true }}
        to={"/sign-in/professor/course"}
      ></Navigate>
    );
  return (
    <Form onSubmit={handleSubmit((data) => handleCreateCourse(data))}>
      <Container
        marginTop={5}
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        padding="35px"
        borderRadius={50}
      >
        <List spacing={5}>
          <FormControl>
            <FormLabel>Title: </FormLabel>
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
            <FormLabel>{"Time (minutes): "} </FormLabel>
            <Input
              {...register("time", { valueAsNumber: true })}
              type="number"
            ></Input>
            {errors.time && (
              <Text color={"red.400"}>{errors.time.message}</Text>
            )}
          </FormControl>
          {error && <Text color={"red.400"}>{error}</Text>}
          <FormControl>
            <Button type="submit">Submit</Button>
          </FormControl>
        </List>
      </Container>
    </Form>
  );
};

export default ProfessorExamCreatePage;
