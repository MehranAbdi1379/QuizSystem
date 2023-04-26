import {
  Button,
  Container,
  FormControl,
  FormHelperText,
  Heading,
  Link,
  Text,
} from "@chakra-ui/react";
import React from "react";
import { NavLink } from "react-router-dom";

const WelcomePage = () => {
  return (
    <>
      <Container>
        <Heading>Exam/Course Managemenet System for Education</Heading>
        <Text>
          Quiz system is a course/exam managemenet app for educational purposes.
          Schools and universities use this app to make the educational
          experience better.
        </Text>
        <Button>Sign In</Button>
        <Text>
          Don't have an account?
          <NavLink to="sign-up">
            <Link> Sign up</Link>
          </NavLink>
        </Text>
      </Container>
    </>
  );
};

export default WelcomePage;
