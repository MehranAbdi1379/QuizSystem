import { QuestionCreateFormData } from "../pages/Professor/ProfessorQuestionCreatePage";
import DescriptiveQuestionService from "./DescriptiveQuestionService";
import GradedQuestionService from "./GradedQuestionService";
import MultipleChoiceQuestionService from "./MultipleChoiceQuestionService";

export interface Question{
    id: string,
    title: string,
    description: string,
    courseId: string,
    professorId: string
}

class QuestionService{
    CreateAndAddQuestion(data: QuestionCreateFormData , state: any , setError: any , setSubmited:any , answerCount:number ) {
        const {Create:CreateDescriptiveQuestion} = new DescriptiveQuestionService()
        const {Create: CreateGradedQuestion} = new GradedQuestionService()
        const {Create:MultipleChoiceQuestionCreate , CreateAnswer} = new MultipleChoiceQuestionService()
        if(data.multipleChoiceAnswers)for (let i = 0; i < data.multipleChoiceAnswers.length; i++) {
          for (let j = i+1; j < data.multipleChoiceAnswers.length; j++) {
            if(data.multipleChoiceAnswers[i]==data.multipleChoiceAnswers[j]) {
              setError('Answers should be unique')
              return;
            };
          }
          
        }
        let answerError = false;
        if (data.type == "Descriptive") {
          const question = {
            description: data.description,
            professorId: localStorage.getItem("userId"),
            courseId: state.courseId,
            title: data.title,
          };
          CreateDescriptiveQuestion(question, setError, setSubmited)
            .then((res) => {
              CreateGradedQuestion(
                {
                  questionId: res.data.id,
                  examId: state.examId,
                  grade: data.grade,
                },
                setError
              );
              setSubmited(true);
            })
            .catch((err) => setError(err.response.data));
        } else if (data.type == "Multiple Choice") {
          const question = {
            description: data.description,
            professorId: localStorage.getItem("userId"),
            courseId: state.courseId,
            title: data.title,
          };
          MultipleChoiceQuestionCreate(question, setError)
            .then((res) => {
              if (data.multipleChoiceAnswers?.length)
                for (let i = 0; i < answerCount; i++) {
                  const answer = {
                    questionId: res.data.id,
                    rightAnswer: i == 0 ? true : false,
                    title: data.multipleChoiceAnswers[i],
                  };
                  CreateAnswer(answer, setError).catch(err => {answerError=true; setError(err.response.data)});
                }
                if(answerError==false)
                {
                    CreateGradedQuestion(
                        {
                          questionId: res.data.id,
                          examId: state.examId,
                          grade: data.grade,
                        },
                        setError
                      );
                      setSubmited(true);
                }
            })
            .catch((err) => setError(err.response.data));
        }
      }
}

export default QuestionService