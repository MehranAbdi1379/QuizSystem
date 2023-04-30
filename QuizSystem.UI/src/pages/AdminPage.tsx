import React, { useEffect, useState } from "react";
import AdminService from "../services/AdminService";
import { Outlet, useParams } from "react-router-dom";
import { Grid, GridItem, SimpleGrid } from "@chakra-ui/react";
import AdminSidebar from "../components/AdminSidebar";

interface admin {
  id: string;
  firstName: string;
  lastName: string;
  birthDate: Date;
  nationalCode: string;
}

const AdminPage = () => {
  const params = useParams();
  const [user, setUser] = useState<admin>();
  useEffect(() => {
    const { GetAdminById } = new AdminService();
    if (params.id) GetAdminById(params, setUser);
  }, []);

  return (
    <>
      <Grid templateColumns={"repeat(6 , 1fr)"}>
        <GridItem colSpan={{ base: 6, md: 2, lg: 1 }}>
          <AdminSidebar></AdminSidebar>
        </GridItem>
        <GridItem colSpan={{ base: 6, md: 4, lg: 5 }}>
          <Outlet></Outlet>
        </GridItem>
      </Grid>
    </>
  );
};

export default AdminPage;
