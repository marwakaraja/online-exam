import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ExamService } from 'src/services/Exams.service';
import jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-admin-exam',
  templateUrl: './admin-exam.component.html',
  styleUrls: ['./admin-exam.component.css']
})
export class AdminExamComponent implements OnInit {
  cardColor: string[] = ['#D9EEE1', '#E7E9EB', '#F3ECEA']; 
   exams:any ;
    
  constructor(private examservices:ExamService , private router: Router){}
  ngOnInit(): void {
    this.examservices.getAllExams().subscribe({
      next:(Response)=>{
        this.exams=Response;
        console.log(this.exams);
        
      },
      error: (error) => {
        console.log(error);
      },
    })
  }

  deleteQuestion(questionID:any){ 
    this.examservices.deleteExam(questionID).subscribe((response)=>{
      console.log(response);
    });
    this.reloadPage();
  }
  reloadPage(){
    location.reload();
  }

  
 
    }
