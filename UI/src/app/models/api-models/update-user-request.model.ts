import { Gender } from "src/app/Enums/gender.enum";
import { UserRole } from "src/app/Enums/user-role.enum";

export interface UpdateUserRequest{
    fullName: string;
    email: string;
    phoneNumber: string;
    gender: Gender;
    role: string;
}