import authApiClient from "./AuthApiClient";

class DescriptiveQuestionService{
    Create(question: any , setError: any , setSubmited:any)
    {
        return authApiClient().post('Question/Descriptive/Create' , question)
    }
    Update(question:any, setError: any)
    {
        authApiClient().put('Question/Descriptive/Update' , question).catch(err => setError(err.response.data));
    }
    Delete(id: any, setError: any)
    {
        authApiClient().delete('Question/Descriptive/Delete' , {data:{id}}).catch(err => setError(err.response.data));
    }
    GetByCourseAndProfessorId(courseId: any , professorId: any , setDescriptiveQuestions: any, setError: any)
    {
        authApiClient().post('Question/Descriptive/GetByCourseAndProfessorId' , {courseId , professorId}).then(res => setDescriptiveQuestions(res.data)).catch(err => setError(err.response.data));
    }
}

export default DescriptiveQuestionService