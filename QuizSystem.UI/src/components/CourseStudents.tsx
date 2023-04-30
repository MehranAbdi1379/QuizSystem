import React, { useEffect, useState } from "react";
import StudentService, { Student } from "../services/StudentService";
import { Box, Text } from "@chakra-ui/react";

interface Props {
  studentId: { id: string };
}

const CourseStudents = ({ studentId }: Props) => {
  const { GetById: GetStudentWithId } = new StudentService();
  const [student, setStudent] = useState<Student>();
  useEffect(() => {
    GetStudentWithId(studentId, setStudent);
  }, []);
  return (
    <Box>
      {student?.firstName} {student?.lastName}
    </Box>
  );
};

export default CourseStudents;
