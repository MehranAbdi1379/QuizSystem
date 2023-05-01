import {
  useColorMode,
  Heading,
  SimpleGrid,
  GridItem,
  Card,
  CardBody,
  Button,
  HStack,
  Box,
  Text,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import StudentService, { Student } from "../../services/StudentService";

const AdminAllStudentsPage = () => {
  const { GetAll } = new StudentService();
  const [students, setStudents] = useState<Student[]>();
  const { colorMode } = useColorMode();

  useEffect(() => {
    GetAll(setStudents);
  }, []);
  return (
    <Box paddingLeft={10} paddingTop={5} paddingRight={10}>
      <Heading paddingBottom={4}>Students</Heading>
      <SimpleGrid
        columns={5}
        minChildWidth={260}
        spacing={"40px"}
        paddingTop={5}
      >
        {students?.map((student) => (
          <GridItem>
            <Card bg={colorMode == "dark" ? "gray.600" : "gray.100"}>
              <CardBody>
                <Link to={"/sign-in/admin/student/" + student.id}>
                  <Button bg={colorMode == "dark" ? "gray.500" : "gray.300"}>
                    {student.firstName + " " + student.lastName}
                  </Button>
                </Link>
                <HStack paddingTop={5}>
                  <Text>National Code: </Text>
                  <Text>{student.nationalCode}</Text>
                </HStack>
                <HStack>
                  <Text>Birth Date: </Text>
                  <Text>{student.birthDate.toString().slice(0, 10)}</Text>
                </HStack>
              </CardBody>
            </Card>
          </GridItem>
        ))}
      </SimpleGrid>
    </Box>
  );
};

export default AdminAllStudentsPage;
