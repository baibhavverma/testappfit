﻿using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class TargetPeakHrgrade
    {
        public int TargetPeakHrgradeId { get; set; }
        public decimal? MinTargetPeakHrscale { get; set; }
        public decimal? MaxTargetPeakHrscale { get; set; }
        public string TargetPeakHraction { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
