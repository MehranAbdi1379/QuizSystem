import authApiClient from "./AuthApiClient"

class GradedQuestionService{
    Create(gradedQuestion: any , setError: any)
    {
        authApiClient().post('Question/GradedQuestion/Create' , gradedQuestion)
        .catch(err => setError(err.response.data))
    }
    GetAllByExamId(examId: any , setQuestions : any , setError: any)
    {
        authApiClient().post('Question/GradedQuestion/GetAllByExamId' , {id: examId})
        .then(res=> setQuestions(res.data)).catch(err => setError(err.response.data))
    }
    Update(question: any , setError: any)
    {
        authApiClient().patch('Question/GradedQuestion/Update' , question)
        .catch(err => setError(err.response.data))
    }
    Delete(questionId: any , setError: any)
    {
        authApiClient().delete('Question/GradedQuestion/Delete' , {data:{id: questionId}})
        .catch(err => setError(err.response.data))
    }
    GetByQuestionId( questionId: any)
    {
        return authApiClient().post('Question/GradedQuestion/GetByExamAndQuestionId' , {id:questionId})
    }
    GetDescriptiveQuestionsOnly(examId: any , setQuestions: any,setError: any)
    {
        authApiClient().post('Question/GradedQuestion/GetDescriptiveQuestionsOnly' , {id:examId})
        .then(res => setQuestions(res.data)).catch(err => setError(err.response.data))
    }
    GetMultipleChoiceQuestionsOnly(examId: any , setQuestions: any,setError: any)
    {
        authApiClient().post('Question/GradedQuestion/GetMultipleChoiceQuestionsOnly' , {id:examId})
        .then(res => setQuestions(res.data)).catch(err => setError(err.response.data))
    }
}

export default GradedQuestionService