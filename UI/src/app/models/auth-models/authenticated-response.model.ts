export interface AuthenticatedResponse{
    jwtToken: string;
    userId: string;
    role: string;
}