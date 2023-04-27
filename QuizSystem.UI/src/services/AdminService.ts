import GetAuthToken from "./Auth";
import authApiClient from "./AuthApiClient";

class AdminService{
    GetAdminById(id : any , setAdmin: any){
        authApiClient().post('/User/Admin/GetById' , id).then(res => setAdmin(res.data))
    }
}

export default AdminService