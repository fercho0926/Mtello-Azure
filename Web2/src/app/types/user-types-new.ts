export interface Address {
    createdDate: string;
    createdBy: string;
    updatedDate: string;
    updatedBy: string;
    addressesId: string;
    address: string;
    city: string;
    state: string;
    postalCode: string;
  }
  
  export interface UserToAddress {
    userToAddressId: string;
    userId: string;
    users: string;
    addressId: string;
    addresses: Address;
  }
  
  export interface User {
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
    userToAddresses: UserToAddress[];
  }