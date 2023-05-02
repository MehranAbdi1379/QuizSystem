import {
  Button,
  Checkbox,
  Container,
  Flex,
  FormControl,
  FormLabel,
  HStack,
  Input,
  List,
  Select,
  SimpleGrid,
  Spacer,
  Text,
  useColorMode,
  useMediaQuery,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { Form, Navigate, useLocation, useParams } from "react-router-dom";
import { z } from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import CourseService from "../../services/CourseService";
import ProfessorService, { Professor } from "../../services/ProfessorService";
import StudentService, { Student } from "../../services/StudentService";

const schema = z.object({
  title: z.string().min(3),
  startDate: z.coerce.date(),
  endDate: z.coerce.date(),
  professorId: z.string(),
  studentIds: z.string().array(),
});

type FormData = z.infer<typeof schema>;

const CourseCreatePage = () => {
  const state: { students: Student[]; professors: Professor[] } =
    useLocation().state;
  const { colorMode } = useColorMode();
  const [submited, setSubmited] = useState(false);
  const [courseId, setCourseId] = useState();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: zodResolver(schema),
  });
  const { Create } = new CourseService();
  function handleCreateCourse(data: FormData) {
    Create(data)
      .then((res) => setCourseId(res.data))
      .then(() => setSubmited(true));
  }

  if (submited)
    return (
      <Navigate
        to={"/sign-in/admin/course"}
        state={{ courseId: courseId }}
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
            <FormLabel>Start Date: </FormLabel>
            <Input {...register("startDate")} type="date"></Input>
            {errors.startDate && (
              <Text color={"red.400"}>{errors.startDate.message}</Text>
            )}
          </FormControl>
          <FormControl>
            <FormLabel>End Date: </FormLabel>
            <Input {...register("endDate")} type="date"></Input>
            {errors.endDate && (
              <Text color={"red.400"}>{errors.endDate.message}</Text>
            )}
          </FormControl>
          <FormControl>
            <FormLabel>Professor:</FormLabel>
            <Select {...register("professorId")}>
              {state.professors?.map((professor) => (
                <option key={professor.id} value={professor.id}>
                  {professor.firstName + " " + professor.lastName}
                </option>
              ))}
            </Select>
            {errors.professorId && (
              <Text color={"red.400"}>{errors.professorId.message}</Text>
            )}
          </FormControl>

          <SimpleGrid columns={3} minChildWidth={140}>
            {state.students?.sort().map((student) => (
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

export default CourseCreatePage;
