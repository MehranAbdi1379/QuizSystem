import React from "react";
import Navbar from "../components/NavbarRoot";
import { Outlet } from "react-router-dom";
import { Box } from "@chakra-ui/react";
import ResponsiveNavbarRoot from "../components/ResponsiveNavbarRoot";

const RootLayout = () => {
  return (
    <>
      <Navbar />
      <Outlet />
    </>
  );
};

export default RootLayout;
