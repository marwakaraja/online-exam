import { Component ,OnInit} from '@angular/core';
import { ExamService } from 'src/services/Exams.service';
@Component({
  selector: 'app-exams-list',
  templateUrl: './exams-list.component.html',
  styleUrls: ['./exams-list.component.css']
})

export class ExamsListComponent implements OnInit {
cardColor: string[] = ['#D9EEE1', '#E7E9EB', '#F3ECEA'];  
exams:any;
 
allow:boolean=true;
  constructor(private examservices:ExamService){}
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

}
