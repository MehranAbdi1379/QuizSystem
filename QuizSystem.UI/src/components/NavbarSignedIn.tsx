import {
  Flex,
  Heading,
  HStack,
  Switch,
  Text,
  useColorMode,
  useMediaQuery,
} from "@chakra-ui/react";
import React from "react";
import NavButton from "./NavButton";
import { NavLink } from "react-router-dom";

interface Props {
  name: string;
}

const NavbarSignedIn = ({ name }: Props) => {
  const { colorMode, toggleColorMode } = useColorMode();
  const [moreThanMedium] = useMediaQuery("(min-width: 820px)");

  return (
    <Flex p={4} justifyContent="space-between">
      <Heading>
        <NavLink to="/">Quiz System</NavLink>
      </Heading>

      <HStack spacing={3}>
        {moreThanMedium && <Text>Welcome Mr/Ms {name}</Text>}
        <NavButton
          to="/"
          name="Sign out"
          onClick={() => localStorage.removeItem("token")}
        ></NavButton>
        {moreThanMedium && (
          <NavButton to="/about-us" name="About Us"></NavButton>
        )}

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
