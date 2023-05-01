import React, { useEffect, useState } from "react";
import { Outlet, useParams } from "react-router-dom";
import { Grid, GridItem, SimpleGrid, useMediaQuery } from "@chakra-ui/react";
import AdminService from "../../services/AdminService";
import AdminSidebar from "../../components/Admin/AdminSidebar";

interface admin {
  id: string;
  firstName: string;
  lastName: string;
  birthDate: Date;
  nationalCode: string;
}

const AdminPage = () => {
  const [moreThanMedium] = useMediaQuery("(min-width: 820px)");
  return (
    <>
      <Grid templateColumns={"repeat(6 , 1fr)"}>
        {moreThanMedium && (
          <GridItem colSpan={{ base: 6, md: 2, lg: 1 }}>
            <AdminSidebar></AdminSidebar>
          </GridItem>
        )}
        <GridItem colSpan={{ base: 6, md: 4, lg: 5 }}>
          <Outlet></Outlet>
        </GridItem>
      </Grid>
    </>
  );
};

export default AdminPage;
