using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class CustomizationAvatar
    {
        public int CustomizationId { get; set; }
        public int? PlayerId { get; set; }
        public string SkinColorCode { get; set; }
        public string EyeColorCode { get; set; }
        public string HairColorCode { get; set; }
        public string ClothesColorCode { get; set; }
        public string ShoeColorCode { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public PlayerProfile Player { get; set; }
    }
}
