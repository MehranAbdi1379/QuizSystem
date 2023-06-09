import authApiClient from "./AuthApiClient";
import GradedQuestionService from "./GradedQuestionService";

export interface Answer{
    id: string,
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
        return authApiClient().put('Question/MultipleChoice/Update' , question)
    }
    Delete(id: any)
    {
        return authApiClient().delete('Question/MultipleChoice/Delete' , {data:{id}})
    }
    GetByCourseAndProfessorId(courseId: any , professorId: any , setMultipleChoiceQuestions: any, setError: any)
    {
        authApiClient().post('Question/MultipleChoice/GetByCourseAndProfessorId' , {courseId , professorId}).then(res => setMultipleChoiceQuestions(res.data)).catch(err => setError(err.response.data));
    }
    GetById(id: any , setQuestion: any , setError: any)
    {
        authApiClient().post('Question/MultipleChoice/GetById' , {id}).then(res => setQuestion(res.data)).catch(err => setError(err.response.data))
    }
    GetAllByExamId(id: any , setQuestions: any , setError: any)
    {
        authApiClient().post('Question/MultipleChoice/GetAllByExamId' , {id}).then(res => setQuestions(res.data)).catch(err => setError(err.response.data))
    }
    CreateAnswer(answer: any,setError: any )
    {
        return authApiClient().post('Question/MultipleChoice/Answer/Create' , answer).catch(err => setError(err.response.data));
    }
    DeleteAnswer(answerId: any, setError: any)
    {
        authApiClient().delete('Question/MultipleChoice/Answer/Delete',{data:{id: answerId}}).catch(err => setError(err.response.data));
    }
    UpdateAnswer(answer: any , setError: any)
    {
        authApiClient().patch('Question/MultipleChoice/Answer/Update' , answer)
    }
    GetAnswerByQuestionId(questionId: any , setError: any)
    {
        return authApiClient().post('Question/MultipleChoice/Answer/GetByQuestionId' , {id: questionId})
    }
    DeleteMultipleChoiceQuestionAndAnswers(questionId: any , setError: any)
    {
        const {Delete , GetAnswerByQuestionId , DeleteAnswer} = new MultipleChoiceQuestionService()
        return Delete(questionId)
                    .then(() => GetAnswerByQuestionId(questionId,setError).then(res => {
                        var result : {id: string, rightAnswer: boolean, title: string, questionId: string}[] = res.data;
                        
                        result.forEach(element => {
                            DeleteAnswer(element.id , setError);
                        });
                    }))
                      .catch((err) => setError(err.response.data));
    }
}

export default MultipleChoiceQuestionService