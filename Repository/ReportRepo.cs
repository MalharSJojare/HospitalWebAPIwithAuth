using HospitalWebApi.Hospital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebApi.Repository
{
    public partial class Repository
    {
        public void CreateReport(TblReport tblReport) 
        {
            using (AngularHospitalContext angularHospitalContext = new())
            {
                angularHospitalContext.TblReports.Add(tblReport);
                angularHospitalContext.SaveChanges();
            }
        }
        public void EditReport( int id, TblReport tblReport) 
        {
            using (AngularHospitalContext angularHospitalContext = new())
            {
                TblReport tblReport1 = angularHospitalContext.TblReports.Find(id);
                tblReport1.ConsultationId = tblReport.ConsultationId != 0 ? tblReport.ConsultationId : tblReport1.ConsultationId;
                tblReport1.LabTest = tblReport.LabTest != "" ? tblReport.LabTest : tblReport1.LabTest;
                tblReport1.Result = tblReport.Result == "" ? tblReport.Result : tblReport1.Result;
                tblReport1.ReportingTo = tblReport.ReportingTo != "" ? tblReport.ReportingTo : tblReport1.ReportingTo;
                tblReport1.ModifiedDate = new DateTime();
                angularHospitalContext.SaveChanges();
            }
        }
        public TblReport SelectReport(int id) 
        {
            using (AngularHospitalContext angularHospitalContext = new())
            {
                TblReport tblReport = angularHospitalContext.TblReports.Find(id);
                TblConsultation tblConsultation = SelectConsultation(tblReport.ConsultationId);
                tblReport.Consultation = tblConsultation;
                return tblReport;
            }
        }
        public List<TblReport> SelectReportList() 
        {
            using (AngularHospitalContext angularHospitalContext = new())
            {
                return angularHospitalContext.TblReports.ToList();
            }
        }
        public void DeleteReport(int id) 
        {
            using (AngularHospitalContext angularHospitalContext = new())
            {
                TblReport tblReport = angularHospitalContext.TblReports.Find(id);
                angularHospitalContext.TblReports.Remove(tblReport);
                angularHospitalContext.SaveChanges();
            }
        }
    }
}
