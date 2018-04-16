using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class PlayerGameInfo
    {
        public int PlayerGameInfoId { get; set; }
        public int? PlayerId { get; set; }
        public int? GameLevelId { get; set; }
        public int? Coins { get; set; }
        public int? Steps { get; set; }
        public decimal? HeartRate { get; set; }
        public decimal? Distance { get; set; }
        public decimal? Bmr { get; set; }
        public decimal? StandingHours { get; set; }
        public DateTime? PlayedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public decimal? Rpescale { get; set; }
        public decimal? CompletionScalePercent { get; set; }
        public bool? IsCompleted { get; set; }
        public string CausesOfIncompletion { get; set; }

        public GameLevel GameLevel { get; set; }
        public PlayerProfile Player { get; set; }
    }
}
