import { Gender } from "src/app/Enums/gender.enum";

export interface UserRegistration{
    username:string;
    password:string;
    fullName:string;
    phoneNumber:string;
    gender: Gender;
    role: string;
}