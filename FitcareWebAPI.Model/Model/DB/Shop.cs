using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class Shop
    {
        public Shop()
        {
            TblPlayerShopInfo = new HashSet<PlayerShopInfo>();
        }

        public int ShopId { get; set; }
        public string ProductName { get; set; }
        public int? TotalCoinsReq { get; set; }
        public int? TotalStepsReq { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public ICollection<PlayerShopInfo> TblPlayerShopInfo { get; set; }
    }
}
