import { Box, Button, HStack, Heading, Text } from "@chakra-ui/react";
import React from "react";
import { Link } from "react-router-dom";

const NotFoundPage = () => {
  return (
    <Box textAlign="center" alignItems={"center"} padding={10} marginTop={4}>
      <Heading textAlign="center">Oops! You seem to be lost.</Heading>
      <Text paddingTop={2}>Here are some helpful links:</Text>
      <Box marginTop={5} marginRight={5}>
        <Link to="/">
          <Button marginRight={2}>Home</Button>
        </Link>
        <Link to="/sign-in">
          <Button marginLeft={2}>Sign in</Button>
        </Link>
      </Box>
    </Box>
  );
};

export default NotFoundPage;
