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
    GetById(id: any , setQuestion: any , setError: any)
    {
        authApiClient().post('Question/Descriptive/GetById' , {id}).then(res => setQuestion(res.data)).catch(err => setError(err.response.data))
    }
    GetAllByExamId(id: any , setQuestions: any , setError: any)
    {
        authApiClient().post('Question/Descriptive/GetAllByExamId' , {id}).then(res => setQuestions(res.data)).catch(err => setError(err.response.data))
    }
}

export default DescriptiveQuestionService