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
import { Form } from "react-router-dom";
import StudentService, { Student } from "../services/StudentService";
import ProfessorService, { Professor } from "../services/ProfessorService";
import { z } from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import CourseService, { Course } from "../services/CourseService";

const schema = z.object({
  title: z.string().min(3),
  startDate: z.coerce.date(),
  endDate: z.coerce.date(),
  professor: z.string(),
  students: z.string().array(),
});

type FormData = z.infer<typeof schema>;

const CourseCreatePage = () => {
  const { colorMode } = useColorMode();
  const [students, setStudents] = useState<Student[]>();
  const [professors, setProfessors] = useState<Professor[]>();
  const { GetAll: GetAllProfessors } = new ProfessorService();
  const { GetAll: GetAllStudents } = new StudentService();
  useEffect(() => {
    GetAllStudents(setStudents);
    GetAllProfessors(setProfessors);
  }, []);
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({
    resolver: zodResolver(schema),
  });
  const [addedStudents, setAddedStudents] = useState<{ id: string }[]>();
  const [moreThanSmall] = useMediaQuery("(min-width: 340px)");
  return (
    <Form onSubmit={handleSubmit((data) => console.log(data))}>
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
            <Select {...register("professor")}>
              {professors?.map((professor) => (
                <option key={professor.id} value={professor.id}>
                  {professor.firstName + " " + professor.lastName}
                </option>
              ))}
            </Select>
            {errors.professor && (
              <Text color={"red.400"}>{errors.professor.message}</Text>
            )}
          </FormControl>
          <FormControl>
            <SimpleGrid columns={3} minChildWidth={140}>
              {students?.sort().map((student) => (
                <HStack align={"stretch"} key={student.id}>
                  <FormLabel>
                    {student.firstName + " " + student.lastName}
                  </FormLabel>
                  {!moreThanSmall && <Spacer key={student.id}></Spacer>}
                  <Checkbox
                    {...register("students")}
                    paddingBottom={2}
                    type="checkbox"
                    value={student.id}
                  ></Checkbox>
                </HStack>
              ))}
            </SimpleGrid>
          </FormControl>
          <FormControl>
            <Button type="submit">Submit</Button>
          </FormControl>
        </List>
      </Container>
    </Form>
  );
};

export default CourseCreatePage;
