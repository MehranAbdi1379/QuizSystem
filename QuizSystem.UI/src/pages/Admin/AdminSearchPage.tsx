import {
  Box,
  Button,
  Container,
  FormControl,
  FormLabel,
  GridItem,
  Heading,
  Input,
  List,
  Radio,
  RadioGroup,
  SimpleGrid,
  Text,
  useColorMode,
} from "@chakra-ui/react";
import React, { useState } from "react";
import { useForm } from "react-hook-form";
import { Form, Link } from "react-router-dom";
import UserServices from "../../services/UserServices";
import UserDisplay from "../../components/Global/UserDisplay";

interface FieldData {
  firstName: string;
  lastName: string;
  role: string;
  minBirthDate: Date;
  maxBirthDate: Date;
}

const AdminSearchPage = () => {
  const minDate = new Date();
  minDate.setFullYear(minDate.getFullYear() - 100);
  const { colorMode } = useColorMode();
  const { handleSubmit, register } = useForm<FieldData>();
  const [searchRole, setSearchRole] = useState<string>();
  const [searchResults, setSearchResults] =
    useState<{ id: string; role: string }[]>();
  const { Search } = new UserServices();
  console.log(searchResults);
  function handleSearch(data: FieldData) {
    if (!data.minBirthDate) data.minBirthDate = minDate;
    if (!data.maxBirthDate) data.maxBirthDate = new Date();
    Search(data, setSearchResults);
    setSearchRole(data.role);
  }
  return (
    <Box>
      <Form onSubmit={handleSubmit((data) => handleSearch(data))}>
        <Container
          marginTop={5}
          bg={colorMode == "dark" ? "gray.700" : "gray.50"}
          padding="35px"
          borderRadius={50}
        >
          <List spacing={5}>
            <FormControl>
              <FormLabel>FirstName: </FormLabel>
              <Input {...register("firstName")} type="text"></Input>
            </FormControl>

            <FormControl>
              <FormLabel>LastName: </FormLabel>
              <Input {...register("lastName")} type="text"></Input>
            </FormControl>

            <FormControl>
              <FormLabel>Minimum Birth Date: </FormLabel>
              <Input {...register("minBirthDate")} type="date"></Input>
            </FormControl>

            <FormControl>
              <FormLabel>Maximum Birth Date: </FormLabel>
              <Input {...register("maxBirthDate")} type="date"></Input>
            </FormControl>

            <FormControl>
              <RadioGroup>
                <Radio {...register("role")} value="student">
                  Student
                </Radio>
                <Radio {...register("role")} value="professor">
                  Professor
                </Radio>
                <Radio {...register("role")} value="">
                  All
                </Radio>
              </RadioGroup>
            </FormControl>

            <FormControl>
              <Button type="submit">Submit</Button>
            </FormControl>
          </List>
        </Container>
      </Form>
      {searchResults && searchResults.length == 0 && (
        <Text>Sorry. There is no match.</Text>
      )}
      {searchResults && searchResults.length > 0 && searchRole == "" && (
        <SimpleGrid p={10} spacing={20} columns={2} minChildWidth={500}>
          <GridItem
            borderRadius={40}
            bg={colorMode == "dark" ? "gray.700" : "gray.50"}
          >
            <Heading paddingTop={5} paddingLeft={7}>
              Students
            </Heading>
            <SimpleGrid p={7} spacing={3} columns={3} minChildWidth={180}>
              {searchResults
                ?.filter((x) => x.role == "Student")
                .map((student) => (
                  <GridItem>
                    <Link
                      to={"/sign-in/admin/student"}
                      state={{ studentId: student.id }}
                    >
                      <Button
                        bg={colorMode == "dark" ? "gray.600" : "gray.200"}
                      >
                        <UserDisplay id={student.id}></UserDisplay>
                      </Button>
                    </Link>
                  </GridItem>
                ))}
            </SimpleGrid>
          </GridItem>
          <GridItem
            borderRadius={40}
            bg={colorMode == "dark" ? "gray.700" : "gray.50"}
          >
            <Heading paddingTop={5} paddingLeft={7}>
              Professors
            </Heading>
            <SimpleGrid p={7} spacing={3} columns={3} minChildWidth={180}>
              {searchResults
                ?.filter((x) => x.role == "Professor")
                .map((professor) => (
                  <GridItem>
                    <Link
                      to={"/sign-in/admin/professor"}
                      state={{ professorId: professor.id }}
                    >
                      <Button
                        bg={colorMode == "dark" ? "gray.600" : "gray.200"}
                      >
                        <UserDisplay id={professor.id}></UserDisplay>
                      </Button>
                    </Link>
                  </GridItem>
                ))}
            </SimpleGrid>
          </GridItem>
        </SimpleGrid>
      )}
      {searchResults && searchResults.length > 0 && searchRole == "student" && (
        <Container
          borderRadius={40}
          marginTop={10}
          bg={colorMode == "dark" ? "gray.700" : "gray.50"}
        >
          <Heading paddingTop={5} paddingLeft={7}>
            Result
          </Heading>
          <SimpleGrid p={7} spacing={3} columns={3} minChildWidth={180}>
            {searchResults
              ?.filter((x) => x.role == "Student")
              .map((student) => (
                <GridItem>
                  <Link
                    to={"/sign-in/admin/student"}
                    state={{ studentId: student.id }}
                  >
                    <Button bg={colorMode == "dark" ? "gray.600" : "gray.200"}>
                      <UserDisplay id={student.id}></UserDisplay>
                    </Button>
                  </Link>
                </GridItem>
              ))}
          </SimpleGrid>
        </Container>
      )}
      {searchResults &&
        searchResults.length > 0 &&
        searchRole == "professor" && (
          <Container
            borderRadius={40}
            marginTop={10}
            bg={colorMode == "dark" ? "gray.700" : "gray.50"}
          >
            <Heading paddingTop={5} paddingLeft={7}>
              Result
            </Heading>
            <SimpleGrid p={7} spacing={3} columns={3} minChildWidth={180}>
              {searchResults
                ?.filter((x) => x.role == "Professor")
                .map((professor) => (
                  <GridItem>
                    <Link
                      to={"/sign-in/admin/professor"}
                      state={{ professorId: professor.id }}
                    >
                      <Button
                        bg={colorMode == "dark" ? "gray.600" : "gray.200"}
                      >
                        <UserDisplay id={professor.id}></UserDisplay>
                      </Button>
                    </Link>
                  </GridItem>
                ))}
            </SimpleGrid>
          </Container>
        )}
    </Box>
  );
};

export default AdminSearchPage;
