import authApiClient from "./AuthApiClient"

export interface Professor{
    id: string,
    firstName: string,
    lastName: string,
    nationalCode: string,
    birthDate: Date,
    accepted: boolean,
    CourseIds: string[]
}
class ProfessorService{
    GetById(id: any , setProfessor: any)
    {
        authApiClient().post('Professor/GetById' , id).then(res => setProfessor(res.data))
    }

    GetAll(setProfessors: any)
    {
        authApiClient().get('Professor/GetAll').then(res => setProfessors(res.data))
    }
}

export default ProfessorService