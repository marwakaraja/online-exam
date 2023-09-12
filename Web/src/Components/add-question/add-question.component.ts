import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ExamService } from 'src/services/Exams.service';
import { QuestionService } from 'src/services/Question.Service';

@Component({
  selector: 'app-add-question',
  templateUrl: './add-question.component.html',
  styleUrls: ['./add-question.component.css']
})
export class AddQuestionComponent implements OnInit {
  examId: any;
  examName: any;
  exam: any;
  selectedQestionID !: number;
  falsyValue: boolean = false;
  constructor(private examService: ExamService,
    private activatedRoute: ActivatedRoute,
    private questionService: QuestionService,
    private router: Router
  ) { }




  ngOnInit(): void {
    this.examId = this.activatedRoute.snapshot.paramMap.get('examId');
    this.examName = this.activatedRoute.snapshot.paramMap.get('examName');
    this.loadQestions(this.examId);
  }

  loadQestions(id: number) {
    this.questionService.getQuestions(id).subscribe({
    });
    this.questionService.getQuestions(id).subscribe((result: any) => {
      this.exam = result;
    }
    );
  }

  savequestion(){
    if (this.Questionform.status == 'VALID') {
      const question = {
        questionHeader: this.getQuestion.value,
        questionFirstChoice: this.getAnswer1.value,
        questionSecondChoice: this.getAnswer2.value,
        questionThirdChoice: this.getAnswer3.value,
        questionFourthChoice: this.getAnswer4.value,
        rightAnswer: this.getRightAnswer.value,
        examId: this.examId,
        ExamName: this.examName,
      }

      this.questionService.addQuestion(question).subscribe((Response) => {
        console.log(Response);
        this.loadQestions(this.examId);
        console.log("All Done Added");

      });
      console.log(question);
      this.Questionform.reset();

    } else {
      console.log("Error")
    }
  }
  AddNewquestion(e: any) {
    e.preventDefault();
  
  }

  EditQuestion(id: any) {
    this.falsyValue = true;
    this.selectedQestionID = id;
    console.log(id);
    this.questionService.getestionByIDElement(id).subscribe((result: any) => {
      const question = result;
      console.log(question);
      this.Questionform.patchValue({
        question: question.questionHeader,
        answer1: question.questionFirstChoice,
        answer2: question.questionSecondChoice,
        answer3: question.questionThirdChoice,
        answer4: question.questionFourthChoice,
        rigthAnswer: question.rightAnswer,
      });
      console.log(question);
    });
    console.log(this.falsyValue);
  }
  saveAllChanges() {
    const qusetion = {
      id:this.selectedQestionID,
      questionHeader: this.getQuestion.value,
      questionFirstChoice: this.getAnswer1.value,
      questionSecondChoice: this.getAnswer2.value,
      questionThirdChoice: this.getAnswer3.value,
      questionFourthChoice: this.getAnswer4.value,
      rightAnswer: this.getRightAnswer.value,
      examId: this.examId,
      ExamName: this.examName
    }

    this.questionService.Edit(qusetion).subscribe(() => {
      console.log("Edit Done");
      this.loadQestions(this.examId);
      this.Questionform.reset();
      this.falsyValue=false;
    });

  }


  DeleteQuestion(id: any) {
    this.questionService.Delete(id).subscribe(() => {
      console.log("deleted")
      this.loadQestions(this.examId);
    });

  }













  Questionform = new FormGroup({
    question: new FormControl('', [Validators.required, Validators.minLength(8)]),
    answer1: new FormControl('', [Validators.required]),
    answer2: new FormControl('', [Validators.required]),
    answer3: new FormControl('', [Validators.required]),
    answer4: new FormControl('', [Validators.required]),
    rigthAnswer: new FormControl('', [Validators.required]),
  });


  get getQuestion() {
    return this.Questionform.controls['question'];
  }

  get getAnswer1() {
    return this.Questionform.controls['answer1'];
  }
  get getAnswer2() {
    return this.Questionform.controls['answer2'];
  }
  get getAnswer3() {
    return this.Questionform.controls['answer3'];
  }
  get getAnswer4() {
    return this.Questionform.controls['answer4'];
  }
  get getRightAnswer() {
    return this.Questionform.controls['rigthAnswer'];
  }

}
