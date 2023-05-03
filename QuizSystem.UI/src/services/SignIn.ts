import { useState } from "react"
import apiClient from "./ApiClient"
import { redirect, useNavigate } from "react-router-dom";

export interface UserSignIn {
    nationalCode: string,
    password: string
}


const signIn = (user: UserSignIn , setUserRole: any , setError: any ) => {
     apiClient.post('/User/SignIn' , user).then((res) => {
        localStorage.setItem("token", res.data.token);
        localStorage.setItem("userId", res.data.userId);
        switch (res.data.role) {
          case "Admin":
            setUserRole("/sign-in/admin");
            break;
          case "Student":
            setUserRole("/sign-in/student");
            break;
          case "Professor":
            setUserRole("/sign-in/professor");
            break;
          default:
            break;
        }
      })
      .catch((err) => setError(err.response.data));
      }
    

export default signIn;