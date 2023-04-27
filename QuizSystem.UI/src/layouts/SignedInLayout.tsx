import React, { useEffect, useState } from "react";
import Navbar from "../components/NavbarRoot";
import { Outlet, useParams } from "react-router-dom";
import NavbarSignedIn from "../components/NavbarSignedIn";
import authApiClient from "../services/AuthApiClient";
import GetAuthToken from "../services/Auth";
import UserServices from "../services/UserServices";
import { SimpleGrid } from "@chakra-ui/react";

interface fullName {
  firstName: string;
  lastName: string;
}

const SignedInLayout = () => {
  const [fullName, setName] = useState<fullName>({
    firstName: "",
    lastName: "",
  });
  const params = useParams();
  const { GetNameById } = new UserServices();

  useEffect(() => {
    if (params.id) GetNameById(params, setName);
  }, []);

  return (
    <>
      <NavbarSignedIn
        name={fullName.firstName + " " + fullName.lastName}
      ></NavbarSignedIn>
      <SimpleGrid>
        <Outlet />
      </SimpleGrid>
    </>
  );
};

export default SignedInLayout;
