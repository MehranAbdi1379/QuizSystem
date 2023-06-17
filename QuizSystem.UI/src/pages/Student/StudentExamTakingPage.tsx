import {
  Box,
  Button,
  Container,
  HStack,
  Heading,
  Spacer,
  Tab,
  TabList,
  TabPanel,
  TabPanels,
  Tabs,
  Text,
  Textarea,
  VStack,
  useColorMode,
  useStatStyles,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { Outlet, useLocation, useNavigate } from "react-router-dom";
import GradedQuestionService from "../../services/GradedQuestionService";
import ExamStudentService from "../../services/ExamStudentService";
import StudentMultipleChoiceQuestionAnswers from "../../components/Student/StudentMultipleChoiceQuestionAnswers";
import DescriptiveQuestionService from "../../services/DescriptiveQuestionService";
import MultipleChoiceQuestionService from "../../services/MultipleChoiceQuestionService";
import { Question } from "../../services/QuestionService";
import StudentExamTimeCounter from "../../components/Student/StudentExamTimeCounter";

const StudentExamTakingPage = () => {
  const { colorMode } = useColorMode();
  const [descriptiveQuestions, setDescriptiveQuestions] =
    useState<{ grade: number; questionId: string; id: string }[]>();
  const [multipleChoiceQuestions, setMutltipleChoiceQuestions] =
    useState<{ grade: number; questionId: string; id: string }[]>();
  const { GetDescriptiveQuestionsOnly, GetMultipleChoiceQuestionsOnly } =
    new GradedQuestionService();
  const [error, setError] = useState();
  const state = useLocation().state;
  const [finished, setFinished] = useState(false);
  const {
    GetByExamAndStudentId,
    Finished,
    GetAllQuestionsByExamAndStudentId,
    UpdateQuestion,
  } = new ExamStudentService();
  const { GetById: GetDescriptiveQuestionById } =
    new DescriptiveQuestionService();
  const { GetById: GetMultipleChoiceQuestionById } =
    new MultipleChoiceQuestionService();
  const [examStudent, setExamStudent] = useState<{
    id: string;
    startTime: Date;
    endTime: Date;
  }>();
  const [examStudentQuestions, setExamStudentQuestions] =
    useState<
      { answer: string; gradedQuestionId: string; id: string; grade: number }[]
    >();

  const [selectedQuestion, setSelectedQuestion] = useState<Question>();

  var multipleChoiceQuestionsWithAnswers: {
    grade: number;
    id: string;
    questionId: string;
    answer: string;
    examStudentQuestionId: string;
    studentGrade: number;
  }[] = [];

  multipleChoiceQuestions?.forEach((element) => {
    var multipleChoiceQuestionWithAnswer = {
      ...element,
      answer: "",
      examStudentQuestionId: "",
      studentGrade: 0,
    };

    examStudentQuestions?.forEach((examStudentQuestion) => {
      if (examStudentQuestion.gradedQuestionId == element.id) {
        multipleChoiceQuestionWithAnswer.answer = examStudentQuestion.answer;
        multipleChoiceQuestionWithAnswer.examStudentQuestionId =
          examStudentQuestion.id;
        multipleChoiceQuestionWithAnswer.studentGrade =
          examStudentQuestion.grade;
      }
    });
    multipleChoiceQuestionsWithAnswers.push(multipleChoiceQuestionWithAnswer);
  });

  var descriptiveQuestionsWithAnswers: {
    grade: number;
    id: string;
    questionId: string;
    answer: string;
    examStudentQuestionId: string;
    studentGrade: number;
  }[] = [];

  descriptiveQuestions?.forEach((element) => {
    var descriptiveQuestionWithAnswer = {
      ...element,
      answer: "",
      examStudentQuestionId: "",
      studentGrade: 0,
    };

    examStudentQuestions?.forEach((examStudentQuestion) => {
      if (examStudentQuestion.gradedQuestionId == element.id) {
        descriptiveQuestionWithAnswer.answer = examStudentQuestion.answer;
        descriptiveQuestionWithAnswer.examStudentQuestionId =
          examStudentQuestion.id;
        descriptiveQuestionWithAnswer.studentGrade = examStudentQuestion.grade;
      }
    });
    descriptiveQuestionsWithAnswers.push(descriptiveQuestionWithAnswer);
  });

  var gradeSum: number = 0;
  examStudentQuestions?.forEach((examStudentQuestion) => {
    gradeSum += examStudentQuestion.grade;
  });

  const [answeredQuestionUpdater, setAnsweredQuestionUpdater] = useState(0);

  useEffect(() => {
    GetAllQuestionsByExamAndStudentId(
      state.examId,
      localStorage.getItem("userId"),
      setExamStudentQuestions,
      setError
    );
    GetDescriptiveQuestionsOnly(
      state.examId,
      setDescriptiveQuestions,
      setError
    );
    GetMultipleChoiceQuestionsOnly(
      state.examId,
      setMutltipleChoiceQuestions,
      setError
    );
    Finished(state.examId, setFinished, setError);

    GetByExamAndStudentId(state.examId, setExamStudent, setError);
  }, [state, answeredQuestionUpdater]);
  return (
    <Container
      minWidth={"70%"}
      bg={colorMode == "dark" ? "gray.700" : "gray.50"}
      p={5}
      borderRadius={50}
    >
      <Tabs>
        <HStack justifyContent={"space-between"}>
          <Heading>Questions: </Heading>

          <VStack>
            {examStudent?.endTime && (
              <StudentExamTimeCounter
                examId={state.examId}
                endTime={examStudent.endTime}
              />
            )}
            {finished && gradeSum != 0 && <Text>Exam grade: {gradeSum}</Text>}
          </VStack>
        </HStack>

        <Text marginTop={5} alignSelf={"center"} fontSize={20}>
          Multiple choice:{" "}
        </Text>
        <TabList>
          {multipleChoiceQuestionsWithAnswers.map((q) => (
            <Tab
              color={q.answer != "" ? "green.400" : ""}
              key={q.id}
              onClick={() =>
                GetMultipleChoiceQuestionById(
                  q.questionId,
                  setSelectedQuestion,
                  setError
                )
              }
            >
              {multipleChoiceQuestionsWithAnswers.indexOf(q) + 1}
            </Tab>
          ))}
        </TabList>
        <Text marginTop={5} alignSelf={"center"} fontSize={20}>
          Descriptive:{" "}
        </Text>
        <TabList>
          {descriptiveQuestionsWithAnswers.map((q) => (
            <Tab
              color={q.answer != "" ? "green.400" : ""}
              key={q.id}
              onClick={() =>
                GetDescriptiveQuestionById(
                  q.questionId,
                  setSelectedQuestion,
                  setError
                )
              }
            >
              {descriptiveQuestionsWithAnswers.indexOf(q) + 1}
            </Tab>
          ))}
        </TabList>

        <TabPanels marginTop={5}>
          {multipleChoiceQuestionsWithAnswers.map((q) => (
            <TabPanel key={q.id}>
              <Heading fontSize={22}>{selectedQuestion?.title}</Heading>
              <Text marginBottom={4} fontSize={18}>
                {selectedQuestion?.description}
              </Text>
              <StudentMultipleChoiceQuestionAnswers
                answeredQuestionUpdater={answeredQuestionUpdater}
                setAnsweredQuestionUpdater={setAnsweredQuestionUpdater}
                finished={finished}
                examStudentQuestionId={q.examStudentQuestionId}
                answer={q.answer}
                questionId={q.questionId}
              ></StudentMultipleChoiceQuestionAnswers>
              <Text marginTop={5}>Question grade: {q.grade}</Text>
              {finished && <Text>Your Grade: {q.studentGrade}</Text>}
            </TabPanel>
          ))}

          {descriptiveQuestionsWithAnswers.map((q) => (
            <TabPanel key={q.id}>
              <Heading fontSize={22}>{selectedQuestion?.title}</Heading>
              <Text marginBottom={4} fontSize={18}>
                {selectedQuestion?.description}
              </Text>
              <Textarea
                disabled={finished}
                onChange={(e) => {
                  UpdateQuestion(
                    q.examStudentQuestionId,
                    e.target.value,
                    setError
                  );
                  if (q.answer == "" || e.target.value == "") {
                    setAnsweredQuestionUpdater(answeredQuestionUpdater + 1);
                  }
                }}
                defaultValue={q.answer}
              ></Textarea>
              <Text marginTop={5}>Question grade: {q.grade}</Text>
              {finished && <Text>Your Grade: {q.studentGrade}</Text>}
            </TabPanel>
          ))}
        </TabPanels>
      </Tabs>
    </Container>
  );
};

export default StudentExamTakingPage;
