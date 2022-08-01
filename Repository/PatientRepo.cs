using HospitalWebApi.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApi.Repository
{
    public partial class Repository
    {
        public void CreatePatient(TblPatient tblPatient)
        {
            using (AngularHospitalContext angularHospitalContext = new()) 
            {
                angularHospitalContext.TblPatients.Add(tblPatient);
                angularHospitalContext.SaveChanges();
            }
        }
        public void EditPatient(int id, TblPatient tblPatient) 
        {
            using (AngularHospitalContext angularHospitalContext = new())
            {
                TblPatient tblPatient1 = angularHospitalContext.TblPatients.Find(id);
                if (tblPatient1 != null)
                {
                    tblPatient1.FirstName = tblPatient.FirstName !="" ? tblPatient.FirstName : tblPatient1.FirstName;
                    tblPatient1.LastName = tblPatient.LastName != "" ? tblPatient.LastName : tblPatient1.LastName;
                    tblPatient1.PhoneNum = tblPatient.PhoneNum != "" ? tblPatient.PhoneNum : tblPatient1.PhoneNum;
                    tblPatient1.AddressLine1 = tblPatient.AddressLine1 != "" ? tblPatient.AddressLine1 : tblPatient1.AddressLine1;
                    tblPatient1.AddressLine2 = tblPatient.AddressLine2 != "" ? tblPatient.AddressLine2 : tblPatient1.AddressLine2;
                    tblPatient1.City = tblPatient.City != "" ? tblPatient.City : tblPatient1.City;
                    tblPatient1.State = tblPatient.State != "" ? tblPatient.State : tblPatient1.State;
                    tblPatient1.ZipCode = tblPatient.ZipCode != "" ? tblPatient.ZipCode : tblPatient1.ZipCode;
                    tblPatient1.EmailId = tblPatient.EmailId != "" ? tblPatient.EmailId : tblPatient1.EmailId;
                    ///tblPatient1.ModifiedDate = new DateTime();
                    angularHospitalContext.SaveChanges();
                }
            }
        }
        public void DeletePatient(int id) 
        {
            using (AngularHospitalContext angularHospitalContext = new())
            {
                TblPatient tblPatient= angularHospitalContext.TblPatients.Find(id);
                //angularHospitalContext.Entry(tblPatient).State = (Microsoft.EntityFrameworkCore.EntityState)System.Data.Entity.EntityState.Deleted;
                //angularHospitalContext.SaveChanges();
                angularHospitalContext.TblPatients.Remove(tblPatient);
                angularHospitalContext.SaveChanges();
            }
        }
        public TblPatient SelectPatient(int id) 
        {
            using (AngularHospitalContext angularHospitalContext = new())
            {
                TblPatient tblPatient = angularHospitalContext.TblPatients.Find(id);
                return tblPatient;
            }
        }
        public List<TblPatient> SelectPatientList() 
        {
            using (AngularHospitalContext angularHospitalContext = new())
            {
                List<TblPatient> tblPatient = angularHospitalContext.TblPatients.ToList();
                return tblPatient;
            }
        }

    }
}
