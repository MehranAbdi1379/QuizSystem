import {
  Flex,
  HStack,
  Heading,
  Switch,
  Text,
  useColorMode,
} from "@chakra-ui/react";
import React from "react";
import NavButton from "./NavButton";

const Navbar = () => {
  const { colorMode, toggleColorMode } = useColorMode();
  return (
    <Flex p={4} justifyContent="space-between">
      <Heading>Quiz System</Heading>

      <HStack spacing={3}>
        <NavButton to="sign-in" name="Sign In"></NavButton>
        <NavButton to="sign-up" name="Sign Up"></NavButton>
        <NavButton to="about-us" name="About Us"></NavButton>
        <HStack>
          <Switch
            isChecked={colorMode === "dark"}
            onChange={toggleColorMode}
          ></Switch>
          <Text>Dark Mode</Text>
        </HStack>
      </HStack>
    </Flex>
  );
};

export default Navbar;
