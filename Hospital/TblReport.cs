using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalWebApi.Hospital
{
    public partial class TblReport
    {
        public int ReportId { get; set; }
        public int ConsultationId { get; set; }
        public string LabTest { get; set; }
        public string Result { get; set; }
        public string ReportingTo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual TblConsultation Consultation { get; set; }
    }
}
