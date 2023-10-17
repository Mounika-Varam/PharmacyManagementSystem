import { Gender } from "src/app/Enums/gender.enum";

export interface AddUserRequest{
    fullName: string;
    email: string;
    phoneNumber: string;
    gender: Gender;
    role: string;
}