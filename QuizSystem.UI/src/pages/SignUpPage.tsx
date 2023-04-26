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
} from "@chakra-ui/react";
import React from "react";
import { Form } from "react-router-dom";

const SignUpPage = () => {
  const { colorMode } = useColorMode();
  const date = new Date(1990, 1);
  return (
    <Form>
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
            <Input type="text"></Input>
          </FormControl>
          <FormControl>
            <FormLabel>Last name: </FormLabel>
            <Input type="text"></Input>
          </FormControl>
          <FormControl>
            <FormLabel>National Code: </FormLabel>
            <Input type="number"></Input>
          </FormControl>
          <FormControl>
            <FormLabel>Password: </FormLabel>
            <Input type="password"></Input>
          </FormControl>
          <FormControl>
            <FormLabel>Date of birth: </FormLabel>
            <Input type="date"></Input>
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
