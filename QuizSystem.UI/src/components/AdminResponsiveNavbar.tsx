import { HamburgerIcon } from "@chakra-ui/icons";
import {
  Box,
  HStack,
  Switch,
  Text,
  VStack,
  useColorMode,
} from "@chakra-ui/react";
import React, { useState } from "react";
import NavButton from "./NavButton";
import { useParams } from "react-router-dom";

const AdminResponsiveNavbar = () => {
  const params = useParams();
  const { colorMode, toggleColorMode } = useColorMode();
  const [sideNavbarOn, setSideNavbar] = useState<boolean>(false);
  return (
    <Box>
      <VStack
        zIndex={1}
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
          to={"/sign-in/" + params.id + "/admin"}
          name="Dashboard"
        ></NavButton>
        <NavButton
          onClick={() => setSideNavbar(false)}
          to="Courses"
          name="Courses"
        ></NavButton>

        <NavButton
          onClick={() => setSideNavbar(false)}
          to="Professors"
          name="Professors"
        ></NavButton>

        <NavButton
          onClick={() => setSideNavbar(false)}
          to="Students"
          name="Students"
        ></NavButton>
        <NavButton
          onClick={() => setSideNavbar(false)}
          to="/sign-in/admin/about-us"
          name="About Us"
        ></NavButton>
        <NavButton
          onClick={() => setSideNavbar(false)}
          to="/"
          name="Sign Out"
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

export default AdminResponsiveNavbar;
