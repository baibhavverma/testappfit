using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class MotivatedEatingActivity
    {
        public MotivatedEatingActivity()
        {
            TblMotivatedEatingActivityHistory = new HashSet<MotivatedEatingActivityHistory>();
            TblMotivatedEatingActivityOptions = new HashSet<MotivatedEatingActivityOptions>();
        }

        public int MotivatedEatingActivityId { get; set; }
        public string MotivatedEatingActivityQuest { get; set; }
        public int? TypeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public BehavioralType Type { get; set; }
        public ICollection<MotivatedEatingActivityHistory> TblMotivatedEatingActivityHistory { get; set; }
        public ICollection<MotivatedEatingActivityOptions> TblMotivatedEatingActivityOptions { get; set; }
    }
}
