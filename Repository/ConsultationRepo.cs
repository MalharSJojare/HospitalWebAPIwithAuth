using HospitalWebApi.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApi.Repository
{
    public partial class Repository
    {
        public void CreateConsultation(TblConsultation tblConsultation) 
        {
            using (AngularHospitalContext angularHospitalContext = new())
            {
                angularHospitalContext.TblConsultations.Add(tblConsultation);
                angularHospitalContext.SaveChanges();
            }
        }
        public void EditConsultation(int id, TblConsultation tblConsultation)
        {
            using (AngularHospitalContext angularHospitalContext = new())
            {
                TblConsultation tblConsultation1 = angularHospitalContext.TblConsultations.Find(id);
                if (tblConsultation1 != null)
                {
                    tblConsultation1.PatientId = tblConsultation.PatientId != 0 ? tblConsultation.PatientId : tblConsultation1.PatientId;
                    tblConsultation1.Description = tblConsultation.Description != "" ? tblConsultation.Description : tblConsultation1.Description;
                    tblConsultation1.DoctorName = tblConsultation.DoctorName != "" ? tblConsultation.DoctorName : tblConsultation1.DoctorName;
                    tblConsultation1.TestReq = tblConsultation.TestReq;
                    tblConsultation1.ModifiedDate = new DateTime();
                    angularHospitalContext.SaveChanges();
                }
            }
        }
        public TblConsultation SelectConsultation(int id) 
        {
            using (AngularHospitalContext angularHospitalContext = new())
            {
                TblConsultation tblConsultation = angularHospitalContext.TblConsultations.Find(id);
                TblPatient tblPatient = angularHospitalContext.TblPatients.Find(tblConsultation.PatientId);
                tblConsultation.Patient = tblPatient;
                return tblConsultation;
            }   
        }
        public void DeleteConsultation(int id) 
        {
            using (AngularHospitalContext angularHospitalContext = new())
            {
                TblConsultation tblConsultation = angularHospitalContext.TblConsultations.Find(id);
                angularHospitalContext.TblConsultations.Remove(tblConsultation);
                angularHospitalContext.SaveChanges();
            }
        }

    }
}
