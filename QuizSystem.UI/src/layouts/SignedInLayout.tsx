import React, { useEffect, useState } from "react";
import { Outlet, useParams } from "react-router-dom";
import AdminNavbar from "../components/Admin/AdminNavbar";
import UserServices from "../services/UserServices";
import { SimpleGrid } from "@chakra-ui/react";
import ProfessorNavbar from "../components/Professor/ProfessorNavbar";
import StudentNavbar from "../components/Student/StudentNavbar";

interface fullName {
  firstName: string;
  lastName: string;
  role: string;
}

const SignedInLayout = () => {
  const [fullName, setName] = useState<fullName>();
  const userId = localStorage.getItem("userId");
  const { GetNameById } = new UserServices();

  useEffect(() => {
    GetNameById(userId, setName);
  }, []);

  return (
    <>
      {fullName?.role == "Admin" && (
        <AdminNavbar
          name={fullName.firstName + " " + fullName.lastName}
        ></AdminNavbar>
      )}
      {fullName?.role == "Professor" && (
        <ProfessorNavbar
          name={fullName.firstName + " " + fullName.lastName}
        ></ProfessorNavbar>
      )}
      {fullName?.role == "Student" && (
        <StudentNavbar
          name={fullName.firstName + " " + fullName.lastName}
        ></StudentNavbar>
      )}
      <SimpleGrid>
        <Outlet />
      </SimpleGrid>
    </>
  );
};

export default SignedInLayout;
