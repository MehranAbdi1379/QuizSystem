import {
  Heading,
  SimpleGrid,
  Card,
  CardHeader,
  CardBody,
  CardFooter,
  HStack,
  Input,
  Text,
  Box,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { Question } from "../../services/QuestionService";
import GradedQuestionService from "../../services/GradedQuestionService";
import DescriptiveQuestionService from "../../services/DescriptiveQuestionService";
import ExamStudentService from "../../services/ExamStudentService";

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
  setGradeSumCounter: (value: any) => void;
  gradeSumCounter: number;
}

const ProfessorDescriptiveQuestionMark = ({
  state,
  setError,
  examStudentQuestions,
  setGradeSumCounter,
  gradeSumCounter,
}: Props) => {
  const [gradedDescriptiveQuestions, setGradedDescriptiveQuestions] =
    useState<
      { id: string; questionId: string; examId: string; grade: number }[]
    >();
  const [descriptiveQuestions, setDescriptiveQuestions] =
    useState<Question[]>();

  const { GetDescriptiveQuestionsOnly } = new GradedQuestionService();
  const { GetAllByExamId } = new DescriptiveQuestionService();
  const { UpdateQuestionGrade } = new ExamStudentService();

  var gradedDescriptiveQuestionsDisplay: {
    gradedQuestionId: string;
    title: string;
    description: string;
    answer: string;
    questionId: string;
    examStudentQuestionId: string;
    grade: number;
    maxGrade: number;
  }[] = [];

  descriptiveQuestions?.forEach((descriptiveQuestion) => {
    var newGradeDescriptiveQuestion: {
      gradedQuestionId: string;
      title: string;
      description: string;
      answer: string;
      questionId: string;
      examStudentQuestionId: string;
      grade: number;
      maxGrade: number;
    } = {
      gradedQuestionId: "",
      answer: "",
      title: "",
      description: "",
      questionId: "",
      examStudentQuestionId: "",
      grade: 0,
      maxGrade: 0,
    };
    gradedDescriptiveQuestions?.forEach((gradedDescriptiveQuestion) => {
      if (gradedDescriptiveQuestion.questionId == descriptiveQuestion.id) {
        newGradeDescriptiveQuestion.gradedQuestionId =
          gradedDescriptiveQuestion.id;
        newGradeDescriptiveQuestion.maxGrade = gradedDescriptiveQuestion.grade;
        examStudentQuestions?.forEach((examStudentQuestion) => {
          if (
            examStudentQuestion.gradedQuestionId == gradedDescriptiveQuestion.id
          ) {
            newGradeDescriptiveQuestion.answer = examStudentQuestion.answer;
            newGradeDescriptiveQuestion.examStudentQuestionId =
              examStudentQuestion.id;
            newGradeDescriptiveQuestion.grade = examStudentQuestion.grade;
          }
        });
      }
    });
    newGradeDescriptiveQuestion.description = descriptiveQuestion.description;
    newGradeDescriptiveQuestion.title = descriptiveQuestion.title;
    newGradeDescriptiveQuestion.questionId = descriptiveQuestion.id;

    gradedDescriptiveQuestionsDisplay.push(newGradeDescriptiveQuestion);
  });

  useEffect(() => {
    GetDescriptiveQuestionsOnly(
      state.examId,
      setGradedDescriptiveQuestions,
      setError
    );
    GetAllByExamId(state.examId, setDescriptiveQuestions, setError);
  }, [state]);
  return (
    <>
      <Heading>Descriptive Questions: </Heading>
      <SimpleGrid columns={2} minChildWidth={300}>
        {gradedDescriptiveQuestionsDisplay.map((q) => (
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
              <Box width={"100%"}>
                <Text>Max Grade: {q.maxGrade}</Text>
                <HStack marginTop={2}>
                  <Text>Grade: </Text>
                  <Input
                    type="number"
                    required
                    defaultValue={q.grade}
                    onChange={(e) => {
                      if (parseFloat(e.target.value) > q.maxGrade) {
                        alert("Grade can not be more than max grade.");
                        e.target.value = q.grade.toString();
                      } else if (parseFloat(e.target.value) < 0) {
                        alert("Grade can not be negative.");
                        e.target.value = q.grade.toString();
                      } else if (e.target.value) {
                        UpdateQuestionGrade(
                          q.examStudentQuestionId,
                          e.target.value,
                          setError
                        );
                        setGradeSumCounter(gradeSumCounter + 1);
                      }
                    }}
                  ></Input>
                </HStack>
              </Box>
            </CardFooter>
          </Card>
        ))}
      </SimpleGrid>
      ;
    </>
  );
};

export default ProfessorDescriptiveQuestionMark;
