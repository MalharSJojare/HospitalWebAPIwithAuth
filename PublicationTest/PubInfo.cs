using System;
using System.Collections.Generic;

#nullable disable

namespace HospitalWebApi.PublicationTest
{
    public partial class PubInfo
    {
        public string PubId { get; set; }
        public byte[] Logo { get; set; }
        public string PrInfo { get; set; }

        public virtual Publisher Pub { get; set; }
    }
}
