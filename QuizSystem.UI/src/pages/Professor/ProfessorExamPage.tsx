import {
  Container,
  Heading,
  HStack,
  Button,
  Box,
  useColorMode,
  Text,
} from "@chakra-ui/react";

import React, { useEffect, useState } from "react";
import { Link, useLocation } from "react-router-dom";
import UserDisplay from "../../components/Global/UserDisplay";
import ExamService, { Exam } from "../../services/ExamService";
import ExamStudentService from "../../services/ExamStudentService";

const ProfessorExamPage = () => {
  const { colorMode } = useColorMode();
  const state = useLocation().state;
  const [exam, setExam] = useState<Exam>();
  const { GetById } = new ExamService();
  const [examStudents, setExamStudents] =
    useState<
      { id: string; studentId: string; examId: string; grade: number }[]
    >();
  const { GetAllByExamId } = new ExamStudentService();
  const [error, setError] = useState();

  useEffect(() => {
    GetById(state.examId, setExam);
    GetAllByExamId(state.examId, setExamStudents, setError);
  }, [state]);
  if (examStudents)
    return (
      <Container>
        <Box
          bg={colorMode == "dark" ? "gray.700" : "gray.50"}
          p={10}
          borderRadius={50}
        >
          <Heading>{exam && <Text>{exam.title}</Text>}</Heading>

          <Heading paddingTop={5} fontSize={22}>
            Description:{" "}
          </Heading>
          <Text>{exam?.description}</Text>

          <Heading paddingTop={5} fontSize={22}>
            Time:{" "}
          </Heading>
          <Text>{exam?.time + " Minutes"} </Text>

          <Heading marginBottom={2} marginTop={5} fontSize={22}>
            Students:{" "}
          </Heading>

          {examStudents.map((es) => (
            <Link
              to={"/sign-in/professor/course/exam/mark"}
              state={{
                examId: state.examId,
                courseId: state.courseId,
                studentId: es.studentId,
              }}
            >
              <Button>
                <UserDisplay id={es.studentId}></UserDisplay>
              </Button>
            </Link>
          ))}
        </Box>
      </Container>
    );
  return (
    <Container>
      <Box
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        p={10}
        borderRadius={50}
      >
        <Heading>{exam && <Text>{exam.title}</Text>}</Heading>

        <Heading paddingTop={5} fontSize={22}>
          Description:{" "}
        </Heading>
        <Text>{exam?.description}</Text>

        <Heading paddingTop={5} fontSize={22}>
          Time:{" "}
        </Heading>
        <Text>{exam?.time + " Minutes"} </Text>

        <Heading marginTop={5} fontSize={22}></Heading>

        <Link
          to="/sign-in/professor/course/exam/edit"
          state={{
            examId: state.examId,
            examEdited: false,
            courseId: state.courseId,
          }}
        >
          <Button marginTop={5}>Edit exam</Button>
        </Link>
      </Box>
    </Container>
  );
};

export default ProfessorExamPage;
