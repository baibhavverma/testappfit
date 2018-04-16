using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class Settings
    {
        public int SettingsId { get; set; }
        public int? PlayerId { get; set; }
        public bool? IsTilt { get; set; }
        public bool? IsSound { get; set; }
        public bool? IsSfx { get; set; }
        public bool? IsGps { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public PlayerProfile Player { get; set; }
    }
}
