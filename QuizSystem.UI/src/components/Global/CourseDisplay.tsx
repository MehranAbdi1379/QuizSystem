import React, { useEffect, useState } from "react";
import { Text } from "@chakra-ui/react";
import CourseService, { Course } from "../../services/CourseService";

interface Props {
  id: string;
}

const CourseDisplay = ({ id }: Props) => {
  const { GetById } = new CourseService();
  const [course, setCourse] = useState<Course>();
  useEffect(() => {
    GetById(id, setCourse);
  }, []);
  return <Text>{course?.title}</Text>;
};

export default CourseDisplay;
