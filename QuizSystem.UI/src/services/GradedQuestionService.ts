import authApiClient from "./AuthApiClient"

class GradedQuestionService{
    Create(gradedQuestion: any , setError: any)
    {
        authApiClient().post('Question/GradedQuestion/Create' , gradedQuestion).catch(err => setError(err.response.data))
    }   
}

export default GradedQuestionService