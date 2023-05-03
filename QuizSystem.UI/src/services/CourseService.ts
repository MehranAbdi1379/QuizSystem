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

    Create(course: any , setCourseId: any , setError : any , setSubmited: any)
    {
         authApiClient().post('Course/Create' , course).then(res => setCourseId(res.data)).then(() => setSubmited(true)).catch(err => setError(err.response.data))
    }

    Update(course:any , setError: any , setSubmited: any)
    {
        authApiClient().put('Course/Update' , course).then(res => setSubmited(true)).catch(err => setError(err.response.data))
    }

    GetByProfessorId(id: any , setCourses: any)
    {
        authApiClient().post('Course/GetByProfessorId' , {id}).then(res => setCourses(res.data))
    }
    Delete(id: any)
    {
        authApiClient().post('Course/Delete' , {id})
    }
}

export default CourseService