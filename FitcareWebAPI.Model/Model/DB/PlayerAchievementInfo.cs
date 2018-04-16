using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class PlayerAchievementInfo
    {
        public int AchievementInfoId { get; set; }
        public int? PlayerId { get; set; }
        public int? AchievementId { get; set; }
        public DateTime? AchievementDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Achievement Achievement { get; set; }
        public PlayerProfile Player { get; set; }
    }
}
