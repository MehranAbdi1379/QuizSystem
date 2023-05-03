import {
  Container,
  List,
  FormControl,
  FormLabel,
  Input,
  Button,
  useColorMode,
  Text,
  Box,
  Heading,
} from "@chakra-ui/react";
import { zodResolver } from "@hookform/resolvers/zod";
import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import {
  Form,
  Navigate,
  useLoaderData,
  useLocation,
  useNavigate,
} from "react-router-dom";
import { z } from "zod";
import ExamService, { Exam } from "../../services/ExamService";

const schema = z.object({
  title: z.string(),
  description: z.string(),
  time: z.string(),
});

type FormData = z.infer<typeof schema>;
const ProfessorExamEditPage = () => {
  const navigate = useNavigate();
  const state = useLocation().state;
  const { colorMode } = useColorMode();
  const [submited, setSubmited] = useState(false);
  const [exam, setExam] = useState<Exam>();
  const [deleteOn, setDeleteOn] = useState(false);
  const { Update, GetById, Delete } = new ExamService();
  const [error, setError] = useState();
  console.log(state.courseId);
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: zodResolver(schema),
  });

  useEffect(() => {
    GetById(state.examId, setExam);
  }, [state]);

  function handleUpdateCourse(data: FormData) {
    const newExam = {
      id: exam?.id,
      courseId: exam?.courseId,
      description:
        data.description == "" ? exam?.description : data.description,
      time: data.time == "" ? exam?.time : parseInt(data.time),
      title: data.title == "" ? exam?.title : data.title,
    };
    console.log(newExam);
    Update(newExam, setExam, setError, setSubmited);
  }
  if (submited)
    return (
      <Navigate
        state={{ examId: exam?.id, examEdited: true, courseId: state.courseId }}
        to={"/sign-in/professor/course/exam"}
      ></Navigate>
    );
  return (
    <Form onSubmit={handleSubmit((data) => handleUpdateCourse(data))}>
      <Container
        marginTop={5}
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        padding="35px"
        borderRadius={50}
      >
        <List spacing={5}>
          <FormControl>
            <FormLabel>Title: </FormLabel>
            <Input
              defaultValue={exam?.title}
              {...register("title")}
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
              defaultValue={exam?.description}
              type="text"
            ></Input>
            {errors.title && (
              <Text color={"red.400"}>{errors.title.message}</Text>
            )}
          </FormControl>

          <FormControl>
            <FormLabel>{"Time(minutes): "} </FormLabel>
            <Input
              defaultValue={exam?.time}
              {...register("time")}
              type="number"
            ></Input>
            {errors.title && (
              <Text color={"red.400"}>{errors.title.message}</Text>
            )}
          </FormControl>
          <Text color={"red.400"}>{error}</Text>
          <FormControl>
            <Button type="submit">Submit</Button>
          </FormControl>
          <Button
            colorScheme="red"
            onClick={() => {
              setDeleteOn(true);
            }}
          >
            Delete Exam
          </Button>
        </List>
      </Container>
      {deleteOn && (
        <Box
          position={"fixed"}
          paddingLeft={"45%"}
          paddingTop={"20%"}
          left={0}
          top={0}
          right={0}
          width={"100vw"}
          height={"100vh"}
          bg={"blackAlpha.700"}
          zIndex={0}
        >
          <Box margin={"auto"}>
            <Heading marginBottom={3} fontSize={25} color={"white"}>
              Are you sure?{" "}
            </Heading>
            <Button
              colorScheme="red"
              fontSize={20}
              marginRight={3}
              p={7}
              paddingLeft={10}
              paddingRight={10}
              onClick={() => {
                Delete(exam?.id);
                console.log(state.courseId);
                navigate("/sign-in/professor/course", {
                  state: { courseId: state.courseId },
                });
              }}
            >
              Yes
            </Button>
            <Button
              colorScheme="green"
              fontSize={20}
              marginRight={3}
              p={7}
              paddingLeft={10}
              paddingRight={10}
              onClick={() => setDeleteOn(false)}
            >
              No
            </Button>
          </Box>
        </Box>
      )}
    </Form>
  );
};

export default ProfessorExamEditPage;
