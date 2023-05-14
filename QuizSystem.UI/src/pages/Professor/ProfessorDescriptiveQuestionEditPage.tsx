import {
  Container,
  List,
  FormControl,
  FormLabel,
  Input,
  Button,
  useColorMode,
  Text,
} from "@chakra-ui/react";
import { zodResolver } from "@hookform/resolvers/zod";
import { useState } from "react";
import { useForm } from "react-hook-form";
import { Form, useLocation } from "react-router-dom";
import { z } from "zod";
import DescriptiveQuestionService from "../../services/DescriptiveQuestionService";

const schema = z.object({
  title: z.string().min(3),
  description: z.string().min(5),
});

type FormData = z.infer<typeof schema>;

const ProfessorDescriptiveQuestionEditPage = () => {
  const { colorMode } = useColorMode();
  const [error, setError] = useState();
  const state = useLocation().state;
  const {
    formState: { errors },
    handleSubmit,
    register,
  } = useForm<FormData>({ resolver: zodResolver(schema) });
  const { Update } = new DescriptiveQuestionService();
  function handleUpdate(data: { description: string; title: string }) {
    var newQuestion = {
      title: data.title,
      description: data.description,
      courseId: state.courseId,
      professorId: state.professorId,
      id: state.questionId,
    };
    Update(newQuestion)
      .then(() => history.back())
      .catch((err) => setError(err.response.data));
  }

  return (
    <Form onSubmit={handleSubmit((data) => handleUpdate(data))}>
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
              {...register("title")}
              defaultValue={state.title}
              type="text"
            ></Input>
            {errors.title && (
              <Text color={"red.400"}>{errors.title.message}</Text>
            )}
          </FormControl>

          <FormControl>
            <FormLabel>Description: </FormLabel>
            <Input
              {...register("description")}
              defaultValue={state.description}
              type="text"
            ></Input>
            {errors.description && (
              <Text color={"red.400"}>{errors.description.message}</Text>
            )}
          </FormControl>

          <FormControl>
            <Button type="submit">Submit</Button>
          </FormControl>
          {error && <Text color={"red.400"}>{error}</Text>}
        </List>
      </Container>
    </Form>
  );
};

export default ProfessorDescriptiveQuestionEditPage;
