﻿using Microsoft.EntityFrameworkCore;
using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Context;
using SmartDigitalPsico.Repository.Contract.Principals;
using SmartDigitalPsico.Repository.Generic;

namespace SmartDigitalPsico.Repository.Principals
{
    public class PatientRepository : GenericRepositoryEntityBase<Patient>, IPatientRepository
    {
        public PatientRepository(SmartDigitalPsicoDataContext context) : base(context) { }

        /// <summary>
        /// Find by Cpf, Rg , Email
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public async Task<Patient> FindByPatient(Patient info)
        {
            return await dataset.FirstOrDefaultAsync(x =>
               x.Cpf.ToLower().Equals(info.Cpf.ToLower())
            || x.Rg.ToLower().Equals(info.Rg.ToLower())
            || x.Email.ToLower().Equals(info.Email.ToLower())
            );
        }

        public async override Task<Patient> FindByID(long id)
        {
            return await dataset
                .Include(e => e.Medical)
                .Include(e => e.Gender)
                .Include(e => e.Medical)
                .Include(e => e.Medical.User)
                .Include(e => e.CreatedUser)
                //.Include(e => e.PatientAdditionalInformations)
                //.Include(e => e.PatientHospitalizationInformations)
                //.Include(e => e.PatientMedicationInformations)
                //.Include(e => e.PatientRecords)
                .SingleOrDefaultAsync(p => p.Id.Equals(id));
        }
        public async override Task<List<Patient>> FindAll()
        {
            await Task.Yield();
            throw new NotImplementedException();
        }
        public async Task<Patient> FindByEmail(string email)
        {
            Patient entityResult = await dataset.FirstOrDefaultAsync(p => p.Email.ToLower().Trim().Equals(email.ToLower().Trim()));

            return entityResult;
        }

        public async Task<List<Patient>> FindAllByMedicalId(long medicalId)
        {
            return await dataset
               .Include(e => e.Gender)
               .Include(e => e.Medical)
               .Include(e => e.Medical.User)
               .Include(e => e.CreatedUser)
               //.Include(e => e.PatientAdditionalInformations)
               //.Include(e => e.PatientHospitalizationInformations)
               //.Include(e => e.PatientMedicationInformations)
               //.Include(e => e.PatientRecords)
               .Where(p => p.MedicalId == medicalId)
               .ToListAsync();
        }
    }
}
