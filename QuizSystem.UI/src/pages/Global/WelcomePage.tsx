import {
  Button,
  Container,
  FormControl,
  FormHelperText,
  Heading,
  Highlight,
  Link,
  Text,
} from "@chakra-ui/react";
import React from "react";
import { NavLink } from "react-router-dom";

const WelcomePage = () => {
  return (
    <>
      <Container p={5}>
        <Heading paddingBottom={5}>
          Exam/Course Managemenet System for Education
        </Heading>
        <Text paddingBottom={5}>
          Quiz system is a course/exam managemenet app for educational purposes.
          Schools and universities use this app to make the educational
          experience better.
        </Text>
        <NavLink to="sign-in-page">
          <Button marginBottom={1}>Sign In</Button>
        </NavLink>

        <Text>
          Don't have an account?
          <NavLink to="sign-up"> Sign up</NavLink>
        </Text>
      </Container>
    </>
  );
};

export default WelcomePage;
