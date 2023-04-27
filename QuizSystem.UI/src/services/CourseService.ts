import GetAuthToken from "./Auth";
import authApiClient from "./AuthApiClient";

class CourseService{
    GetAllCourses(setCourses: any)
    {
        authApiClient().get('Course/Get-All-Courses').then(res => setCourses(res.data))
    }
}

export default CourseService