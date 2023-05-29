import React, { useEffect, useState } from "react";
import GradedQuestionService from "../../services/GradedQuestionService";
import { Form, useFormAction, useLocation } from "react-router-dom";
import { Question } from "../../services/QuestionService";
import DescriptiveQuestionService from "../../services/DescriptiveQuestionService";
import ExamStudentService from "../../services/ExamStudentService";
import {
  Box,
  Button,
  FormControl,
  Heading,
  Input,
  Text,
  Textarea,
} from "@chakra-ui/react";
import { z } from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";

const schema = z.object({
  answer: z.string(),
});

type FormData = z.infer<typeof schema>;
const StudentExamDescriptiveQuestionPage = () => {
  const [error, setError] = useState();
  const state = useLocation().state;
  const [examStudentQuestion, setExamStudentQuestion] = useState<{
    id: string;
    answer: string;
  }>();
  const {
    register,
    formState: { errors },
    handleSubmit,
  } = useForm<FormData>({ resolver: zodResolver(schema) });
  const [question, setQuestion] = useState<Question>();
  const { GetById } = new DescriptiveQuestionService();
  const { GetQuestion, UpdateQuestion } = new ExamStudentService();

  useEffect(() => {
    GetById(state.questionId, setQuestion, setError);
    GetQuestion(
      state.gradedQuestionId,
      state.examStudentId,
      setExamStudentQuestion,
      setError
    );
  }, [state]);
  return (
    <Form
      onSubmit={handleSubmit((e) => {
        UpdateQuestion(examStudentQuestion?.id, e.answer, setError);
      })}
    >
      <Box>
        <Heading fontSize={22}>{question?.title}</Heading>
        <Text marginTop={4}>{question?.description}</Text>

        <FormControl marginTop={8}>
          <Textarea
            {...register("answer")}
            defaultValue={examStudentQuestion?.answer}
          ></Textarea>
        </FormControl>
        <Text marginTop={2} color={"red.400"}>
          {errors.answer?.message}
        </Text>
        <FormControl marginTop={5}>
          <Button type="submit">Submit</Button>
        </FormControl>
      </Box>
    </Form>
  );
};

export default StudentExamDescriptiveQuestionPage;
