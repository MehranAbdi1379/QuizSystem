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

const schema = z.object({
  title: z.string().min(3),
  startDate: z.coerce.date(),
  endDate: z.coerce.date(),
  professorId: z.string(),
  studentIds: z.string().array(),
});

type FormData = z.infer<typeof schema>;

const AdminCourseEditPage = () => {
  const { colorMode } = useColorMode();
  const state: { course: Course; courseStudents: Student[] } =
    useLocation().state;
  const [professors, setProfessors] = useState<Professor[]>();
  const [students, setStudents] = useState<Student[]>();
  const { GetAll } = new ProfessorService();
  const { GetAll: GetAllStudents } = new StudentService();
  const { Update } = new CourseService();
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
    const newCourse: Course = {
      id: state.course.id,
      professorId: data.professorId
        ? data.professorId
        : state.course.professorId,
      timePeriod: { endDate: data.endDate, startDate: data.startDate },
      studentIds: data.studentIds,
      title: data.title,
    };
    Update(newCourse);
    setSubmited(true);
  }

  if (submited) return <Navigate to={"/sign-in/admin"}></Navigate>;
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
                  selected={
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
                <FormControl>
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
          <FormControl>
            <Button type="submit">Submit</Button>
          </FormControl>
        </List>
      </Container>
    </Form>
  );
};

export default AdminCourseEditPage;
