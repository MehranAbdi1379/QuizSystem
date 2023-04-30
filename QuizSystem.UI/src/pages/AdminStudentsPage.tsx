import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import StudentService, { Student } from "../services/StudentService";
import { Box, Heading, Text } from "@chakra-ui/react";

const AdminStudentsPage = () => {
  const params = useParams();
  const { GetById: GetStudentWithId } = new StudentService();
  const [student, setStudent] = useState<Student>();

  useEffect(() => {
    GetStudentWithId({ id: params.studentId }, setStudent);
  }, [params]);

  return (
    <Box paddingLeft={5}>
      <Heading>Student Page</Heading>
      {student && (
        <Box>
          <Heading fontSize={30}>
            {student.firstName + " " + student.lastName}
          </Heading>
          <Text>National Code: {student.nationalCode}</Text>
          <Text>
            Birth Date: {student.birthDate.toString().substring(0, 10)}
          </Text>
          {student.accepted && <Text>Accepted</Text>}
          {!student.accepted && <Text>Not Accepted</Text>}
        </Box>
      )}
    </Box>
  );
};

export default AdminStudentsPage;
