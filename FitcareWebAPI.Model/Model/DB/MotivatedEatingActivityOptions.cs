using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class MotivatedEatingActivityOptions
    {
        public int MotivatedEatingActivityOptionsId { get; set; }
        public int? MotivatedEatingActivityId { get; set; }
        public string Options { get; set; }
        public decimal? Points { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }

        public MotivatedEatingActivity MotivatedEatingActivity { get; set; }
    }
}
