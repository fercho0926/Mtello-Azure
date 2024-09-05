import { AddressResponse } from "../shared/address";

export interface CompanyResponse {
    companyId: string;
    companyName: string;
    email: string;
    phone: number;
    companyCode: string;
    createdBy: string;
    CreatedDate: Date; 
    isActive: boolean;
    updatedBy: string | null;
    updatedDate: Date;
    addressList: AddressResponse[]; 
  }