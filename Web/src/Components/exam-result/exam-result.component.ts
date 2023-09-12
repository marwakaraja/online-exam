import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExamService } from 'src/services/Exams.service';
import { Router} from '@angular/router';


@Component({
  selector: 'app-exam-result',
  templateUrl: './exam-result.component.html',
  styleUrls: ['./exam-result.component.css']
})
export class ExamResultComponent implements OnInit {
  examId: any;
  exam:any;
  totalscore:any;
  atmpedQAs:any
  unAatmpedQAs:any
  rightAnswers:any
  wrongAnswers:any
  totalexamscore:any
  scorePresentage:any
  totalQquestionNumber:any

  constructor(
    private examservices: ExamService,
    private activatedRoute: ActivatedRoute,
    ) {}

  ngOnInit(): void {
    this.examId = this.activatedRoute.snapshot.paramMap.get('examId');
    this.totalscore = this.activatedRoute.snapshot.paramMap.get('totalScore');
    this.atmpedQAs = this.activatedRoute.snapshot.paramMap.get('attampedQuesstions'); 
    this.unAatmpedQAs = this.activatedRoute.snapshot.paramMap.get('UnattampedQuesstions'); 
    this.wrongAnswers = this.activatedRoute.snapshot.paramMap.get('wrongAnswers'); 
    this.rightAnswers = this.activatedRoute.snapshot.paramMap.get('rightAnswers'); 
    this.totalexamscore = this.activatedRoute.snapshot.paramMap.get('totalexamscore'); 
    this.totalQquestionNumber = this.activatedRoute.snapshot.paramMap.get('totalQquestionNumber'); 


    this.examservices.getExamById(this.examId).subscribe({
      next: (response: any) => {
        this.exam = response;  
        console.log(this.totalscore);
        this.scorePresentage=(this.totalscore/this.totalexamscore)*100

        
      },
      error: (error) => {
        console.log(error);
        
      }

    });

   
  }
  

}