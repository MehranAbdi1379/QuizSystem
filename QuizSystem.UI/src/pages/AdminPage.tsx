import React, { useEffect, useState } from "react";
import AdminService from "../services/AdminService";
import { useParams } from "react-router-dom";
import { Grid, GridItem, SimpleGrid } from "@chakra-ui/react";
import AdminSidebar from "../components/Sidebar";

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
        <GridItem colSpan={{ sm: 6, md: 2, lg: 1 }} bg="blue">
          <AdminSidebar></AdminSidebar>
        </GridItem>
        <GridItem colSpan={{ sm: 6, md: 4, lg: 5 }}></GridItem>
      </Grid>
    </>
  );
};

export default AdminPage;
