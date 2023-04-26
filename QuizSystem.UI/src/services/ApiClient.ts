import axios from "axios";

const apiClient =  axios.create({baseURL : 'https://localhost:7031/api' })

export default apiClient;

