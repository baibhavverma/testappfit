using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class MotivatedEatingActivityHistory
    {
        public int MotivatedEatingActivityHistoryId { get; set; }
        public int? MotivatedEatingActivityId { get; set; }
        public int? PlayerId { get; set; }
        public decimal? Points { get; set; }
        public DateTime? SubmitedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public MotivatedEatingActivity MotivatedEatingActivity { get; set; }
        public PlayerProfile Player { get; set; }
    }
}
