using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class CurrentEatingActivity
    {
        public CurrentEatingActivity()
        {
            TblCurrentEatingActivityHistory = new HashSet<CurrentEatingActivityHistory>();
            TblCurrentEatingActivityOptions = new HashSet<CurrentEatingActivityOptions>();
        }

        public int CurrentEatingActivityId { get; set; }
        public string EatingActivityQuest { get; set; }
        public int? TypeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public BehavioralType Type { get; set; }
        public ICollection<CurrentEatingActivityHistory> TblCurrentEatingActivityHistory { get; set; }
        public ICollection<CurrentEatingActivityOptions> TblCurrentEatingActivityOptions { get; set; }
    }
}
