import {
  Flex,
  Heading,
  HStack,
  Switch,
  Text,
  useColorMode,
} from "@chakra-ui/react";
import React from "react";
import NavButton from "./NavButton";

interface Props {
  name: string;
}

const NavbarSignedIn = ({ name }: Props) => {
  const { colorMode, toggleColorMode } = useColorMode();
  return (
    <Flex p={4} justifyContent="space-between">
      <Heading>Quiz System</Heading>

      <HStack spacing={3}>
        <Text>Welcome Mr/Ms {name}</Text>
        <NavButton to="/" name="Sign out"></NavButton>
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

export default NavbarSignedIn;
