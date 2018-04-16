using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class PlayerQuestInfo
    {
        public int PlayerQuestInfoId { get; set; }
        public int? PlayerId { get; set; }
        public int? QuestId { get; set; }
        public DateTime? QuestComepletedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? QuestAssessmentIntervalsPercent { get; set; }
        public bool? IsCompleted { get; set; }
        public int? CriterionPeriod { get; set; }

        public PlayerProfile Player { get; set; }
        public Quests Quest { get; set; }
    }
}
