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
import { NavLink } from "react-router-dom";
import ProfessorResponsiveNavbar from "./ProfessorResponsiveNavbar";
import NavButton from "../Global/NavButton";

interface Props {
  name: string;
}

const ProfessorNavbar = ({ name }: Props) => {
  const { colorMode, toggleColorMode } = useColorMode();
  const [moreThanMedium] = useMediaQuery("(min-width: 820px)");

  return (
    <Flex p={4} justifyContent="space-between">
      <Heading>
        <NavLink to="/sign-in/professor">Quiz System</NavLink>
      </Heading>

      <HStack spacing={3}>
        {moreThanMedium && <Text>Welcome Mr/Ms {name}</Text>}
        {moreThanMedium && (
          <NavButton
            to="/"
            name="Sign out"
            onClick={() => {
              localStorage.removeItem("token");
              localStorage.removeItem("userId");
            }}
          ></NavButton>
        )}
        {moreThanMedium && (
          <NavButton to="/sign-in/about-us" name="About Us"></NavButton>
        )}

        {moreThanMedium && (
          <HStack>
            <Switch
              isChecked={colorMode === "dark"}
              onChange={toggleColorMode}
            ></Switch>
            <Text>Dark Mode</Text>
          </HStack>
        )}
      </HStack>

      {!moreThanMedium && (
        <ProfessorResponsiveNavbar></ProfessorResponsiveNavbar>
      )}
    </Flex>
  );
};

export default ProfessorNavbar;
