import authApiClient from "./AuthApiClient";

export interface Answer{
    questionId: string,
    title: string,
    rightAnswer: boolean
}

class MultipleChoiceQuestionService{
    Create(question: any, setError: any)
    {
        return authApiClient().post('Question/MultipleChoice/Create' , question)
    }
    Update(question:any, setError: any)
    {
        authApiClient().put('Question/MultipleChoice/Update' , question).catch(err => setError(err.response.data));
    }
    Delete(id: any, setError: any)
    {
        authApiClient().delete('Question/MultipleChoice/Delete' , {data:{id}}).catch(err => setError(err.response.data));
    }
    GetByCourseAndProfessorId(courseId: any , professorId: any , setDescriptiveQuestions: any, setError: any)
    {
        authApiClient().post('Question/MultipleChoice/GetByCourseAndProfessorId' , {courseId , professorId}).then(res => setDescriptiveQuestions(res.data)).catch(err => setError(err.response.data));
    }
    CreateAnswer(answer: any, setError: any )
    {
        authApiClient().post('Question/MultipleChoice/Answer/Create' , answer).catch(err => setError(err.response.data));
    }
    DeleteAnswer(answerId: any, setError: any)
    {
        authApiClient().delete('Question/MultipleChoice/Answer/Delete',{data:{answerId}}).catch(err => setError(err.response.data));
    }
}

export default MultipleChoiceQuestionService