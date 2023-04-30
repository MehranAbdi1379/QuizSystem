import {
  Box,
  Flex,
  HStack,
  Icon,
  Switch,
  Text,
  VStack,
  useColorMode,
  useMediaQuery,
} from "@chakra-ui/react";
import React, { useState } from "react";
import NavButton from "./NavButton";
import { AddIcon, HamburgerIcon, MinusIcon } from "@chakra-ui/icons";

const ResponsiveNavbar = () => {
  const { colorMode, toggleColorMode } = useColorMode();
  const [sideNavbarOn, setSideNavbar] = useState<boolean>(false);

  return (
    <Box>
      <VStack
        p={10}
        bg="blackAlpha.800"
        top={0}
        left={0}
        position={"fixed"}
        width="100%"
        height="100%"
        spacing={5}
        transition={"1s"}
        transform={sideNavbarOn == false ? "translateY(-100vh)" : "none"}
      >
        <HamburgerIcon
          position={"absolute"}
          right={4}
          top={4}
          onClick={() => setSideNavbar(false)}
          boxSize={10}
        ></HamburgerIcon>
        <NavButton
          onClick={() => setSideNavbar(false)}
          to="/sign-in"
          name="Sign In"
        ></NavButton>

        <NavButton
          onClick={() => setSideNavbar(false)}
          to="/sign-up"
          name="Sign Up"
        ></NavButton>
        <NavButton
          onClick={() => setSideNavbar(false)}
          to="/about-us"
          name="About Us"
        ></NavButton>

        <HStack>
          <Switch
            isChecked={colorMode === "dark"}
            onChange={toggleColorMode}
          ></Switch>
          <Text color={"white"}>Dark Mode</Text>
        </HStack>
      </VStack>

      {!sideNavbarOn && (
        <HamburgerIcon
          onClick={() => setSideNavbar(true)}
          boxSize={10}
        ></HamburgerIcon>
      )}
    </Box>
  );
};

export default ResponsiveNavbar;
