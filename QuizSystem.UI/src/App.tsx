import {
  Route,
  RouterProvider,
  createBrowserRouter,
  createRoutesFromElements,
} from "react-router-dom";
import RootLayout from "./layouts/RootLayout";
import WelcomePage from "./pages/WelcomePage";
import SignedInLayout from "./layouts/SignedInLayout";
import Navbar from "./components/NavbarRoot";
import SignInPage from "./pages/SignInPage";
import SignUpPage from "./pages/SignUpPage";

const router = createBrowserRouter(
  createRoutesFromElements(
    <Route>
      <Route path="/" element={<RootLayout />}>
        <Route index element={<WelcomePage />}></Route>
        <Route path="sign-in" element={<SignInPage />}></Route>
        <Route path="sign-up" element={<SignUpPage />}></Route>
      </Route>
      <Route path="/signed-in" element={<SignedInLayout />}>
        <Route index element={<Navbar />}></Route>
      </Route>
    </Route>
  )
);

function App() {
  return <RouterProvider router={router}></RouterProvider>;
}

export default App;
