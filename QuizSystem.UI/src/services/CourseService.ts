import GetAuthToken from "./Auth";
import authApiClient from "./AuthApiClient";

export interface Course {
    id: string;
    timePeriod: {
      endDate: Date;
      startDate: Date;
    };
    title: string;
    professorId: string;
    studentIds: string[];
  }

class CourseService{
    GetAll(setCourses: any)
    {
        authApiClient().get('Course/GetAll').then(res => setCourses(res.data))
    }

    GetById(id: any , setCourse: any)
    {
        authApiClient().post('Course/GetById' , {id}).then(res => setCourse(res.data))
    }

    GetStudentsWithCourseId(id: any , setCourseStudents: any)
    {
        authApiClient().post('Course/GetStudentsByCourseId' , {id}).then(res => setCourseStudents(res.data))
    }

    Create(course: any  )
    {
        return authApiClient().post('Course/Create' , course)
    }

    Update(course:any)
    {
        authApiClient().put('Course/Update' , course)
    }
}

export default CourseService