import {
  Flex,
  HStack,
  Heading,
  Switch,
  Text,
  useColorMode,
  useMediaQuery,
} from "@chakra-ui/react";
import React, { useState } from "react";
import NavButton from "./NavButton";
import { NavLink, Navigate } from "react-router-dom";
import SideNavbar from "./SideNavbar";

const Navbar = () => {
  const { colorMode, toggleColorMode } = useColorMode();
  const [moreThanMedium] = useMediaQuery("(min-width: 800px)");
  const [moreThanSmall] = useMediaQuery("(min-width: 420px)");

  return (
    <Flex p={4} justifyContent="space-between">
      <Heading>
        <NavLink to="/">Quiz System</NavLink>
      </Heading>

      <HStack spacing={3}>
        {moreThanMedium && <NavButton to="/sign-in" name="Sign In"></NavButton>}

        {moreThanMedium && <NavButton to="/sign-up" name="Sign Up"></NavButton>}
        {moreThanMedium && (
          <NavButton to="/about-us" name="About Us"></NavButton>
        )}

        {moreThanSmall && (
          <HStack>
            <Switch
              isChecked={colorMode === "dark"}
              onChange={toggleColorMode}
            ></Switch>
            <Text>Dark Mode</Text>
          </HStack>
        )}
      </HStack>
      {!moreThanSmall && <SideNavbar></SideNavbar>}
    </Flex>
  );
};

export default Navbar;
