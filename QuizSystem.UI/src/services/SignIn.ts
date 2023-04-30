import { useState } from "react"
import apiClient from "./ApiClient"
import { redirect, useNavigate } from "react-router-dom";

export interface UserSignIn {
    nationalCode: string,
    password: string
}


const signIn = (user: UserSignIn  ) => {
     return apiClient.post('/User/SignIn' , user)
    
      }
    

export default signIn;