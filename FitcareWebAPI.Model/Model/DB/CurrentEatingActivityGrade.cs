using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class CurrentEatingActivityGrade
    {
        public int CurrentEatingActivityGradeId { get; set; }
        public int? Ce { get; set; }
        public decimal? MinScale { get; set; }
        public decimal? MaxScale { get; set; }
        public string EatingActivityHabit { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
