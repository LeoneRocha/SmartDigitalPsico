﻿using SmartDigitalPsico.Model.Entity.Domains;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.Contract.Principals
{
    public interface IPatientRepository : IRepositoryEntityBase<Patient>
    {
        Task<Patient> FindByPatient(Patient info);
    }
}
