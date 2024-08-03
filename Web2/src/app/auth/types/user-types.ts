export interface IUser {
    createdBy: string;
    createdDate: string; // This should ideally be a Date object, but if you're receiving it as a string, you can parse it when needed.
    email: string;
    firstName: string;
    identification: number;
    isActive: boolean;
    lastName: string;
    middleName: string;
    password: string;
    phone: string;
    updatedBy: string;
    updatedDate: string; // Same as createdDate, consider parsing to Date object when needed.
    userId: string;
  }
  