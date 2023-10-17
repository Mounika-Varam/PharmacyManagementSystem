import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/api-models/user.model';
import { HttpClient } from '@angular/common/http';
import { AddUserRequest } from '../models/api-models/add-user-request.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseApiUrl = "https://localhost:7079/api";

  constructor(private httpClient: HttpClient) {}

  getUsers() : Observable<User[]>{
    return this.httpClient.get<User[]>(this.baseApiUrl + "/Users");
  }

  getUserById(userId: string) : Observable<User>{
    return this.httpClient.get<User>(this.baseApiUrl + "/Users/" + userId);
  }

  getUserByEmail(email: string) : Observable<User>{
    return this.httpClient.get<User>(this.baseApiUrl + "/Users/" + email + "/by-email");
  }



  addDrug(userRequest: User): Observable<User>{
    const addUserRequest: AddUserRequest = {
      fullName: userRequest.fullName,
      email: userRequest.email,
      phoneNumber: userRequest.phoneNumber,
      gender: userRequest.gender,
      role: userRequest.role
  };

  return this.httpClient.post<User>(this.baseApiUrl + '/Users/', addUserRequest );
  }

}
