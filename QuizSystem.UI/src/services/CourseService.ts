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
    GetAllCourses(setCourses: any)
    {
        authApiClient().get('Course/Get-All-Courses')
    }

    GetWithId(id: any , setCourse: any)
    {
        authApiClient().post('Course/Get-With-Id' , {id: id.courseId}).then(res => this.GetStudentsWithCourseId(id , setCourse).then(result => setCourse()))
    }

    GetStudentsWithCourseId(id: any , setCourse: any)
    {
        return authApiClient().post('Course/Get-Students-With-Course-Id' , {id: id.courseId})
    }
}

export default CourseService