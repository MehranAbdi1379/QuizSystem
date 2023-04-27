import axios from "axios"

const authApiClient = (jwtToken: string) => {
    return axios.create({baseURL:'https://localhost:7031/api' , headers: {Authorization: 'bearer ' + jwtToken}})
}

export default authApiClient;