import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CreateExamServiceService {

  baseURL :string = 'https://localhost:7022/api/exam';
  constructor(private http : HttpClient) { }
  insert(exam:any){
    return this.http.post(`${this.baseURL}/insert`, exam);
  }
}
