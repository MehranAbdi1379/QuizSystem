import GetAuthToken from "./Auth";
import authApiClient from "./AuthApiClient";
import { UserSignIn } from "./SignIn";

export interface UserSignUp{
    firstName:string,
    lastName:string,
    birthDate: Date,
    password: string,
    nationalCode: string,
    role: string
}

class UserServices {
    GetNameById(id: any , setName: any){
        authApiClient().post('/User/GetNameById' , id)
        .then(res => setName(res.data))
    }

    SignUp(user: UserSignUp , setUser: any)
    {
        authApiClient().post('User/Sign-Up' , user)
        .then(res => setUser(user))
    }
}

export default UserServices