import axios from "axios"

const authApiClient = (jwtToken: string) => {
    return axios.create({baseURL:'https://localhost:7031/api' , headers: {Authorization: 'Bearer ' + jwtToken}})
}

export default authApiClient;