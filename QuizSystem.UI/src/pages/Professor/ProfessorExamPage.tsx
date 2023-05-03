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

const ProfessorExamPage = () => {
  const { colorMode } = useColorMode();
  const state = useLocation().state;
  const [exam, setExam] = useState<Exam>();
  const { GetById } = new ExamService();
  console.log(state);

  useEffect(() => {
    GetById(state.examId, setExam);
  }, [state]);
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
