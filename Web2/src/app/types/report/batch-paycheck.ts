export interface BatchPaycheck {
    batchPaycheckId: string; // Guid in C# maps to string in TypeScript
    fileName?: string; // string? in C# maps to string | undefined in TypeScript
    companyId: string; // Guid in C# maps to string in TypeScript
    company: Company; // Assuming you have a Company interface defined elsewhere
    recordsByFile: number; // int in C# maps to number in TypeScript
    recordsProcessed: number; // int in C# maps to number in TypeScript
    totalHours: number; // int in C# maps to number in TypeScript
    totalMoney: number; // int in C# maps to number in TypeScript
    payCheckRecord: PayCheckRecord[]; // IEnumerable<PayCheckRecord> in C# maps to PayCheckRecord[] in TypeScript
    status: string; // Assuming you will change this to an enum later
}

// Example Company interface
export interface Company {
    // Define properties of the Company interface here
}

// Example PayCheckRecord interface
export interface PayCheckRecord {
    // Define properties of the PayCheckRecord interface here
}