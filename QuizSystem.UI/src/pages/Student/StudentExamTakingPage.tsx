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
  const [finished, setFinished] = useState(false);
  const { GetByExamAndStudentId, Finished } = new ExamStudentService();
  const [examStudent, setExamStudent] = useState<{
    id: string;
    startTime: Date;
    endTime: Date;
  }>();

  const [minutes, setMinutes] = useState<number>();
  const [second, setSeconds] = useState<number>();

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
    Finished(state.examId, setFinished, setError);
    GetByExamAndStudentId(state.examId, setExamStudent, setError);
    const secondTimer = setInterval(() => {
      if (!finished) {
        Finished(state.examId, setFinished, setError);
        const endtime = examStudent?.endTime.toString().slice(11, 19);
        const nowHours = new Date().getHours();
        const nowMinutes = new Date().getMinutes();
        const nowSeconds = new Date().getSeconds();
        setSeconds(
          (parseInt(endtime?.slice(0, 2) ? endtime?.slice(0, 2) : "") * 3600 +
            parseInt(endtime?.slice(3, 5) ? endtime?.slice(3, 5) : "") * 60 +
            parseInt(endtime?.slice(6, 8) ? endtime?.slice(6, 8) : "") -
            (nowHours * 3600 + nowMinutes * 60 + nowSeconds)) %
            60
        );
        setMinutes(
          (parseInt(endtime?.slice(0, 2) ? endtime?.slice(0, 2) : "") * 3600 +
            parseInt(endtime?.slice(3, 5) ? endtime?.slice(3, 5) : "") * 60 +
            parseInt(endtime?.slice(6, 8) ? endtime?.slice(6, 8) : "") -
            (nowHours * 3600 + nowMinutes * 60 + nowSeconds) -
            ((parseInt(endtime?.slice(0, 2) ? endtime?.slice(0, 2) : "") *
              3600 +
              parseInt(endtime?.slice(3, 5) ? endtime?.slice(3, 5) : "") * 60 +
              parseInt(endtime?.slice(6, 8) ? endtime?.slice(6, 8) : "") -
              (nowHours * 3600 + nowMinutes * 60 + nowSeconds)) %
              60)) /
            60
        );
      }
    }, 1000);
    return () => clearInterval(secondTimer);
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
              <HStack justify={"space-between"}>
                <Heading p={5} fontSize={22}>
                  Multiple choice questions:{" "}
                </Heading>
                {!finished && (
                  <Heading paddingRight={5} fontSize={20}>
                    Time left: {minutes} {second}
                  </Heading>
                )}
                {finished && (
                  <Heading
                    color={"red.400"}
                    alignSelf={"start"}
                    paddingRight={5}
                    fontSize={20}
                  >
                    Exam is finished
                  </Heading>
                )}
              </HStack>

              {multipleChoiceQuestions?.map((q) => (
                <Button
                  marginTop={3}
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
        </HStack>

        {descriptiveQuestions && (
          <Box>
            <Heading p={5} fontSize={22}>
              Descriptive questions:{" "}
            </Heading>
            {descriptiveQuestions?.map((q) => (
              <Button
                marginTop={3}
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
