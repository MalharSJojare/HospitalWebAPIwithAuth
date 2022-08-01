using HospitalWebApi.Hospital;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApi.Repository
{
    public interface IRepository
    {
        public void CreateAdmin(TblAdmin tblAdmin);
        public dynamic AuthenticateUser(TblAdmin tblAdmin);
        public TblAdmin GetAdminDetails(string mailId);
        public string GenerateJSONWebToken(TblAdmin admin_info, IConfiguration _config);
        public void Login(string username, string password);
        public void JWTAuthorization();
        public void LogOut();
        public void CreatePatient(TblPatient tblPatient);
        public void EditPatient(int id, TblPatient tblPatient);
        public void DeletePatient(int id);
        public TblPatient SelectPatient(int id);
        public List<TblPatient> SelectPatientList();
        public void CreateConsultation(TblConsultation tblConsultation);
        public void EditConsultation(int id, TblConsultation tblConsultation);
        public TblConsultation SelectConsultation(int id);
        public void DeleteConsultation(int id);
        public void CreateReport(TblReport tblReport);
        public void EditReport(int id ,TblReport tblReport);
        public TblReport SelectReport(int id);
        public List<TblReport> SelectReportList();
        public void DeleteReport(int id);
    }
}
