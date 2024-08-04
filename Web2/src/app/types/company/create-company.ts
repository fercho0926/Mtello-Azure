export interface CreateCompany {
    createdBy: string;
    companyName: string;
  }




  export interface Company {
    companyId: string;
    companyName: string;
    createdBy: string;
    CreatedDate: string; // Use Date if you want to handle it as a Date object
    isActive: boolean;
    updatedBy: string | null;
    updatedDate: string; // Use Date if you want to handle it as a Date object
  }