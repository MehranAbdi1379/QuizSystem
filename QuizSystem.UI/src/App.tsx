import {
  Route,
  RouterProvider,
  Routes,
  createBrowserRouter,
  createRoutesFromElements,
} from "react-router-dom";
import RootLayout from "./layouts/RootLayout";
import WelcomePage from "./pages/WelcomePage";
import SignedInLayout from "./layouts/SignedInLayout";
import Navbar from "./components/NavbarRoot";
import SignInPage from "./pages/SignInPage";
import SignUpPage from "./pages/SignUpPage";
import { useState } from "react";
import AdminPage from "./pages/AdminPage";
import { Heading } from "@chakra-ui/react";
import NotFoundPage from "./pages/NotFoundPage";
import AdminCoursePage from "./pages/CoursePage";
import AboutPage from "./pages/AboutPage";
import AdminStudentsPage from "./pages/AdminStudentsPage";
import AdminProfessorsPage from "./pages/AdminProfessorsPage";

const router = createBrowserRouter(
  createRoutesFromElements(
    <Route>
      <Route path="about-us" element={<AboutPage />}></Route>
      <Route path="*" element={<NotFoundPage />}></Route>
      <Route path="/" element={<RootLayout />}>
        <Route index element={<WelcomePage />}></Route>
        <Route path="sign-in" element={<SignInPage />}></Route>
        <Route path="sign-up" element={<SignUpPage />}></Route>
      </Route>
      {localStorage.getItem("token") && (
        <Route path="sign-in/:id" element={<SignedInLayout />}>
          <Route path="admin" element={<AdminPage />}>
            <Route
              path="course/:courseId"
              element={<AdminCoursePage />}
            ></Route>
            <Route
              path="student/:studentId"
              element={<AdminStudentsPage />}
            ></Route>
            <Route
              path="professor/:professorId"
              element={<AdminProfessorsPage />}
            ></Route>
          </Route>
          <Route path="student" element={<AdminPage />}></Route>
          <Route path="professor" element={<AdminPage />}></Route>
        </Route>
      )}
    </Route>
  )
);

function App() {
  return <RouterProvider router={router}></RouterProvider>;
}

export default App;
