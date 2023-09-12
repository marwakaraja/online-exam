import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ExamsListComponent } from '../Components/exams-list/exams-list.component';
import { ExamQAsComponent } from 'src/Components/exam-qas/exam-qas.component';
import { ExamResultComponent } from 'src/Components/exam-result/exam-result.component';
import { HomeComponent } from 'src/Components/home/home.component';
import { AboutComponent } from 'src/Components/about/about.component';
import { NotFoundComponent } from 'src/Components/not-found/not-found.component';
import { ContactsComponent } from 'src/Components/contacts/contacts.component';
import { RegisterComponent } from 'src/Components/register/register.component';
import { LoginComponent } from 'src/Components/login/login.component';
import { routeGuardGuard } from '../services/route-guard.guard';
import { CreateExamComponent } from 'src/Components/create-exam/create-exam.component';
import { AdminExamComponent } from 'src/Components/admin-exam/admin-exam.component';
import { AddQuestionComponent } from 'src/Components/add-question/add-question.component';
import { routeGuardAdmin } from 'src/services/rout-guard-admin.service';
import { CountDownComponent } from 'src/Components/count-down/count-down.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'Home', component: HomeComponent },
  { path: 'About', component: AboutComponent },
  { path: 'Exams', component: ExamsListComponent,canActivate:[routeGuardGuard]},
  { path: 'examQA/:examId', component:ExamQAsComponent,canActivate:[routeGuardGuard]},
  { path: 'examResult/:examId', component:CountDownComponent,canActivate:[routeGuardGuard]},
  { path: 'conacts', component: ContactsComponent },
  { path: 'register', component: RegisterComponent },
  {path: 'login' , component: LoginComponent},
  {path: 'CreateExam' , component: CreateExamComponent, canActivate:[routeGuardAdmin]},
  {path: 'AdminExam' , component: AdminExamComponent, canActivate:[routeGuardAdmin]},
  { path: 'addQuestion/:examId/:examName', component:AddQuestionComponent},
  { path: 'score/:examId/:totalScore/:attampedQuesstions/:UnattampedQuesstions/:wrongAnswers/:rightAnswers/:totalexamscore/:totalQquestionNumber', component:ExamResultComponent,canActivate:[routeGuardGuard]},
  { path: '**', component:NotFoundComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
