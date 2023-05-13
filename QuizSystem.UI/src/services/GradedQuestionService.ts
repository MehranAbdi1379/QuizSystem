import authApiClient from "./AuthApiClient"

class GradedQuestionService{
    Create(gradedQuestion: any , setError: any)
    {
        authApiClient().post('Question/GradedQuestion/Create' , gradedQuestion).catch(err => setError(err.response.data))
    }
    GetAllByExamId(examId: any , setQuestions : any , setError: any)
    {
        authApiClient().post('Question/GradedQuestion/GetAllByExamId' , {id: examId}).then(res=> setQuestions(res.data)).catch(err => setError(err.response.data))
    }
}

export default GradedQuestionService