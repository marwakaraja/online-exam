import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CreateExamServiceService } from 'src/services/create-exam.service';


@Component({
  selector: 'app-create-exam',
  templateUrl: './create-exam.component.html',
  styleUrls: ['./create-exam.component.css']
})
export class CreateExamComponent implements OnInit{
  
  constructor(
    private NewExamService :CreateExamServiceService,
    private router:Router,
    private activatedRoute:ActivatedRoute
    ) {}

  ExamForm = new FormGroup({
    examName : new FormControl('',[Validators.required , Validators.minLength(8)]),
    examDicription : new FormControl('',[Validators.required , Validators.minLength(8)]),
    examPassword : new FormControl('',[Validators.required , Validators.minLength(8)]),
  });
  exam :any;

  get getName() {
    return this.ExamForm.controls['examName'];
  }

  get getDis() {
    return this.ExamForm.controls['examDicription'];
  }

  AddNewExam(e: any) {
    e.preventDefault();
    if(this.ExamForm.status =='VALID'){
      
      const Exam ={
        examName: this.ExamForm.value.examName,
        examDescription : this.ExamForm.value.examDicription,
        passwordExam:this.ExamForm.value.examPassword,
      }

        this.NewExamService.insert(Exam).subscribe((response:any)=>
          {
            console.log(response);
           console.log("Done");
           this.ExamForm.reset();
          }
        );
        // With Deleting the CONSOL LOG
      console.log(this.ExamForm.value);
    }else{
      console.log("Error")
    }
   
  }
  ngOnInit(): void {
    
  }


}
