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
        authApiClient().post('Course/GetById' , {id: id.courseId}).then(res => setCourse(res.data))
    }

    GetStudentsWithCourseId(id: any , setCourseStudents: any)
    {
        authApiClient().post('Course/GetStudentsByCourseId' , {id: id.courseId}).then(res => setCourseStudents(res.data))
    }
}

export default CourseService