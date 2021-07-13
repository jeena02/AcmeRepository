import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})

export default class ServiceService {
  Base_URL: "https://localhost:44333/"

  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  getData() {

    return this.http.get('https://localhost:44333/api/Participant/GetAllParticipants');
    
  }
  getAllActivities() {

    return this.http.get('https://localhost:44333/api/Activity/GetAllActivities');

  }
  getRelatedParticipants(id) {

    return this.http.get('https://localhost:44333/api/Participant/GetRelatedParticipants/' + id);

  }

  postData(formData) {
    return this.http.post('https://localhost:44333/api/Participant/AddParticipant', formData);
  }

  putData(id, formData) {
    return this.http.put('https://localhost:44333/api/Participant/' + id, formData);
  }

  /* to be completed */
  deleteData(id) {
    return this.http.delete('/api/Delete/' + id);
  }

}
