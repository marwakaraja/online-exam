import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ExamService {
  baseURL: string = 'https://localhost:7022/api/exam/all';
  examURL: string = 'https://localhost:7022/api/exam/';

  QuestionsURL: string = 'https://localhost:7022/api/exam/exam-questions/';

 resultURL: string = 'https://localhost:7022/api/user-exam-relation/users-scores/';
 insertResultURL: string = 'https://localhost:7022/api/user-exam-relation/insert';

  baseDelete:string='https://localhost:7022/api/exam/delete';


  constructor(private http: HttpClient) {}

  getAllExams() {
    return this.http.get(this.baseURL);
  }

  getExamById(examId: any) {
    return this.http.get(`${this.QuestionsURL}${examId}`);
  }

  addExam(exam: any) {
    return this.http.post(this.baseURL,exam);
  }

  deleteExam(examId: any) {
    return this.http.delete(`${this.baseDelete}?examId=${examId}`);
  }

  editExam(examId: any, exam: any) {
    return this.http.put(`${this.baseURL}/?examId=${examId}`, exam);
  }

  getResultsExamById(examId: any) {
    return this.http.get(`${this.resultURL}${examId}`);
  }

  insertResultExamById(userId:any,examId: any,examScore:any) {
    return this.http.post(this.insertResultURL,{userId,examId,examScore});
  }

  getById(examId: any) {
    return this.http.get(`${this.examURL}${examId}`);
  }


}
