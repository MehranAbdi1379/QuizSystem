import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import ProfessorService, { Professor } from "../services/ProfessorService";
import { Box, Heading, Text } from "@chakra-ui/react";

const AdminProfessorsPage = () => {
  const params = useParams();
  const { GetById } = new ProfessorService();
  const [professor, setProfessor] = useState<Professor>();
  const [courses, setCourses] = useState();

  useEffect(() => {
    GetById({ id: params.professorId }, setProfessor);
  }, [params]);

  return (
    <Box paddingLeft={5}>
      <Heading>Professor Page</Heading>
      {professor && (
        <Box>
          <Heading fontSize={30}>
            {professor.firstName + " " + professor.lastName}
          </Heading>
          <Text>National Code: {professor.nationalCode}</Text>
          <Text>
            Birth Date: {professor.birthDate.toString().substring(0, 10)}
          </Text>
          {professor.accepted && <Text>Accepted</Text>}
          {!professor.accepted && <Text>Not Accepted</Text>}
        </Box>
      )}
    </Box>
  );
};

export default AdminProfessorsPage;
