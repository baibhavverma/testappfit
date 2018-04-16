using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class Achievement
    {
        public Achievement()
        {
            TblPlayerAchievementInfo = new HashSet<PlayerAchievementInfo>();
        }

        public int AchievementId { get; set; }
        public byte[] AchievementImage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public ICollection<PlayerAchievementInfo> TblPlayerAchievementInfo { get; set; }
    }
}
