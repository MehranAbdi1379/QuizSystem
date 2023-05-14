import authApiClient from "./AuthApiClient";

class DescriptiveQuestionService{
    Create(question: any , setError: any , setSubmited:any)
    {
        return authApiClient().post('Question/Descriptive/Create' , question)
    }
    Update(question:any)
    {
        return authApiClient().put('Question/Descriptive/Update' , question)
    }
    Delete(id: any)
    {
        return authApiClient().delete('Question/Descriptive/Delete' , {data:{id}})
    }
    GetByCourseAndProfessorId(courseId: any , professorId: any , setDescriptiveQuestions: any, setError: any)
    {
        authApiClient().post('Question/Descriptive/GetByCourseAndProfessorId' , {courseId , professorId}).then(res => setDescriptiveQuestions(res.data)).catch(err => setError(err.response.data));
    }
}

export default DescriptiveQuestionService