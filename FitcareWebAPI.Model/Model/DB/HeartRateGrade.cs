using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class HeartRateGrade
    {
        public int HeartRateScaleId { get; set; }
        public decimal? MinHeartRateScale { get; set; }
        public decimal? MaxHeartRateScale { get; set; }
        public string HeartRateAction { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
