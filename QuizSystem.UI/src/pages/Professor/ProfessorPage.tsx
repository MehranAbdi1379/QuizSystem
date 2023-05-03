import { useMediaQuery, Grid, GridItem } from "@chakra-ui/react";
import { Outlet } from "react-router-dom";
import ProfessorSidebar from "../../components/Professor/ProfessorSidebar";

const ProfessorPage = () => {
  const [moreThanMedium] = useMediaQuery("(min-width: 820px)");
  return (
    <>
      <Grid templateColumns={"repeat(6 , 1fr)"}>
        {moreThanMedium && (
          <GridItem colSpan={{ base: 6, md: 2, lg: 1 }}>
            <ProfessorSidebar></ProfessorSidebar>
          </GridItem>
        )}
        <GridItem colSpan={{ base: 6, md: 4, lg: 5 }}>
          <Outlet></Outlet>
        </GridItem>
      </Grid>
    </>
  );
};

export default ProfessorPage;
