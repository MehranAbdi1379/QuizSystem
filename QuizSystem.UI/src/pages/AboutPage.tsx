import { Box, Button, Container, Heading, Text } from "@chakra-ui/react";
import React from "react";
import { Link } from "react-router-dom";
import Navbar from "../components/NavbarRoot";

const AboutPage = () => {
  return (
    <>
      <Navbar></Navbar>
      <Box textAlign="center" alignItems={"center"} padding={10} marginTop={4}>
        <Heading textAlign="center">
          This is what you should know about us.
        </Heading>
        <Text p={4}>
          We are trying to make the best possible system for online education.
          <br></br>
          Nowadays there are so many people learning from home and we are
          <br></br>
          trying to make both educators and students lives easier.
        </Text>
      </Box>
    </>
  );
};

export default AboutPage;
