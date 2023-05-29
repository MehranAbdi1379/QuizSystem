import {
  Box,
  Button,
  Container,
  HStack,
  Heading,
  Spacer,
  Text,
  useColorMode,
  useStatStyles,
} from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import { Outlet, useLocation, useNavigate } from "react-router-dom";
import GradedQuestionService from "../../services/GradedQuestionService";
import MultipleChoiceQuestionService from "../../services/MultipleChoiceQuestionService";
import DescriptiveQuestionService from "../../services/DescriptiveQuestionService";
import ExamStudentService from "../../services/ExamStudentService";

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
  const [activeQuestionId, setActiveQuestionId] = useState("");
  const { GetByExamAndStudentId, Create } = new ExamStudentService();
  const [examStudentQuestion, setExamStudentQuestion] = useState();
  const [examStudent, setExamStudent] = useState<{
    id: string;
    startTime: string;
    endTime: string;
  }>();
  const navigate = useNavigate();
  useEffect(() => {
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
    GetByExamAndStudentId(state.examId, setExamStudent, setError);
  }, [state]);
  return (
    <Container maxWidth={"70%"}>
      <Box
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        p={5}
        borderRadius={50}
      >
        <HStack>
          {multipleChoiceQuestions && (
            <Box>
              <Heading p={5} fontSize={22}>
                Multiple choice questions:{" "}
              </Heading>
              {multipleChoiceQuestions?.map((q) => (
                <Button
                  key={q.id}
                  colorScheme={activeQuestionId == q.id ? "whatsapp" : "gray"}
                  marginLeft={2}
                  onClick={() => {
                    setActiveQuestionId(q.id);
                    navigate("multiple-choice-question", {
                      state: {
                        examStudentId: examStudent?.id,
                        gradedQuestionId: q.id,
                        questionId: q.questionId,
                        examId: state.examId,
                      },
                    });
                  }}
                >
                  {multipleChoiceQuestions.indexOf(q) + 1}
                </Button>
              ))}
            </Box>
          )}
          <Spacer></Spacer>
          <Heading alignSelf={"start"} paddingRight={5} fontSize={20}>
            Time left: not set
          </Heading>
        </HStack>

        {descriptiveQuestions && (
          <Box>
            <Heading p={5} fontSize={22}>
              Descriptive questions:{" "}
            </Heading>
            {descriptiveQuestions?.map((q) => (
              <Button
                key={q.id}
                colorScheme={activeQuestionId == q.id ? "whatsapp" : "gray"}
                marginLeft={2}
                onClick={() => {
                  setActiveQuestionId(q.id);

                  navigate("descriptive-question", {
                    state: {
                      examStudentId: examStudent?.id,
                      gradedQuestionId: q.id,
                      questionId: q.questionId,
                      examId: state.examId,
                    },
                  });
                }}
              >
                {descriptiveQuestions.indexOf(q) + 1}
              </Button>
            ))}
          </Box>
        )}
      </Box>

      <Box
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        marginTop={5}
        p={10}
        borderRadius={50}
      >
        <Outlet></Outlet>
      </Box>
    </Container>
  );
};

export default StudentExamTakingPage;
