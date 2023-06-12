import React, { useEffect, useState } from "react";
import GradedQuestionService from "../../services/GradedQuestionService";
import { Form, useLocation } from "react-router-dom";
import MultipleChoiceQuestionService, {
  Answer,
} from "../../services/MultipleChoiceQuestionService";
import { Question } from "../../services/QuestionService";
import ExamStudentService from "../../services/ExamStudentService";
import {
  Box,
  Button,
  FormControl,
  HStack,
  Heading,
  Radio,
  RadioGroup,
  Text,
  Textarea,
} from "@chakra-ui/react";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";

const schema = z.object({
  answer: z.string().min(1),
});

type FormData = z.infer<typeof schema>;

const StudentExamMultipleChoiceQuestionPage = () => {
  const [error, setError] = useState();
  const state = useLocation().state;
  const [examStudentQuestion, setExamStudentQuestion] = useState<{
    id: string;
    answer: string;
  }>();
  const [finished, setFinished] = useState();
  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm<FormData>({ resolver: zodResolver(schema) });
  const [question, setQuestion] = useState<Question>();
  const { GetById, GetAnswerByQuestionId } =
    new MultipleChoiceQuestionService();
  const [answers, setAnswers] = useState<Answer[]>();
  const { GetQuestion, UpdateQuestion, Finished } = new ExamStudentService();

  useEffect(() => {
    GetById(state.questionId, setQuestion, setError);
    GetAnswerByQuestionId(state.questionId, setError).then((res) =>
      setAnswers(res.data)
    );
    GetQuestion(
      state.gradedQuestionId,
      state.examStudentId,
      setExamStudentQuestion,
      setError
    );
    Finished(state.examId, setFinished, setError);
  }, [state]);
  return (
    <Form
      onSubmit={handleSubmit((e) => {
        console.log(e);
        UpdateQuestion(examStudentQuestion?.id, e.answer, setError);
      })}
    >
      <Box>
        <Heading fontSize={22}>{question?.title}</Heading>
        <Text marginTop={4}>{question?.description}</Text>
        <FormControl marginTop={8}>
          <Box>
            {answers?.map((answer) => (
              <HStack key={answer.id}>
                <input
                  disabled={finished}
                  type="radio"
                  {...register("answer")}
                  value={answer.title}
                  defaultChecked={answer.title == examStudentQuestion?.answer}
                ></input>
                <Text>{answer.title}</Text>
              </HStack>
            ))}
          </Box>
        </FormControl>
        <Text>{errors.answer?.message}</Text>
        {examStudentQuestion?.answer != "" && (
          <Text marginTop={5} color="green.400">
            Submited
          </Text>
        )}
        {!finished && (
          <FormControl marginTop={5}>
            <Button type="submit">Submit</Button>
          </FormControl>
        )}
      </Box>
    </Form>
  );
};

export default StudentExamMultipleChoiceQuestionPage;
