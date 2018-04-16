using System;
using System.Collections.Generic;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class PlayerProfile
    {
        public PlayerProfile()
        {
            TblCurrentEatingActivityHistory = new HashSet<CurrentEatingActivityHistory>();
            TblCustomizationAvatar = new HashSet<CustomizationAvatar>();
            TblMotivatedEatingActivityHistory = new HashSet<MotivatedEatingActivityHistory>();
            TblPlayerAchievementInfo = new HashSet<PlayerAchievementInfo>();
            TblPlayerDetails = new HashSet<PlayerDetails>();
            TblPlayerGameInfo = new HashSet<PlayerGameInfo>();
            TblPlayerQuestInfo = new HashSet<PlayerQuestInfo>();
            TblPlayerShopInfo = new HashSet<PlayerShopInfo>();
            TblSettings = new HashSet<Settings>();
        }

        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? Dob { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public decimal? BpOptional { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public ICollection<CurrentEatingActivityHistory> TblCurrentEatingActivityHistory { get; set; }
        public ICollection<CustomizationAvatar> TblCustomizationAvatar { get; set; }
        public ICollection<MotivatedEatingActivityHistory> TblMotivatedEatingActivityHistory { get; set; }
        public ICollection<PlayerAchievementInfo> TblPlayerAchievementInfo { get; set; }
        public ICollection<PlayerDetails> TblPlayerDetails { get; set; }
        public ICollection<PlayerGameInfo> TblPlayerGameInfo { get; set; }
        public ICollection<PlayerQuestInfo> TblPlayerQuestInfo { get; set; }
        public ICollection<PlayerShopInfo> TblPlayerShopInfo { get; set; }
        public ICollection<Settings> TblSettings { get; set; }
    }
}
