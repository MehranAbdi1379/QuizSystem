import { Box, Heading, List, ListItem, useStatStyles } from "@chakra-ui/react";
import React, { useEffect, useState } from "react";
import CourseService, { Course } from "../services/CourseService";
import { Link, NavLink } from "react-router-dom";

const AdminSidebar = () => {
  const [courses, setCourses] = useState<Course[]>();
  const { GetAllCourses } = new CourseService();
  useEffect(() => {
    GetAllCourses(setCourses);
  }, []);

  return (
    <Box minHeight={{ base: "200px", md: "100vh" }}>
      <Heading>Courses</Heading>
      <List>
        {courses?.map((course) => (
          <ListItem key={course.id}>
            <Link to={"course/" + course.id}>{course.title}</Link>
          </ListItem>
        ))}
      </List>
    </Box>
  );
};

export default AdminSidebar;
