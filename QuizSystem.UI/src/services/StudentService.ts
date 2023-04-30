import authApiClient from "./AuthApiClient"

export interface Student{
    id: string,
    firstName: string,
    lastName: string,
    nationalCode: string,
    birthDate: Date,
    accepted: boolean,
    CourseIds: string[]
}
class StudentService{
    GetById(id: any , setStudent: any)
    {
        authApiClient().post('Student/GetById' , id).then(res => setStudent(res.data))
    }

    GetAll(setStudents: any)
    {
        authApiClient().get('Student/GetAll').then(res => setStudents(res.data))
    }
}

export default StudentService