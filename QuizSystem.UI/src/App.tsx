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
            <Route path="courses">
              <Route path="create" element={<CourseCreatePage />}></Route>
              <Route path="all" element={<AdminAllCoursesPage />}></Route>
            </Route>
            <Route path="professors">
              <Route path="all" element={<AdminAllProfessorsPage />}></Route>
            </Route>
            <Route path="students">
              <Route path="all" element={<AdminAllStudentsPage />}></Route>
            </Route>
            <Route path="course">
              <Route index element={<AdminCoursePage />}></Route>
              <Route path="edit" element={<AdminCourseEditPage />}></Route>
            </Route>
            <Route path="student" element={<AdminStudentsPage />}></Route>
            <Route path="professor" element={<AdminProfessorsPage />}></Route>
          </Route>
          <Route path="student" element={<AdminPage />}></Route>
          <Route path="professor" element={<ProfessorPage />}></Route>
        </Route>
      )}
    </Route>
  )
);

function App() {
  return <RouterProvider router={router}></RouterProvider>;
}

export default App;
