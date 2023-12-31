export interface IPatient {
    id: number
    patientName: string
    carnetIdentification: string
    dob: string
    gender: string
    address: string
    phone: number
    email: string
    socialSecurity: string
}

export interface IPatientToCreate {
    patientName: string
    carnetIdentification: string
    dob: string
    gender: string
    address: string
    phone: number
    email: string
    socialSecurity: string
}

export class PatientFormValues implements IPatientToCreate {
    patientName = "";
    carnetIdentification = "";
    dob = "";
    gender = "";
    address = "";
    phone = 0;
    email = "";
    socialSecurity = "";

    constructor(init?: PatientFormValues) {
        Object.assign(this, init);
    }
}
