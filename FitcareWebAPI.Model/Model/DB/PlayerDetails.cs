using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class PlayerDetails
    {
        public int PlayerDetailsId { get; set; }
        public int? PlayerId { get; set; }
        public int? TotalCoins { get; set; }
        public int? TotalSteps { get; set; }
        public decimal? TotalDistance { get; set; }
        public decimal? AverageHeartRate { get; set; }
        public decimal? AverageBmr { get; set; }
        public decimal? TotalStandingHours { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public PlayerProfile Player { get; set; }
    }
}
