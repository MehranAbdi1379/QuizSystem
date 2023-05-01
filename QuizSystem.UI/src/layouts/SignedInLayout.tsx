import React, { useEffect, useState } from "react";
import { Outlet, useParams } from "react-router-dom";
import AdminNavbar from "../components/Admin/AdminNavbar";
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
  const userId = localStorage.getItem("userId");
  const { GetNameById } = new UserServices();

  useEffect(() => {
    GetNameById(userId, setName);
  }, []);

  return (
    <>
      <AdminNavbar
        name={fullName.firstName + " " + fullName.lastName}
      ></AdminNavbar>
      <SimpleGrid>
        <Outlet />
      </SimpleGrid>
    </>
  );
};

export default SignedInLayout;
