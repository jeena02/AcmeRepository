import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import ServiceService from '../service.service';
import {Activity, ParticipantInfo } from "../models/addparticipant.model"





@Component({
  selector: 'app-participant',
  templateUrl: './participant.component.html'
})

export default class ParticipantComponent {

  constructor(private ServiceService: ServiceService) { }
  public  data: any;
  public allactivity: any;
  public  EmpForm: FormGroup;
  public submitted = false;
  public displayrelated = false;
  public EventValue: any = "Save";
  public selectedActivity: any;
  public relatedParticipants: any;
  public participantresponse = new ParticipantInfo();

  ngOnInit(): void {
    this.getdata();
    this.getAllActivities();
   

    this.EmpForm = new FormGroup({
      //id: new FormControl(),
      FirstName: new FormControl("", [Validators.required]),
      LastName: new FormControl("", [Validators.required]),
      Email: new FormControl("", [Validators.required]),
      Comments: new FormControl(""),
      ActivityId: new FormControl("", [Validators.required]),
      PhoneNumber: new FormControl("", [Validators.required])
    })
  }
  getdata() {
    this.ServiceService.getData().subscribe((data: any[]) => {
      this.data = data;
    })
  }
  getAllActivities() {
    this.ServiceService.getAllActivities().subscribe((data: any[]) => {
      this.allactivity = data;
    })
  }
  getRelatedParticipants(id) {
    this.ServiceService.getRelatedParticipants(id).subscribe((data: any[]) => {
      this.relatedParticipants = data;
      })
  }

  
  filterActivity(filterVal: any) {
    if (filterVal != "0") {
      this.getRelatedParticipants(filterVal);
    }
   
  }




  deleteData(id) {
    this.ServiceService.deleteData(id).subscribe((data: any[]) => {
      this.data = data;
      this.getdata();
    })
  }
  Save() {
    this.submitted = true;

    if (this.EmpForm.invalid) {
      return;
    }
    
    this.participantresponse["FirstName"] = this.EmpForm.controls["FirstName"].value;
    this.participantresponse["LastName"] = this.EmpForm.controls["LastName"].value;
    this.participantresponse["Email"] = this.EmpForm.controls["Email"].value;
    this.participantresponse["ActivityId"] = Number(this.EmpForm.controls["ActivityId"].value);
    this.participantresponse["PhoneNumber"] = this.EmpForm.controls["PhoneNumber"].value;
    this.participantresponse["Comments"] = this.EmpForm.controls["Comments"].value;



    this.ServiceService.postData(this.participantresponse).subscribe((data: any[]) => {
      this.data = data;
      //  this.getRelatedParticipants(this.EmpForm.controls["ActivityId"].value);
      this.resetFrom(this.participantresponse.ActivityId);

    })
  //  this.getRelatedParticipants(this.EmpForm.controls["ActivityId"].value);
    alert("Congratulations.You are registred for the event now.")
   
  }
  Update() {
    this.submitted = true;

    if (this.EmpForm.invalid) {
      return;
    }
    this.ServiceService.putData(this.EmpForm.value.Id, this.EmpForm.value).subscribe((data: any[]) => {
      this.data = data;
      //this.resetFrom();
    })
  }

  EditData(Data) {
    this.EmpForm.controls["Id"].setValue(Data.empId);
    this.EmpForm.controls["FirstName"].setValue(Data.FirstName);
    this.EmpForm.controls["LastName"].setValue(Data.LastName);
    this.EmpForm.controls["Email"].setValue(Data.Email);
    this.EmpForm.controls["Comments"].setValue(Data.Comments);
    this.EventValue = "Update";
  }

  resetFrom(id) {
    this.getdata();
    this.EmpForm.reset();
    this.EventValue = "Save";
    this.submitted = false;
    this.displayrelated = true;
    this.getRelatedParticipants(id);
  }
}

