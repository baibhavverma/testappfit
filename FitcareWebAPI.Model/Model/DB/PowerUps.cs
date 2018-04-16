using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class PowerUps
    {
        public int PowerUpId { get; set; }
        public string PowerUpType1 { get; set; }
        public string PowerUpType2 { get; set; }
        public string PowerUpType3 { get; set; }
        public string PowerUpType4 { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
