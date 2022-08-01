using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalWebApi.Hospital
{
    public partial class TblAdmin
    {
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string PhoneNum { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
