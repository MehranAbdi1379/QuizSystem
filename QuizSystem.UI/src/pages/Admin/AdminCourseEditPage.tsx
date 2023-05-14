import React, { useEffect, useState } from "react";
import CourseService, { Course } from "../../services/CourseService";
import {
  Container,
  Heading,
  Select,
  Button,
  Checkbox,
  Box,
  Text,
  Input,
  useColorMode,
  FormControl,
  FormLabel,
  HStack,
  List,
  SimpleGrid,
} from "@chakra-ui/react";
import UserDisplay from "../../components/Global/UserDisplay";
import { Form, Navigate, useLocation } from "react-router-dom";
import StudentService, { Student } from "../../services/StudentService";
import ProfessorService, { Professor } from "../../services/ProfessorService";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForceUpdate } from "framer-motion";

const schema = z.object({
  title: z.string().min(3),
  startDate: z.coerce.date(),
  endDate: z.coerce.date(),
  professorId: z.string(),
  studentIds: z.string().array(),
});

type FormData = z.infer<typeof schema>;

const AdminCourseEditPage = () => {
  const state: { course: Course; courseStudents: Student[] } =
    useLocation().state;
  const { colorMode } = useColorMode();
  const [professors, setProfessors] = useState<Professor[]>();
  const [students, setStudents] = useState<Student[]>();
  const [error, setError] = useState();
  const { GetAll } = new ProfessorService();
  const { GetAll: GetAllStudents } = new StudentService();
  const { Update, Delete } = new CourseService();
  const [deleteOn, setDeleteOn] = useState(false);
  useEffect(() => {
    GetAll(setProfessors);
    GetAllStudents(setStudents);
  }, []);
  const [submited, setSubmited] = useState(false);
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: zodResolver(schema),
  });
  function handleUpdateCourse(data: FormData) {
    const newCourse = {
      id: state.course.id,
      professorId: data.professorId
        ? data.professorId
        : state.course.professorId,
      endDate: data.endDate,
      startDate: data.startDate,
      studentIds: data.studentIds,
      title: data.title,
    };
    Update(newCourse, setError, setSubmited);
  }

  if (submited) return <Navigate to={"/sign-in/admin"}></Navigate>;
  return (
    <Container
      marginTop={5}
      bg={colorMode == "dark" ? "gray.700" : "gray.50"}
      padding="35px"
      borderRadius={50}
    >
      <Form onSubmit={handleSubmit((data) => handleUpdateCourse(data))}>
        <Container>
          <List spacing={5}>
            <FormControl>
              <FormLabel>Title: </FormLabel>
              <Input
                defaultValue={state.course.title}
                {...register("title")}
                type="text"
              ></Input>
              {errors.title && (
                <Text color={"red.400"}>{errors.title.message}</Text>
              )}
            </FormControl>

            <FormControl>
              <FormLabel>Start Date: </FormLabel>
              <Input
                defaultValue={state.course.timePeriod.startDate
                  .toString()
                  .slice(0, 10)}
                {...register("startDate")}
                type="date"
              ></Input>
              {errors.startDate && (
                <Text color={"red.400"}>{errors.startDate.message}</Text>
              )}
            </FormControl>

            <FormControl>
              <FormLabel>End Date: </FormLabel>
              <Input
                defaultValue={state.course.timePeriod.endDate
                  .toString()
                  .slice(0, 10)}
                {...register("endDate")}
                type="date"
              ></Input>
              {errors.endDate && (
                <Text color={"red.400"}>{errors.endDate.message}</Text>
              )}
            </FormControl>
            <FormControl>
              <FormLabel>Professor:</FormLabel>
              <Select {...register("professorId")}>
                {professors?.map((professor) => (
                  <option
                    key={professor.id}
                    value={professor.id}
                    defaultChecked={
                      state.course.professorId == professor.id ? true : false
                    }
                  >
                    {professor.firstName + " " + professor.lastName}
                  </option>
                ))}
              </Select>
              {errors.professorId && (
                <Text color={"red.400"}>{errors.professorId.message}</Text>
              )}
            </FormControl>
            <SimpleGrid columns={3} minChildWidth={140}>
              {students
                ?.map((x) => x)
                .filter(function (x) {
                  return state.courseStudents.map((x) => x.id).includes(x.id);
                })
                .map((student) => (
                  <FormControl key={student.id}>
                    <HStack align={"stretch"} key={student.id}>
                      <Checkbox
                        {...register("studentIds")}
                        paddingBottom={2}
                        type="checkbox"
                        value={student.id}
                        defaultChecked
                      ></Checkbox>
                      <FormLabel paddingBottom={2}>
                        {student.firstName + " " + student.lastName}
                      </FormLabel>
                    </HStack>
                  </FormControl>
                ))}
              {students
                ?.map((x) => x)
                .filter(function (x) {
                  return !state.courseStudents.map((x) => x.id).includes(x.id);
                })
                .map((student) => (
                  <FormControl>
                    <HStack align={"stretch"} key={student.id}>
                      <Checkbox
                        {...register("studentIds")}
                        paddingBottom={2}
                        type="checkbox"
                        value={student.id}
                      ></Checkbox>
                      <FormLabel paddingBottom={2}>
                        {student.firstName + " " + student.lastName}
                      </FormLabel>
                    </HStack>
                  </FormControl>
                ))}
            </SimpleGrid>
            {error && <Text color={"red.400"}>{error}</Text>}
            <FormControl>
              <Button type="submit">Submit</Button>
            </FormControl>
          </List>
          <Button
            colorScheme="red"
            marginTop={5}
            onClick={() => {
              setDeleteOn(true);
            }}
          >
            Delete This Course
          </Button>
        </Container>
      </Form>
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
                Delete(state.course.id);
                setSubmited(true);
                setDeleteOn(false);
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
    </Container>
  );
};

export default AdminCourseEditPage;
