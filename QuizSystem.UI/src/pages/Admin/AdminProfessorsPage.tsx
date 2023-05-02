import React, { useEffect, useState } from "react";
import { Link, useLocation, useParams } from "react-router-dom";
import {
  Box,
  Button,
  Container,
  Heading,
  Text,
  VStack,
  useColorMode,
} from "@chakra-ui/react";
import ProfessorService, { Professor } from "../../services/ProfessorService";
import CourseService, { Course } from "../../services/CourseService";

const AdminProfessorsPage = () => {
  const { colorMode } = useColorMode();
  const state = useLocation().state;
  const { GetById, Accept, Unaccept } = new ProfessorService();
  const [professor, setProfessor] = useState<Professor>();
  const { GetAll } = new CourseService();
  const [courses, setCourses] = useState<Course[]>();

  useEffect(() => {
    GetById(state.professorId, setProfessor);
    GetAll(setCourses);
  }, [state]);

  return (
    <Container>
      <Box
        bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        p={10}
        borderRadius={50}
      >
        <Heading>
          {professor && (
            <Text>{professor.firstName + " " + professor.lastName}</Text>
          )}
        </Heading>

        <Heading marginTop={5} fontSize={22}>
          Birth Date:
        </Heading>
        {professor && (
          <Heading fontSize={20}>
            <Text>{professor.birthDate.toString().slice(0, 10)}</Text>
          </Heading>
        )}

        <Heading marginTop={5} fontSize={22}>
          National Code:
        </Heading>
        {professor && (
          <Heading fontSize={20}>
            <Text>{professor.nationalCode}</Text>
          </Heading>
        )}
        <Heading marginTop={5} marginBottom={2} fontSize={22}>
          Courses
        </Heading>
        <VStack marginBottom={5} align={"startZ"}>
          {courses
            ?.map((x) => x)
            .filter(function (x) {
              return professor?.id.includes(x.professorId);
            })
            .map((course) => (
              <Link to="/sign-in/admin/course" state={{ courseId: course.id }}>
                <Button variant={"ghost"}>{course.title}</Button>
              </Link>
            ))}
        </VStack>
        {professor?.accepted && (
          <Button
            onClick={() => {
              Unaccept;
              setProfessor({ ...professor, accepted: false });
            }}
          >
            Unaccept
          </Button>
        )}
        {professor?.accepted == false && (
          <Button
            onClick={() => {
              Accept;
              setProfessor({ ...professor, accepted: true });
            }}
          >
            Accept
          </Button>
        )}
      </Box>
    </Container>
  );
};

export default AdminProfessorsPage;
