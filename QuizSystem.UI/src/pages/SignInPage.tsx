import {
  Box,
  Button,
  Container,
  FormControl,
  FormLabel,
  Heading,
  Input,
  List,
  Text,
  VStack,
  useColorMode,
} from "@chakra-ui/react";
import React, { useState } from "react";
import { Form, Link, Navigate, redirect, useNavigate } from "react-router-dom";
import signIn, { user } from "../services/SignIn";
import { useForm } from "react-hook-form";
import GetAuthToken from "../services/Auth";

const SignInPage = () => {
  const { colorMode } = useColorMode();
  const [authenticated, setAuthenticated] = useState<boolean>(false);
  const [userRole, setUserRole] = useState("");
  const [error, setError] = useState();
  const {
    handleSubmit,
    register,
    formState: { errors },
  } = useForm();

  function onSubmit(user: user) {
    signIn(user)
      .then((res) => {
        localStorage.setItem("token", res.data.token);
        switch (res.data.role) {
          case "Admin":
            setUserRole(res.data.userId + "/admin");
            break;
          case "Student":
            setUserRole("student");
            break;
          case "Professor":
            setUserRole("professor");
            break;
          default:
            break;
        }
      })
      .then(() => setAuthenticated(true))
      .catch((err) => setError(err.message));
  }

  if (authenticated == true) {
    return <Navigate to={userRole}></Navigate>;
  }

  return (
    <Form
      onSubmit={handleSubmit((res) =>
        onSubmit({ nationalCode: res.nationalCode, password: res.password })
      )}
    >
      <Container
        marginTop={5}
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        padding="35px"
        borderRadius={50}
      >
        <List spacing={5}>
          <Box>
            <Heading>Sign in</Heading>
            <Text>to your account</Text>
          </Box>

          {error && (
            <Text color="red">National code or password is wrong.</Text>
          )}

          <FormControl>
            <FormLabel>National Code: </FormLabel>
            <Input required {...register("nationalCode")} type="number"></Input>
          </FormControl>
          <FormControl>
            <FormLabel>Password: </FormLabel>
            <Input required {...register("password")} type="password"></Input>
          </FormControl>
          <FormControl>
            <Button type="submit">Submit</Button>
          </FormControl>
        </List>
      </Container>
    </Form>
  );
};

export default SignInPage;
