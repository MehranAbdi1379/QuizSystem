import authApiClient from "./AuthApiClient";

class ExamStudentService{
    Create(examId: any , setExamStudent: any,setError: any)
    {
        authApiClient().post('Exam/ExamStudent/Create' , {examId , studentId: localStorage.getItem('userId')}).then(res => setExamStudent(res.data))
        .catch(err => setError(err.response.data))
    }
    GetByExamAndStudentId(examId: any , setExamStudent: any,setError: any)
    {
        authApiClient().post('Exam/ExamStudent/Get' , {examId, studentId: localStorage.getItem('userId')}).then(res => setExamStudent(res.data))
        .catch(err => setError(err.response.data))
    }
    Exist(examId:any , setExist: any , setError: any)
    {
        authApiClient().post('Exam/ExamStudent/Exist' , {examId , studentId: localStorage.getItem('userId')}).then(res => setExist(res.data)).catch(err => setError(err.response.data))
    }
    GetAllByExamId(examId: any , setExamStudents: any , setError: any)
    {
        authApiClient().post('Exam/ExamStudent/GetAllByExamId' , {id:examId}).then(res => setExamStudents(res.data))
        .catch(err => setError(err.response.data))
    }
    Finished(examId:any , setFinished: any , setError: any)
    {
        authApiClient().post('Exam/ExamStudent/Finished' , {examId , studentId: localStorage.getItem('userId')}).then(res => setFinished(res.data)).catch(err => setError(err.response.data))
    }
    CountDownTimeLift(examStudentId: any , setError: any)
    {
        authApiClient().post('Exam/ExamStudent/UpdateTimeLeft', {id: examStudentId}).catch(err => setError(err.response.data))
    }
    CreateQuestion(examStudentId: any , gradedQuestionId: any , answer: any ,setExamStudentQuestion: any, setError:any)
    {
        authApiClient().post('Question/ExamStudentQuestion/Create' , {examStudentId, gradedQuestionId,answer})
        .then(res => setExamStudentQuestion(res.data)).catch(err => setError(err.response.data))
    }
    GetQuestion(gradedQuestionId: any , examStudentId: any , setExamStudentQuestion: any, setError:any)
    {
        authApiClient().post('Question/ExamStudentQuestion/Get' , {gradedQuestionId, examStudentId})
        .then(res => setExamStudentQuestion(res.data)).catch(err => setError(err.response.data))
    }
    UpdateQuestion(id: any , answer: any , setError: any)
    {
        authApiClient().patch('Question/ExamStudentQuestion/Update', {id, answer}).catch(err => setError(err.response.data))
    }
    UpdateQuestionGrade(id: any , grade: any , setError: any)
    {
        authApiClient().patch('Question/ExamStudentQuestion/UpdateGrade', {id , grade}).catch(err => setError(err.response.data))
    }
    GetAllQuestionsByExamAndStudentId(examId: any , studentId: any , setExamStudentQuestions: any , setError: any)
    {
        authApiClient().post('Question/ExamStudentQuestion/GetAllByExamAndStudentId' , {examId , studentId})
        .then(res => setExamStudentQuestions(res.data)).catch(err => setError(err.response.data))
    }
}

export default ExamStudentService