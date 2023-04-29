import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import CourseService, { Course } from "../services/CourseService";
import { Text } from "@chakra-ui/react";

const AdminCoursePage = () => {
  const [course, setCourse] = useState<Course>();
  const params = useParams();
  console.log(course);
  const { GetWithId, GetStudentsWithCourseId } = new CourseService();
  useEffect(() => {
    GetWithId(params, setCourse);
    GetStudentsWithCourseId(params, course, setCourse);
  }, []);

  return (
    <div>
      {course && (
        <Text>
          {course.title} {course.id}
        </Text>
      )}
    </div>
  );
};

export default AdminCoursePage;
