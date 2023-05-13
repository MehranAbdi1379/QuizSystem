import {
  Route,
  RouterProvider,
  Routes,
  createBrowserRouter,
  createRoutesFromElements,
} from "react-router-dom";
import RootLayout from "./layouts/RootLayout";
import SignedInLayout from "./layouts/SignedInLayout";
import Navbar from "./components/Global/NavbarRoot";
import { useState } from "react";
import { Heading } from "@chakra-ui/react";
import AdminCoursePage from "./pages/Admin/AdminCoursePage";
import AboutPage from "./pages/Global/AboutPage";
import AdminAllCoursesPage from "./pages/Admin/AdminAllCoursesPage";
import AdminPage from "./pages/Admin/AdminPage";
import AdminProfessorsPage from "./pages/Admin/AdminProfessorsPage";
import AdminStudentsPage from "./pages/Admin/AdminStudentsPage";
import CourseCreatePage from "./pages/Admin/CourseCreatePage";
import NotFoundPage from "./pages/Global/NotFoundPage";
import SignInPage from "./pages/Global/SignInPage";
import SignUpPage from "./pages/Global/SignUpPage";
import WelcomePage from "./pages/Global/WelcomePage";
import AdminAllProfessorsPage from "./pages/Admin/AdminAllProfessorsPage";
import AdminAllStudentsPage from "./pages/Admin/AdminAllStudentsPage";
import AdminCourseEditPage from "./pages/Admin/AdminCourseEditPage";
import AdminSearchPage from "./pages/Admin/AdminSearchPage";
import ProfessorPage from "./pages/Professor/ProfessorPage";
import ProfessorCoursePage from "./pages/Professor/ProfessorCoursePage";
import ProfessorExamCreatePage from "./pages/Professor/ProfessorExamCreatePage";
import ProfessorExamPage from "./pages/Professor/ProfessorExamPage";
import ProfessorExamEditPage from "./pages/Professor/ProfessorExamEditPage";
import ProfessorAllCoursesPage from "./pages/Professor/ProfessorAllCoursesPage";
import ProfessorExamQuestionCreatePage from "./pages/Professor/ProfessorExamQuestionCreatePage";
import ProfessorExamQuestionAddFromBank from "./pages/Professor/ProfessorExamQuestionAddFromBank";
import ProfessorExamQuestionEditPage from "./pages/Professor/ProfessorExamQuestionEditPage";

const router = createBrowserRouter(
  createRoutesFromElements(
    <Route>
      <Route path="*" element={<NotFoundPage />}></Route>
      <Route path="/" element={<RootLayout />}>
        <Route path="about-us" element={<AboutPage />}></Route>
        <Route index element={<WelcomePage />}></Route>
        <Route path="sign-in-page" element={<SignInPage />}></Route>
        <Route path="sign-up" element={<SignUpPage />}></Route>
      </Route>
      {localStorage.getItem("token") && (
        <Route path="sign-in" element={<SignedInLayout />}>
          <Route path="about-us" element={<AboutPage />}></Route>
          <Route path="admin" element={<AdminPage />}>
            <Route path="search" element={<AdminSearchPage />}></Route>
            <Route path="course">
              <Route index element={<AdminCoursePage />}></Route>
              <Route path="edit" element={<AdminCourseEditPage />}></Route>
              <Route path="create" element={<CourseCreatePage />}></Route>
              <Route path="all" element={<AdminAllCoursesPage />}></Route>
            </Route>
            <Route path="professor">
              <Route index element={<AdminProfessorsPage />}></Route>
              <Route path="all" element={<AdminAllProfessorsPage />}></Route>
            </Route>
            <Route path="student">
              <Route index element={<AdminStudentsPage />}></Route>
              <Route path="all" element={<AdminAllStudentsPage />}></Route>
            </Route>
          </Route>

          <Route path="student" element={<AdminPage />}></Route>

          <Route path="professor" element={<ProfessorPage />}>
            <Route path="course">
              <Route index element={<ProfessorCoursePage />}></Route>
              <Route path="all" element={<ProfessorAllCoursesPage />}></Route>
              <Route path="create"></Route>
              <Route path="exam">
                <Route index element={<ProfessorExamPage />}></Route>
                <Route
                  path="create"
                  element={<ProfessorExamCreatePage />}
                ></Route>
                <Route path="edit">
                  <Route index element={<ProfessorExamEditPage />}></Route>
                  <Route
                    path="question/create"
                    element={<ProfessorExamQuestionCreatePage />}
                  ></Route>
                  <Route
                    path="question/bank"
                    element={<ProfessorExamQuestionAddFromBank />}
                  ></Route>
                  <Route
                    path="question/edit"
                    element={<ProfessorExamQuestionEditPage />}
                  ></Route>
                </Route>
              </Route>
            </Route>
          </Route>
        </Route>
      )}
    </Route>
  )
);

function App() {
  return <RouterProvider router={router}></RouterProvider>;
}

export default App;
