import GetAuthToken from "./Auth";
import authApiClient from "./AuthApiClient";

class UserServices {
    GetNameById(id: any , setName: any){
        authApiClient().post('/User/GetNameById' , id)
        .then(res => setName(res.data))
    }
}

export default UserServices