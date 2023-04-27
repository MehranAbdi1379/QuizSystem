import React, { useEffect, useState } from "react";
import Navbar from "../components/NavbarRoot";
import { Outlet, useParams } from "react-router-dom";
import NavbarSignedIn from "../components/NavbarSignedIn";
import authApiClient from "../services/AuthApiClient";
import GetAuthToken from "../services/Auth";
import UserServices from "../services/UserServices";

const SignedInLayout = () => {
  const [name, setName] = useState("");
  const params = useParams();
  const { GetNameById } = new UserServices();

  useEffect(() => {
    if (params.id) GetNameById(params, setName);
  }, []);

  return (
    <>
      <NavbarSignedIn name={name}></NavbarSignedIn>
      <Outlet />
    </>
  );
};

export default SignedInLayout;
