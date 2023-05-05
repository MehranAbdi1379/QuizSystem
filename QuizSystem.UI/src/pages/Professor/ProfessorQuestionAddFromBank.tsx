import { Box, Container, Text } from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import DescriptiveQuestionService from "../../services/DescriptiveQuestionService";
import MultipleChoiceQuestionService from "../../services/MultipleChoiceQuestionService";
import { useLocation } from "react-router-dom";
import { Question } from "../../services/QuestionService";

const ProfessorQuestionAddFromBank = () => {
  const { GetByCourseAndProfessorId } = new DescriptiveQuestionService();
  const { GetByCourseAndProfessorId: GetMultipleQuestions } =
    new MultipleChoiceQuestionService();
  const [descriptiveQuestions, setDescriptiveQuestions] =
    useState<Question[]>();
  const [multipleChoiceQuestions, setMultipleChoiceQuestions] =
    useState<Question[]>();
  const [error, setError] = useState();
  const state = useLocation().state;

  useEffect(() => {
    GetByCourseAndProfessorId(
      state.courseId,
      localStorage.getItem("userId"),
      setDescriptiveQuestions,
      setError
    );
    GetMultipleQuestions(
      state.courseId,
      localStorage.getItem("userId"),
      setMultipleChoiceQuestions,
      setError
    );
  }, [state]);
  return (
    <Container>
      {descriptiveQuestions?.map((q) => (
        <Text>{q.title}</Text>
      ))}
      {multipleChoiceQuestions?.map((q) => (
        <Text>{q.title}</Text>
      ))}
    </Container>
  );
};

export default ProfessorQuestionAddFromBank;
