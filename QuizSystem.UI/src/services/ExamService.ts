import authApiClient from "./AuthApiClient";

export interface Exam {
    id: string,
    title: string,
    description: string,
    time: number,
    courseId: string
}

class ExamService{
    Create(exam: any , setError: any , setSubmited:any)
    {
        authApiClient().post('Exam/Create' , exam).then(res => setSubmited(true)).catch(err => setError(err.response.data))
    }
    Update(exam: any , setExam: any , setError: any , setSubmited: any)
    {
        authApiClient().put('Exam/Update' , exam).then(res => setExam(res.data)).then(()=>setSubmited(true)).catch(err => setError(err.response.data))
    }
    GetAllByCourseId(courseId: any , setExams:any)
    {
        authApiClient().post('Exam/GetByCourseId' , {id: courseId}).then(res => setExams(res.data))
    }
    GetById(id: any , setExam: any)
    {
        authApiClient().post('Exam/GetById' , {id}).then(res => setExam(res.data))
    }
    Delete(id: any)
    {
        authApiClient().post('Exam/Delete' , {id})
    }
}

export default ExamService