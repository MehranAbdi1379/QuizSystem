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
import React from "react";
import { Form } from "react-router-dom";

const SignInPage = () => {
  const { colorMode } = useColorMode();
  return (
    <Form>
      <Container
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        padding="35px"
        borderRadius={50}
      >
        <List spacing={5}>
          <Box>
            <Heading>Sign in</Heading>
            <Text>to your account</Text>
          </Box>

          <FormControl>
            <FormLabel>National Code: </FormLabel>
            <Input type="number"></Input>
          </FormControl>
          <FormControl>
            <FormLabel>Password: </FormLabel>
            <Input type="password"></Input>
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
