using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class PlayerShopInfo
    {
        public int PlayerShopInfoId { get; set; }
        public int? PlayerId { get; set; }
        public int? ShopId { get; set; }
        public DateTime? ShopDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public PlayerProfile Player { get; set; }
        public Shop Shop { get; set; }
    }
}
