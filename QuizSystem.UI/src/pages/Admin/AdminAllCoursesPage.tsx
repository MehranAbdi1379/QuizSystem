import { Box, Heading, useColorMode } from "@chakra-ui/react";
import { useEffect, useState } from "react";
import CourseService, { Course } from "../../services/CourseService";
import AllCourses from "../../components/Global/AllCourses";

const AdminAllCoursesPage = () => {
  const { GetAll } = new CourseService();
  const [courses, setCourses] = useState<Course[]>();
  const { colorMode } = useColorMode();

  useEffect(() => {
    GetAll(setCourses);
  }, []);
  return (
    <Box paddingLeft={10} paddingTop={5} paddingRight={10}>
      <Heading paddingBottom={4}>Courses</Heading>

      {courses && (
        <AllCourses colorMode={colorMode} courses={courses}></AllCourses>
      )}
    </Box>
  );
};

export default AdminAllCoursesPage;
