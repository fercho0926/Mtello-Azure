export interface CreateUserRequest {
    createdDate: Date;
    createdBy: string;
    updatedDate: Date;
    updatedBy: string;
    identification: number;
    firstName: string;
    middleName: string;
    lastName: string;
    email: string;
    phone: number;
    passwordHash: string;
    passwordSalt: string;
    isActive: boolean;
  }