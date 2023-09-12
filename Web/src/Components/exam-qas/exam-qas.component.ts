import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExamService } from 'src/services/Exams.service';
import { QuestionService } from 'src/services/Question.Service';
import { Router } from '@angular/router';
import jwt_decode from 'jwt-decode';

@Component({
  selector: 'app-exam-qas',
  templateUrl: './exam-qas.component.html',
  styleUrls: ['./exam-qas.component.css']
})
export class ExamQAsComponent implements OnInit {
  id:any;
  exam: any;
  examId: any;
  Questions: any;
  IsVisible=false;
  PasswordCheckIsVisible=true;
  Choices: any[] = [];
  currentQuestionIndex = 0;
  currentQuestion:any;
  selectedAnswer:any[] = [];
  score :any[] = [];
  progressValue: any;
  isSubmittedVisible = false;
  rightAnswers=0
  wrongAnswers=0
  totalScore=0
  userExamRelation:any
  attampedQuesstions=0;
UnattampedQuesstions=0;
questionScore=10;
totalexamscore:any
totalQquestionNumber=0;
token: any;
  userId: any;
  tokenData: any;
  ExamPassword!:string;
 warnPassword=false;
  
  private _value!: string;
  scorePresentage:any;

  
  constructor(
    private examservices: ExamService,
    private questionService:QuestionService,
    private activatedRoute: ActivatedRoute,
    private router:Router
  ) {}

  ngOnInit(): void {
    this.examId = this.activatedRoute.snapshot.paramMap.get('examId');
    this.token = localStorage.getItem("token");

    if (this.token != null) {
      this.tokenData = jwt_decode(this.token);
      this.userId = this.tokenData["http://schemas.microsoft.com/ws/2008/06/identity/claims/serialnumber"]
    }

    this.examservices.getById(this.examId).subscribe({
      next: (response) => {
        this.exam = response; 
        this.ExamPassword=this.exam.passwordExam;
       
      },
      error: (error) => {
        console.log(error);
      }
      
    });

    this.questionService.getQuestions(this.examId).subscribe({
      next: (response: any) => {
        this.Questions = response;
        this.totalQquestionNumber=this.Questions.length;
        
      this.getChoices();    
        this.score=[this.Questions.length];     
      },
      error: (error) => {
        console.log(error);
      }
    });
  }

  getNextQuestion() {
    
    if (this.currentQuestionIndex < this.Questions.length-1) {
      this.scoreCaluclation()
      this.currentQuestionIndex++;
      this.getChoices();

    } else {

      this.scoreCaluclation()
      this.isSubmittedVisible=true;
    }
  }
  getPreviousQuestion(){

    console.log(this.currentQuestionIndex);
    if (this.currentQuestionIndex>0) {
      this.currentQuestionIndex--;
      this.scoreCaluclation()

      this.getChoices();
    } 
  }

  scoreCaluclation() {
 
    if(this.selectedAnswer[this.currentQuestionIndex] ==this.currentQuestion.rightAnswer)
    {
      this.score[this.currentQuestionIndex]=(1*this.questionScore);
      //this.rightAnswers++
      //this.attampedQuesstions++
    }else if(this.selectedAnswer[this.currentQuestionIndex]==null){
    // this.UnattampedQuesstions++;
    this.score[this.currentQuestionIndex]=null;

    }
    else{
      this.score[this.currentQuestionIndex]=0;
      // this.wrongAnswers++
      // this.attampedQuesstions++

    }
   this.totalScore=this.score.reduce((total,current)=>total+current,0)
   console.log("total score"+ this.totalScore);
   
  }

  getChoices(){
    this.currentQuestion = this.Questions[this.currentQuestionIndex];
    this.Choices = [
    this.currentQuestion.questionFirstChoice,
    this.currentQuestion.questionSecondChoice,
    this.currentQuestion.questionThirdChoice,
    this.currentQuestion.questionFourthChoice
  ];
  this.selectedAnswer.length=this.Choices.length;
  this.totalexamscore=this.Questions.length*this.questionScore;
        console.log( this.totalexamscore,);
  
  }

  onProgress(){
    if (this.currentQuestionIndex< this.Questions.length+1) {
      this.progressValue = ((this.currentQuestionIndex+1) / this.Questions.length) * 100; 
       }
      else{this.progressValue = 0;}
      return this.progressValue;
  }
  onSubmit(){
    
    for(var i=0;this.score.length>i;i++){
        if(this.score[i] > 0) {
          this.rightAnswers++;
          console.log( this.rightAnswers,this.wrongAnswers,this.UnattampedQuesstions,this.attampedQuesstions);
          this.attampedQuesstions++;

        }
        else if(this.score[i] == null){
            this.UnattampedQuesstions++;
        }else{
          this.wrongAnswers++;
          this.attampedQuesstions++;
        }
    }
    this.examservices.insertResultExamById(this.userId,this.examId, (this.totalScore/this.totalexamscore)*100).subscribe();

   this.router.navigate(['/score',this.examId,this.totalScore,this.attampedQuesstions,this.UnattampedQuesstions,this.wrongAnswers,this.rightAnswers,this.totalexamscore,this.totalQquestionNumber]);

  }

  public get value() : string {
    return this._value;
  }
  public set value(v : string) {
    this._value = v;

  }

  DoCheck() {
    if(this.value == this.ExamPassword)
    {
      this.IsVisible=true;
      this.PasswordCheckIsVisible=false;
      this.warnPassword=false;
    }
    
  else
  {
    this.IsVisible=false;
    this.PasswordCheckIsVisible=true;
    this.warnPassword=true;
    this.value="";
   
   
  }
  
    }

    tryAgain()
    {
      window.location.reload();    }

}
