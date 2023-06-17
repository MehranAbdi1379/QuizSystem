import React, { useEffect, useState } from "react";
import MultipleChoiceQuestionService from "../../services/MultipleChoiceQuestionService";
import { Box, Radio, RadioGroup, Text, VStack } from "@chakra-ui/react";
import ExamStudentService from "../../services/ExamStudentService";

interface Props {
  questionId: string;
  answer: string;
  examStudentQuestionId: string;
  finished: boolean;
  setAnsweredQuestionUpdater: (number: number) => void;
  answeredQuestionUpdater: number;
}

const StudentMultipleChoiceQuestionAnswers = ({
  questionId,
  answer,
  examStudentQuestionId,
  finished,
  answeredQuestionUpdater: answerUpdater,
  setAnsweredQuestionUpdater: setAnswerUpdater,
}: Props) => {
  const { GetAnswerByQuestionId } = new MultipleChoiceQuestionService();
  const { UpdateQuestion } = new ExamStudentService();
  const [answers, setAnswers] =
    useState<{ title: string; rightAnswer: boolean }[]>();
  const [error, setError] = useState();
  const [setAnswer, setSetAnswer] = useState("");
  useEffect(() => {
    GetAnswerByQuestionId(questionId, setError).then((res) =>
      setAnswers(res.data)
    );
  }, []);
  return (
    <RadioGroup>
      {answers?.map((a) => (
        <Box key={a.title}>
          <Radio
            isDisabled={finished}
            onChange={() => {
              UpdateQuestion(examStudentQuestionId, a.title, setError);
              setSetAnswer(a.title);
              setAnswerUpdater(answerUpdater + 1);
            }}
            value={a.title}
          >
            {!finished && a.title == answer && (
              <Text color={"red.400"}>{a.title}</Text>
            )}
            {finished && a.title == answer && a.rightAnswer == false && (
              <Text color={"red.400"}>{a.title}</Text>
            )}
            {!finished && a.rightAnswer == true && a.title != answer && (
              <Text>{a.title}</Text>
            )}
            {a.rightAnswer == false && a.title != answer && (
              <Text>{a.title}</Text>
            )}
            {finished && a.rightAnswer && (
              <Text color={"green.400"}>{a.title}</Text>
            )}
          </Radio>
        </Box>
      ))}
    </RadioGroup>
  );
};

export default StudentMultipleChoiceQuestionAnswers;
