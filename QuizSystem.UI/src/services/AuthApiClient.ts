import axios from "axios"
import GetAuthToken from "./Auth";

const authApiClient = () => {
    return axios.create({baseURL:'https://localhost:7031/api' , headers: {Authorization: 'bearer ' + GetAuthToken()}})
}

export default authApiClient;