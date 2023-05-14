import GetAuthToken from "./Auth";
import authApiClient from "./AuthApiClient";
import { UserSignIn } from "./SignIn";

export interface UserSignUp{
    id: string,
    firstName:string,
    lastName:string,
    birthDate: Date,
    password: string,
    nationalCode: string,
    role: string
}

class UserServices {
    GetNameById(id: any , setName: any){
        authApiClient().post('/User/GetNameById' , {id})
        .then(res => setName(res.data))
    }

    SignUp(user: any )
    {
        return authApiClient().post('User/SignUp' , user)
    }
    Search(user: {firstName: string, lastName: string, role:string} , setSearchResults: any)
    {
        authApiClient().post('User/Search' , user).then(res => setSearchResults(res.data))
    }
}

export default UserServices