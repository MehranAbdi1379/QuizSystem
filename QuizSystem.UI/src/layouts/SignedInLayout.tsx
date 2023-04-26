import React from "react";
import Navbar from "../components/NavbarRoot";
import { Outlet } from "react-router-dom";
import NavbarSignedIn from "../components/NavbarSignedIn";

const SignedInLayout = () => {
  return (
    <>
      <NavbarSignedIn />
      <Outlet />
    </>
  );
};

export default SignedInLayout;
