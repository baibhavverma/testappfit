using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class MotivatedEatingActivityGrade
    {
        public int MotivatedEatingActivityGradeId { get; set; }
        public int? Me { get; set; }
        public decimal? MinScale { get; set; }
        public decimal? MaxScale { get; set; }
        public string MotivationEatingActivityHabit { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
