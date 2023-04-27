import { useState } from "react"
import apiClient from "./ApiClient"
import { redirect, useNavigate } from "react-router-dom";

export interface user {
    nationalCode: string,
    password: string
}


const signIn = (user: user  ) => {
     return apiClient.post('/User/Sign-In' , user)
    
      }
    

export default signIn;