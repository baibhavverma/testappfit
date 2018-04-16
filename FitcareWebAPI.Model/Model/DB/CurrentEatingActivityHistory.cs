using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class CurrentEatingActivityHistory
    {
        public int CurrentEatingActivityHistoryId { get; set; }
        public int? CurrentEatingActivityId { get; set; }
        public int? PlayerId { get; set; }
        public decimal? Points { get; set; }
        public DateTime? SubmitedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public CurrentEatingActivity CurrentEatingActivity { get; set; }
        public PlayerProfile Player { get; set; }
    }
}
