import {
  Container,
  List,
  Heading,
  FormControl,
  FormLabel,
  Input,
  Button,
  Box,
  Text,
  useColorMode,
  FormErrorMessage,
  RadioGroup,
  Radio,
  HStack,
  Flex,
} from "@chakra-ui/react";
import { useForm } from "react-hook-form";
import { Form, Navigate } from "react-router-dom";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";

import { useEffect, useState } from "react";
import UserServices, { UserSignUp } from "../../services/UserServices";
import { Student } from "../../services/StudentService";
import { Professor } from "../../services/ProfessorService";

const maxDate = new Date();
maxDate.setFullYear(maxDate.getFullYear() - 15);

const schema = z.object({
  firstName: z
    .string()
    .min(2, "First name should have more than 2 characters.")
    .max(50, "First name should have less than 50 characters."),
  lastName: z
    .string()
    .min(2, "Last name should have more than 2 characters.")
    .max(50, "Last name should have less than 50 characters."),
  nationalCode: z
    .string()
    .length(10, "National code should have 10 characters."),
  password: z
    .string()
    .min(6, "Password should have at least 6 characters.")
    .regex(
      new RegExp("^(?=.*[a-zA-Z])(?=.*[0-9])"),
      "Password should have at least a number and a character."
    ),
  birthDate: z.coerce
    .date()
    .min(new Date("1900-01-01"), "Too old...")
    .max(maxDate, "Too young..."),
  role: z.string(),
});

type FormData = z.infer<typeof schema>;

const SignUpPage = () => {
  const { colorMode } = useColorMode();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<FormData>({ resolver: zodResolver(schema) });
  const [user, setUser] = useState<UserSignUp>();

  const { SignUp } = new UserServices();

  useEffect(() => {
    if (user) localStorage.setItem("userId", user.id);
  }, [user]);
  let newUser: Student | Professor;

  if (user?.role == "student") {
    newUser = { ...user, id: user.id, courseIds: [], accepted: false };
    return (
      <Navigate state={{ student: newUser }} to="/sign-in/student"></Navigate>
    );
  }

  if (user?.role == "professor") {
    newUser = { ...user, id: user.id, courseIds: [], accepted: false };
    return (
      <Navigate
        state={{ professor: newUser }}
        to="/sign-in/professor"
      ></Navigate>
    );
  }
  return (
    <Form onSubmit={handleSubmit((data) => SignUp(data, setUser))}>
      <Container
        marginTop={5}
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        padding="35px"
        borderRadius={50}
      >
        <List spacing={5}>
          <Box>
            <Heading>Sign up</Heading>
            <Text>welcome to our website</Text>
          </Box>
          <FormControl>
            <FormLabel>First name: </FormLabel>
            <Input {...register("firstName")} type="text"></Input>
            {errors.firstName && (
              <Text color={"red.400"}>{errors.firstName.message}</Text>
            )}
          </FormControl>
          <FormControl>
            <FormLabel>Last name: </FormLabel>
            <Input {...register("lastName")} type="text"></Input>
            {errors.lastName && (
              <Text color={"red.400"}>{errors.lastName.message}</Text>
            )}
          </FormControl>
          <FormControl>
            <FormLabel>National Code: </FormLabel>
            <Input {...register("nationalCode")} type="number"></Input>
            {errors.nationalCode && (
              <Text color={"red.400"}>{errors.nationalCode.message}</Text>
            )}
          </FormControl>
          <FormControl>
            <FormLabel>Password: </FormLabel>
            <Input {...register("password")} type="password"></Input>
            {errors.password && (
              <Text color={"red.400"}>{errors.password.message}</Text>
            )}
          </FormControl>
          <FormControl>
            <FormLabel>Date of birth: </FormLabel>
            <Input {...register("birthDate")} type="date"></Input>
            {errors.birthDate && (
              <Text color={"red.400"}>{errors.birthDate.message}</Text>
            )}
          </FormControl>
          <FormControl>
            <Flex>
              <FormLabel>Student or Professor?</FormLabel>
              <RadioGroup>
                <Radio {...register("role")} value="student">
                  Student
                </Radio>
                <Radio {...register("role")} marginLeft={2} value="professor">
                  Professor
                </Radio>
              </RadioGroup>
            </Flex>
            {errors.role && (
              <Text color="red.400">
                Please determine if you are a student or a professor.
              </Text>
            )}
          </FormControl>
          <FormControl>
            <Button type="submit">Submit</Button>
          </FormControl>
        </List>
      </Container>
    </Form>
  );
};

export default SignUpPage;
