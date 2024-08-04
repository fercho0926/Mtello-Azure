export interface UserCreate {
    createdDate: string;
    createdBy: string;
    updatedDate: string;
    updatedBy: string;
    userId: string;
    identification: number;
    firstName: string;
    middleName: string;
    lastName: string;
    email: string;
    phone: string;
    passwordHash: string;
    passwordSalt: string;
    isActive: boolean;
  }