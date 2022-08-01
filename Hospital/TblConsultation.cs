using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalWebApi.Hospital
{
    public partial class TblConsultation
    {
        public TblConsultation()
        {
            TblReports = new HashSet<TblReport>();
        }

        public int ConsultationId { get; set; }
        public int PatientId { get; set; }
        public string DoctorName { get; set; }
        public string Description { get; set; }
        public bool? TestReq { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual TblPatient Patient { get; set; }
        public virtual ICollection<TblReport> TblReports { get; set; }
    }
}
