using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class GameLevel
    {
        public GameLevel()
        {
            TblPlayerGameInfo = new HashSet<PlayerGameInfo>();
        }

        public int GameLevelId { get; set; }
        public string GameLevelName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public ICollection<PlayerGameInfo> TblPlayerGameInfo { get; set; }
    }
}
