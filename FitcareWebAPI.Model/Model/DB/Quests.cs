using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class Quests
    {
        public Quests()
        {
            TblPlayerQuestInfo = new HashSet<PlayerQuestInfo>();
        }

        public int QuestId { get; set; }
        public string QuestTitle { get; set; }
        public string QuestObjectives { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public ICollection<PlayerQuestInfo> TblPlayerQuestInfo { get; set; }
    }
}
