using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalWebApi.PublicationTest
{
    public partial class TransactionTable
    {
        public int TranId { get; set; }
        public int? FromAcc { get; set; }
        public int? ToAcc { get; set; }
        public int? Amount { get; set; }
        public string Remarks { get; set; }
    }
}
