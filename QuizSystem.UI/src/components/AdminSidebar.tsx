import { Box, Heading, List, ListItem, useStatStyles } from "@chakra-ui/react";
import React, { useState } from "react";
import CourseService from "../services/CourseService";
import { Link, NavLink } from "react-router-dom";

interface Course {
  id: string;
  timePeriod: {
    endDate: Date;
    startDate: Date;
  };
  title: string;
}

const AdminSidebar = () => {
  const [courses, setCourses] = useState<Course[]>();
  const { GetAllCourses } = new CourseService();
  GetAllCourses(setCourses);

  return (
    <Box minHeight={{ base: "200px", md: "100vh" }}>
      <Heading>Courses</Heading>
      <List>
        {courses?.map((course) => (
          <ListItem>
            <Link to={" edf"}>{course.title}</Link>
          </ListItem>
        ))}
      </List>
    </Box>
  );
};

export default AdminSidebar;
