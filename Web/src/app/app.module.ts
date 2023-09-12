import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { NavbarComponent } from 'src/Components/navbar/navbar.component';
import { FooterComponent } from 'src/Components/footer/footer.component';
import { ExamsListComponent } from 'src/Components/exams-list/exams-list.component';
import { ExamQAsComponent } from 'src/Components/exam-qas/exam-qas.component';
import { ExamResultComponent } from 'src/Components/exam-result/exam-result.component';
import { HomeComponent } from 'src/Components/home/home.component';
import { AboutComponent } from 'src/Components/about/about.component';
import { NotFoundComponent } from 'src/Components/not-found/not-found.component';
import { ContactsComponent } from 'src/Components/contacts/contacts.component';
import { RegisterComponent } from 'src/Components/register/register.component';
import { LoginComponent } from 'src/Components/login/login.component';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { CreateExamComponent } from 'src/Components/create-exam/create-exam.component';
import { AdminExamComponent } from 'src/Components/admin-exam/admin-exam.component';
import { AddQuestionComponent } from 'src/Components/add-question/add-question.component';
import { CountDownComponent } from 'src/Components/count-down/count-down.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    ExamsListComponent,
    ExamQAsComponent,
    ExamResultComponent,
    HomeComponent,
    AboutComponent,NotFoundComponent,ContactsComponent,
    RegisterComponent,
    LoginComponent,
    CreateExamComponent,
    AdminExamComponent,
    AddQuestionComponent,
    CountDownComponent
  ],
  imports: [
    BrowserModule,RouterModule,
    AppRoutingModule,HttpClientModule, CommonModule,
    FormsModule,ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
