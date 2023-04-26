import { Flex, HStack, Heading, Switch, Text } from "@chakra-ui/react";
import React from "react";
import NavButton from "./NavButton";

const Navbar = () => {
  return (
    <Flex p={4} justifyContent="space-between">
      <HStack>
        <Heading>Quiz System</Heading>
        <NavButton name="Sign In"></NavButton>
        <NavButton name="Sign Up"></NavButton>
        <NavButton name="About Us"></NavButton>
      </HStack>
      <HStack>
        <Switch defaultChecked></Switch>
        <Text>Dark Mode</Text>
      </HStack>
    </Flex>
  );
};

export default Navbar;
