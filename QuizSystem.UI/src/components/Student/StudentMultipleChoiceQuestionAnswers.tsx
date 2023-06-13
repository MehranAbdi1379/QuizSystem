import React, { useEffect, useState } from "react";
import MultipleChoiceQuestionService from "../../services/MultipleChoiceQuestionService";
import { Box, Radio, RadioGroup, Text, VStack } from "@chakra-ui/react";
import ExamStudentService from "../../services/ExamStudentService";

interface Props {
  questionId: string;
  answer: string;
  examStudentQuestionId: string;
  finished: boolean;
}

const StudentMultipleChoiceQuestionAnswers = ({
  questionId,
  answer,
  examStudentQuestionId,
  finished,
}: Props) => {
  const { GetAnswerByQuestionId } = new MultipleChoiceQuestionService();
  const { UpdateQuestion } = new ExamStudentService();
  const [answers, setAnswers] = useState<{ title: string }[]>();
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
        <Box>
          <Radio
            isDisabled={!finished}
            onChange={() => {
              UpdateQuestion(examStudentQuestionId, a.title, setError);
              setSetAnswer(a.title);
            }}
            value={a.title}
          >
            {a.title == answer && <Text color={"red.400"}>{a.title}</Text>}
            {a.title != answer && <Text>{a.title}</Text>}
          </Radio>
        </Box>
      ))}
    </RadioGroup>
  );
};

export default StudentMultipleChoiceQuestionAnswers;
