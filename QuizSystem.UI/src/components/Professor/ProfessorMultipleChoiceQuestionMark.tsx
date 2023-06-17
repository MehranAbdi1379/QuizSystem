import {
  Box,
  Card,
  CardBody,
  CardFooter,
  CardHeader,
  GridItem,
  Heading,
  SimpleGrid,
  Text,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { Question } from "../../services/QuestionService";
import GradedQuestionService from "../../services/GradedQuestionService";
import MultipleChoiceQuestionService from "../../services/MultipleChoiceQuestionService";

interface Props {
  state: any;
  setError: (value: any) => void;
  examStudentQuestions:
    | {
        id: string;
        examStudentId: string;
        gradedQuestionId: string;
        grade: number;
        answer: string;
      }[]
    | undefined;
}

const ProfessorMultipleChoiceQuestionMark = ({
  state,
  setError,
  examStudentQuestions,
}: Props) => {
  const [GradedMultipleChoiceQuestions, setGradedMultipleChoiceQuestions] =
    useState<
      { id: string; questionId: string; examId: string; grade: number }[]
    >();
  const [multipleChoiceQuestions, setMultipleChoiceQuestions] =
    useState<Question[]>();

  const { GetAllByExamId } = new MultipleChoiceQuestionService();

  const { GetMultipleChoiceQuestionsOnly } = new GradedQuestionService();
  var gradedMultipleChoiceQuestionsDisplay: {
    gradedQuestionId: string;
    title: string;
    description: string;
    answer: string;
    questionId: string;
    examStudentQuestionId: string;
    grade: number;
  }[] = [];

  multipleChoiceQuestions?.forEach((multipleChoiceQuestion) => {
    var newGradedMultipleChoiceQuestion: {
      gradedQuestionId: string;
      title: string;
      description: string;
      answer: string;
      questionId: string;
      examStudentQuestionId: string;
      grade: number;
    } = {
      gradedQuestionId: "",
      answer: "",
      title: "",
      description: "",
      questionId: "",
      examStudentQuestionId: "",
      grade: 0,
    };
    GradedMultipleChoiceQuestions?.forEach((gradedMultipleChoiceQuestion) => {
      if (
        gradedMultipleChoiceQuestion.questionId == multipleChoiceQuestion.id
      ) {
        newGradedMultipleChoiceQuestion.gradedQuestionId =
          gradedMultipleChoiceQuestion.id;
        examStudentQuestions?.forEach((examStudentQuestion) => {
          if (
            examStudentQuestion.gradedQuestionId ==
            gradedMultipleChoiceQuestion.id
          ) {
            newGradedMultipleChoiceQuestion.answer = examStudentQuestion.answer;
            newGradedMultipleChoiceQuestion.examStudentQuestionId =
              examStudentQuestion.id;
            newGradedMultipleChoiceQuestion.grade = examStudentQuestion.grade;
          }
        });
      }
    });
    newGradedMultipleChoiceQuestion.description =
      multipleChoiceQuestion.description;
    newGradedMultipleChoiceQuestion.title = multipleChoiceQuestion.title;
    newGradedMultipleChoiceQuestion.questionId = multipleChoiceQuestion.id;

    gradedMultipleChoiceQuestionsDisplay.push(newGradedMultipleChoiceQuestion);
  });

  useEffect(() => {
    GetMultipleChoiceQuestionsOnly(
      state.examId,
      setGradedMultipleChoiceQuestions,
      setError
    );
    GetAllByExamId(state.examId, setMultipleChoiceQuestions, setError);
  }, [state]);
  return (
    <>
      <Heading>Multiple Choice Questions: </Heading>

      <SimpleGrid columns={2} minChildWidth={300}>
        {gradedMultipleChoiceQuestionsDisplay.map((q) => (
          <GridItem>
            <Card
              key={q.questionId}
              marginTop={5}
              marginRight={5}
              marginBottom={5}
            >
              <CardHeader>
                <Heading fontSize={24}>{q.title}</Heading>
                <Text>{q.description}</Text>
              </CardHeader>
              <CardBody>
                <Box>
                  <Text>Answer: </Text>
                  <Text>{q.answer}</Text>
                </Box>
              </CardBody>
              <CardFooter>
                <Box>
                  <Text>Grade: {q.grade}</Text>
                </Box>
              </CardFooter>
            </Card>
          </GridItem>
        ))}
      </SimpleGrid>
    </>
  );
};

export default ProfessorMultipleChoiceQuestionMark;
