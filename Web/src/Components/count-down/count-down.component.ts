import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExamService } from 'src/services/Exams.service';

@Component({
  selector: 'app-count-down',
  templateUrl: './count-down.component.html',
  styleUrls: ['./count-down.component.css']
})
export class CountDownComponent implements OnInit {
  examId: any;
  exams:any;
  constructor(private examservices: ExamService,
    private activatedRoute: ActivatedRoute,){}
  ngOnInit(): void {

    this.examId = this.activatedRoute.snapshot.paramMap.get('examId');

    this.examservices.getResultsExamById(this.examId).subscribe({
      next: (response: any) => {
        this.exams = response;  
        console.log(this.exams);
        
      },
      error: (error) => {
        console.log(error);
      },
    })
}}


