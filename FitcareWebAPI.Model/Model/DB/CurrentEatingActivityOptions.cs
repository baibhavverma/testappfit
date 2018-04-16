using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class CurrentEatingActivityOptions
    {
        public int CurrentEatingAcivityOptionsId { get; set; }
        public int? CurrentEatingActivityId { get; set; }
        public string Options { get; set; }
        public decimal? Points { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }

        public CurrentEatingActivity CurrentEatingActivity { get; set; }
    }
}
