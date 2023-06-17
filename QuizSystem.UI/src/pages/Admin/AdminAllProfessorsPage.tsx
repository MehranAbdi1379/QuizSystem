import {
  Box,
  Button,
  Card,
  CardBody,
  GridItem,
  HStack,
  Heading,
  SimpleGrid,
  Text,
  useColorMode,
} from "@chakra-ui/react";
import { useEffect, useState } from "react";
import ProfessorService, { Professor } from "../../services/ProfessorService";
import { Link } from "react-router-dom";

const AdminAllProfessorsPage = () => {
  const { GetAll } = new ProfessorService();
  const [professors, setProfessors] = useState<Professor[]>();
  const { colorMode } = useColorMode();

  useEffect(() => {
    GetAll(setProfessors);
  }, []);
  return (
    <Box paddingLeft={10} paddingTop={5} paddingRight={10}>
      <Heading paddingBottom={4}>Professors</Heading>
      <SimpleGrid
        columns={5}
        minChildWidth={260}
        spacing={"40px"}
        paddingTop={5}
      >
        {professors?.map((professor) => (
          <GridItem>
            <Card bg={colorMode == "dark" ? "gray.600" : "gray.100"}>
              <CardBody>
                <Link
                  to={"/sign-in/admin/professor/"}
                  state={{ professorId: professor.id }}
                >
                  <Button bg={colorMode == "dark" ? "gray.500" : "gray.300"}>
                    {professor.firstName + " " + professor.lastName}
                  </Button>
                </Link>
                <HStack paddingTop={5}>
                  <Text>National Code: </Text>
                  <Text>{professor.nationalCode}</Text>
                </HStack>
                <HStack>
                  <Text>Birth Date: </Text>
                  <Text>{professor.birthDate.toString().slice(0, 10)}</Text>
                </HStack>
              </CardBody>
            </Card>
          </GridItem>
        ))}
      </SimpleGrid>
    </Box>
  );
};

export default AdminAllProfessorsPage;
