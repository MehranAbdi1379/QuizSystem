import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import { Question } from "../../services/QuestionService";
import GradedQuestionService from "../../services/GradedQuestionService";
import {
  Box,
  Button,
  Card,
  CardBody,
  Container,
  Heading,
  Input,
  List,
  Text,
  useColorMode,
} from "@chakra-ui/react";
import ExamStudentService from "../../services/ExamStudentService";
import DescriptiveQuestionService from "../../services/DescriptiveQuestionService";
import MultipleChoiceQuestionService from "../../services/MultipleChoiceQuestionService";

const ProfessorExamMarkPage = () => {
  const state: {
    courseId: string;
    examId: string;
    studentId: string;
  } = useLocation().state;
  const [gradedDescriptiveQuestions, setGradedDescriptiveQuestions] =
    useState<
      { id: string; questionId: string; examId: string; grade: number }[]
    >();
  const [GradedMultipleChoiceQuestions, setGradedMultipleChoiceQuestions] =
    useState<
      { id: string; questionId: string; examId: string; grade: number }[]
    >();
  const [descriptiveQuestions, setDescriptiveQuestions] =
    useState<Question[]>();
  const [multipleChoiceQuestions, setMultipleChoiceQuestions] =
    useState<Question[]>();
  const {
    Update,
    Delete,
    GetDescriptiveQuestionsOnly,
    GetMultipleChoiceQuestionsOnly,
  } = new GradedQuestionService();

  const [examStudentQuestions, setExamStudentQuestions] = useState<
    {
      id: string;
      examStudentId: string;
      gradedQuestionId: string;
      grade: number;
    }[]
  >();
  const { GetAllQuestionsByExamAndStudentId } = new ExamStudentService();
  const { GetAllByExamId: GetDescriptiveQuestionsByExamId } =
    new DescriptiveQuestionService();
  const { GetAllByExamId: GetMutlipleChoiceQuestionByExamId } =
    new MultipleChoiceQuestionService();
  const [error, setError] = useState();
  const { colorMode } = useColorMode();
  var gradeSum: number = 0;
  GradedMultipleChoiceQuestions?.forEach((element) => {
    gradeSum += element.grade;
  });
  gradedDescriptiveQuestions?.forEach((element) => {
    gradeSum += element.grade;
  });

  useEffect(() => {
    GetDescriptiveQuestionsOnly(
      state.examId,
      setGradedDescriptiveQuestions,
      setError
    );
    GetMultipleChoiceQuestionsOnly(
      state.examId,
      setGradedMultipleChoiceQuestions,
      setError
    );
    GetAllQuestionsByExamAndStudentId(
      state.examId,
      state.studentId,
      setExamStudentQuestions,
      setError
    );
    GetDescriptiveQuestionsByExamId(
      state.examId,
      setDescriptiveQuestions,
      setError
    );
    GetMutlipleChoiceQuestionByExamId(
      state.examId,
      setMultipleChoiceQuestions,
      setError
    );
  }, [state]);
  return (
    <Container marginTop={10} maxWidth={600}>
      <List spacing={5}>
        {descriptiveQuestions
          ?.map((q) => q)
          .filter(function (q) {
            return gradedDescriptiveQuestions
              ?.map((q) => q.questionId)
              .includes(q.id);
          }).length && (
          <Box
            p={5}
            bg={colorMode == "dark" ? "gray.600" : "gray.100"}
            borderRadius={20}
          >
            <Heading>Descriptive Questions: </Heading>
            {descriptiveQuestions
              ?.map((q) => q)
              .filter(function (q) {
                return gradedDescriptiveQuestions
                  ?.map((q) => q.questionId)
                  .includes(q.id);
              })
              .map((descriptiveQuestion) => (
                <Card key={descriptiveQuestion.id} margin={5}>
                  <CardBody>
                    <Heading fontSize={24}>{descriptiveQuestion.title}</Heading>
                    <Text>{descriptiveQuestion.description}</Text>
                    {examStudentQuestions
                      ?.filter(function (examStudentQuestion) {
                        return gradedDescriptiveQuestions
                          ?.filter(function (gradedDescriptiveQuestion) {
                            return descriptiveQuestions
                              ?.map((q) => q.id)
                              .includes(descriptiveQuestion.id);
                          })
                          .map((q) => q.id)
                          .includes(examStudentQuestion.gradedQuestionId);
                      })
                      .map((que) => (
                        <Box key={que.id}>
                          <Text>Grade: </Text>
                          <Input
                            type="number"
                            required
                            defaultValue={que.grade}
                            onChange={(e) => {
                              if (e.target.value) {
                                Update(
                                  { id: que.id, grade: e.target.value },
                                  setError
                                );
                              }
                            }}
                          ></Input>
                        </Box>
                      ))}
                  </CardBody>
                </Card>
              ))}
          </Box>
        )}

        <Box
          p={5}
          bg={colorMode == "dark" ? "gray.600" : "gray.100"}
          borderRadius={20}
        >
          <Heading fontSize={22}>Sum: {gradeSum}</Heading>
        </Box>
      </List>
    </Container>
  );
};

export default ProfessorExamMarkPage;
