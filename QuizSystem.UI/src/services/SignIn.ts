import { useState } from "react"
import apiClient from "./ApiClient"

export interface user {
    nationalCode: string,
    password: string
}


const signIn = (user: user  ) => {
     return apiClient.post('/User/Sign-In' , user)
    .then(res => { localStorage.setItem('token' , res.data.token) 
    localStorage.setItem('role' , res.data.role) 
}
    )
}

export default signIn;