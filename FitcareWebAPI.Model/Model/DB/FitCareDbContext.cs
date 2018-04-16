using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FitcareWebAPI.Model.Model.DB
{
    public partial class FitCareDbContext : DbContext
    {
        public virtual DbSet<Achievement> TblAchievement { get; set; }
        public virtual DbSet<CompletionGrade> TblCompletionGrade { get; set; }
        public virtual DbSet<CriterionPeriods> TblCriterionPeriod { get; set; }
        public virtual DbSet<CurrentEatingActivity> TblCurrentEatingActivity { get; set; }
        public virtual DbSet<CurrentEatingActivityGrade> TblCurrentEatingActivityGrade { get; set; }
        public virtual DbSet<CurrentEatingActivityHistory> TblCurrentEatingActivityHistory { get; set; }
        public virtual DbSet<CurrentEatingActivityOptions> TblCurrentEatingActivityOptions { get; set; }
        public virtual DbSet<CustomizationAvatar> TblCustomizationAvatar { get; set; }
        public virtual DbSet<EncouragementMsgs> TblEncouragementMsgs { get; set; }
        public virtual DbSet<GameLevel> TblGameLevel { get; set; }
        public virtual DbSet<HeartRateGrade> TblHeartRateGrade { get; set; }
        public virtual DbSet<MotivatedEatingActivity> TblMotivatedEatingActivity { get; set; }
        public virtual DbSet<MotivatedEatingActivityGrade> TblMotivatedEatingActivityGrade { get; set; }
        public virtual DbSet<MotivatedEatingActivityHistory> TblMotivatedEatingActivityHistory { get; set; }
        public virtual DbSet<MotivatedEatingActivityOptions> TblMotivatedEatingActivityOptions { get; set; }
        public virtual DbSet<NotificationMessages> TblNotificationMessage { get; set; }
        public virtual DbSet<PlayerAchievementInfo> TblPlayerAchievementInfo { get; set; }
        public virtual DbSet<PlayerDetails> TblPlayerDetails { get; set; }
        public virtual DbSet<PlayerGameInfo> TblPlayerGameInfo { get; set; }
        public virtual DbSet<PlayerProfile> TblPlayerProfile { get; set; }
        public virtual DbSet<PlayerQuestInfo> TblPlayerQuestInfo { get; set; }
        public virtual DbSet<PlayerShopInfo> TblPlayerShopInfo { get; set; }
        public virtual DbSet<PowerUps> TblPowerUps { get; set; }
        public virtual DbSet<Quests> TblQuests { get; set; }
        public virtual DbSet<ReinforcementMsgs> TblReinforcementMsgs { get; set; }
        public virtual DbSet<Rpegrade> TblRpegrade { get; set; }
        public virtual DbSet<Settings> TblSettings { get; set; }
        public virtual DbSet<Shop> TblShop { get; set; }
        public virtual DbSet<TargetPeakHrgrade> TblTargetPeakHrgrade { get; set; }
        public virtual DbSet<BehavioralType> TblType { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseNpgsql(@"User ID=postgres;Password=pgadmin;Host=localhost;Port=5432;Database=FitCareDb;Pooling=true;");
        //            }
        //        }

        public FitCareDbContext(DbContextOptions<FitCareDbContext> options)
: base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.HasKey(e => e.AchievementId);

                entity.ToTable("Tbl_Achievement");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");
            });

            modelBuilder.Entity<CompletionGrade>(entity =>
            {
                entity.HasKey(e => e.CompletionGradeId);

                entity.ToTable("Tbl_CompletionGrade");

                entity.Property(e => e.CompletionScalePercent).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");
            });

            modelBuilder.Entity<CriterionPeriods>(entity =>
            {
                entity.HasKey(e => e.CriterionPeriodId);

                entity.ToTable("Tbl_CriterionPeriod");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");
            });

            modelBuilder.Entity<CurrentEatingActivity>(entity =>
            {
                entity.HasKey(e => e.CurrentEatingActivityId);

                entity.ToTable("Tbl_CurrentEatingActivity");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TblCurrentEatingActivity)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("Tbl_CurrentEatingActivity_TypeId_fkey");
            });

            modelBuilder.Entity<CurrentEatingActivityGrade>(entity =>
            {
                entity.HasKey(e => e.CurrentEatingActivityGradeId);

                entity.ToTable("Tbl_CurrentEatingActivityGrade");

                entity.Property(e => e.Ce).HasColumnName("CE");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.Property(e => e.MaxScale).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.MinScale).HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<CurrentEatingActivityHistory>(entity =>
            {
                entity.HasKey(e => e.CurrentEatingActivityHistoryId);

                entity.ToTable("Tbl_CurrentEatingActivityHistory");

                entity.Property(e => e.CurrentEatingActivityHistoryId).HasDefaultValueSql("nextval('\"Tbl_CurrentEatingActivityHist_CurrentEatingActivityHistoryI_seq\"'::regclass)");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.Property(e => e.Points).HasColumnType("numeric(5, 2)");

                entity.HasOne(d => d.CurrentEatingActivity)
                    .WithMany(p => p.TblCurrentEatingActivityHistory)
                    .HasForeignKey(d => d.CurrentEatingActivityId)
                    .HasConstraintName("Tbl_CurrentEatingActivityHistory_CurrentEatingActivityId_fkey");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TblCurrentEatingActivityHistory)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("Tbl_CurrentEatingActivityHistory_PlayerId_fkey");
            });

            modelBuilder.Entity<CurrentEatingActivityOptions>(entity =>
            {
                entity.HasKey(e => e.CurrentEatingAcivityOptionsId);

                entity.ToTable("Tbl_CurrentEatingActivityOptions");

                entity.Property(e => e.CurrentEatingAcivityOptionsId).HasDefaultValueSql("nextval('\"Tbl_CurrentEatingActivityOpti_CurrentEatingAcivityOptionsId_seq\"'::regclass)");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.Property(e => e.Points).HasColumnType("numeric(5, 2)");

                entity.HasOne(d => d.CurrentEatingActivity)
                    .WithMany(p => p.TblCurrentEatingActivityOptions)
                    .HasForeignKey(d => d.CurrentEatingActivityId)
                    .HasConstraintName("Tbl_CurrentEatingActivityOptions_CurrentEatingActivityId_fkey");
            });

            modelBuilder.Entity<CustomizationAvatar>(entity =>
            {
                entity.HasKey(e => e.CustomizationId);

                entity.ToTable("Tbl_CustomizationAvatar");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TblCustomizationAvatar)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("Tbl_CustomizationAvatar_PlayerId_fkey");
            });

            modelBuilder.Entity<EncouragementMsgs>(entity =>
            {
                entity.HasKey(e => e.EncouragementMsgId);

                entity.ToTable("Tbl_EncouragementMsgs");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");
            });

            modelBuilder.Entity<GameLevel>(entity =>
            {
                entity.HasKey(e => e.GameLevelId);

                entity.ToTable("Tbl_GameLevel");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");
            });

            modelBuilder.Entity<HeartRateGrade>(entity =>
            {
                entity.HasKey(e => e.HeartRateScaleId);

                entity.ToTable("Tbl_HeartRateGrade");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.Property(e => e.MaxHeartRateScale).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.MinHeartRateScale).HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<MotivatedEatingActivity>(entity =>
            {
                entity.HasKey(e => e.MotivatedEatingActivityId);

                entity.ToTable("Tbl_MotivatedEatingActivity");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.TblMotivatedEatingActivity)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("Tbl_MotivatedEatingActivity_TypeId_fkey");
            });

            modelBuilder.Entity<MotivatedEatingActivityGrade>(entity =>
            {
                entity.HasKey(e => e.MotivatedEatingActivityGradeId);

                entity.ToTable("Tbl_MotivatedEatingActivityGrade");

                entity.Property(e => e.MotivatedEatingActivityGradeId).HasDefaultValueSql("nextval('\"Tbl_MotivatedEatingActivityGr_MotivatedEatingActivityGradeI_seq\"'::regclass)");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.Property(e => e.MaxScale).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Me).HasColumnName("ME");

                entity.Property(e => e.MinScale).HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<MotivatedEatingActivityHistory>(entity =>
            {
                entity.HasKey(e => e.MotivatedEatingActivityHistoryId);

                entity.ToTable("Tbl_MotivatedEatingActivityHistory");

                entity.Property(e => e.MotivatedEatingActivityHistoryId).HasDefaultValueSql("nextval('\"Tbl_MotivatedEatingActivityHi_MotivatedEatingActivityHistor_seq\"'::regclass)");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.Property(e => e.Points).HasColumnType("numeric(5, 2)");

                entity.HasOne(d => d.MotivatedEatingActivity)
                    .WithMany(p => p.TblMotivatedEatingActivityHistory)
                    .HasForeignKey(d => d.MotivatedEatingActivityId)
                    .HasConstraintName("Tbl_MotivatedEatingActivityHisto_MotivatedEatingActivityId_fkey");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TblMotivatedEatingActivityHistory)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("Tbl_MotivatedEatingActivityHistory_PlayerId_fkey");
            });

            modelBuilder.Entity<MotivatedEatingActivityOptions>(entity =>
            {
                entity.HasKey(e => e.MotivatedEatingActivityOptionsId);

                entity.ToTable("Tbl_MotivatedEatingActivityOptions");

                entity.Property(e => e.MotivatedEatingActivityOptionsId).HasDefaultValueSql("nextval('\"Tbl_MotivatedEatingActivityOp_MotivatedEatingActivityOption_seq\"'::regclass)");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.Property(e => e.Points).HasColumnType("numeric(5, 2)");

                entity.HasOne(d => d.MotivatedEatingActivity)
                    .WithMany(p => p.TblMotivatedEatingActivityOptions)
                    .HasForeignKey(d => d.MotivatedEatingActivityId)
                    .HasConstraintName("Tbl_MotivatedEatingActivityOptio_MotivatedEatingActivityId_fkey");
            });

            modelBuilder.Entity<NotificationMessages>(entity =>
            {
                entity.HasKey(e => e.NotificationMessageId);

                entity.ToTable("Tbl_NotificationMessage");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");
            });

            modelBuilder.Entity<PlayerAchievementInfo>(entity =>
            {
                entity.HasKey(e => e.AchievementInfoId);

                entity.ToTable("Tbl_PlayerAchievementInfo");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.HasOne(d => d.Achievement)
                    .WithMany(p => p.TblPlayerAchievementInfo)
                    .HasForeignKey(d => d.AchievementId)
                    .HasConstraintName("Tbl_PlayerAchievementInfo_AchievementId_fkey");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TblPlayerAchievementInfo)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("Tbl_PlayerAchievementInfo_PlayerId_fkey");
            });

            modelBuilder.Entity<PlayerDetails>(entity =>
            {
                entity.HasKey(e => e.PlayerDetailsId);

                entity.ToTable("Tbl_PlayerDetails");

                entity.Property(e => e.AverageBmr)
                    .HasColumnName("AverageBMR")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.AverageHeartRate).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.Property(e => e.TotalDistance).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.TotalStandingHours).HasColumnType("numeric(5, 2)");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TblPlayerDetails)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("Tbl_PlayerDetails_PlayerId_fkey");
            });

            modelBuilder.Entity<PlayerGameInfo>(entity =>
            {
                entity.HasKey(e => e.PlayerGameInfoId);

                entity.ToTable("Tbl_PlayerGameInfo");

                entity.Property(e => e.Bmr)
                    .HasColumnName("BMR")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.CompletionScalePercent).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Distance).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.HeartRate).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.Property(e => e.Rpescale)
                    .HasColumnName("RPEScale")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.StandingHours).HasColumnType("numeric(5, 2)");

                entity.HasOne(d => d.GameLevel)
                    .WithMany(p => p.TblPlayerGameInfo)
                    .HasForeignKey(d => d.GameLevelId)
                    .HasConstraintName("Tbl_PlayerGameInfo_GameLevelId_fkey");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TblPlayerGameInfo)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("Tbl_PlayerGameInfo_PlayerId_fkey");
            });

            modelBuilder.Entity<PlayerProfile>(entity =>
            {
                entity.HasKey(e => e.PlayerId);

                entity.ToTable("Tbl_PlayerProfile");

                entity.Property(e => e.BpOptional)
                    .HasColumnName("BP(optional)")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Height).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.Property(e => e.Weight).HasColumnType("numeric(5, 2)");
            });

            modelBuilder.Entity<PlayerQuestInfo>(entity =>
            {
                entity.HasKey(e => e.PlayerQuestInfoId);

                entity.ToTable("Tbl_PlayerQuestInfo");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TblPlayerQuestInfo)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("Tbl_PlayerQuestInfo_PlayerId_fkey");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.TblPlayerQuestInfo)
                    .HasForeignKey(d => d.QuestId)
                    .HasConstraintName("Tbl_PlayerQuestInfo_QuestId_fkey");
            });

            modelBuilder.Entity<PlayerShopInfo>(entity =>
            {
                entity.HasKey(e => e.PlayerShopInfoId);

                entity.ToTable("Tbl_PlayerShopInfo");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TblPlayerShopInfo)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("Tbl_PlayerShopInfo_PlayerId_fkey");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.TblPlayerShopInfo)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("Tbl_PlayerShopInfo_ShopId_fkey");
            });

            modelBuilder.Entity<PowerUps>(entity =>
            {
                entity.HasKey(e => e.PowerUpId);

                entity.ToTable("Tbl_PowerUps");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");
            });

            modelBuilder.Entity<Quests>(entity =>
            {
                entity.HasKey(e => e.QuestId);

                entity.ToTable("Tbl_Quests");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");
            });

            modelBuilder.Entity<ReinforcementMsgs>(entity =>
            {
                entity.HasKey(e => e.ReinforcementMsgid);

                entity.ToTable("Tbl_ReinforcementMsgs");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");
            });

            modelBuilder.Entity<Rpegrade>(entity =>
            {
                entity.HasKey(e => e.Rpeid);

                entity.ToTable("Tbl_RPEGrade");

                entity.Property(e => e.Rpeid).HasColumnName("RPEId");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.Property(e => e.MaxRpescale)
                    .HasColumnName("MaxRPEScale")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.MinRpescale)
                    .HasColumnName("MinRPEScale")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Rpeaction).HasColumnName("RPEAction");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.HasKey(e => e.SettingsId);

                entity.ToTable("Tbl_Settings");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.Property(e => e.IsGps).HasColumnName("IsGPS");

                entity.Property(e => e.IsSfx).HasColumnName("IsSFX");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.TblSettings)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("Tbl_Settings_PlayerId_fkey");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasKey(e => e.ShopId);

                entity.ToTable("Tbl_Shop");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");
            });

            modelBuilder.Entity<TargetPeakHrgrade>(entity =>
            {
                entity.HasKey(e => e.TargetPeakHrgradeId);

                entity.ToTable("Tbl_TargetPeakHRGrade");

                entity.Property(e => e.TargetPeakHrgradeId).HasColumnName("TargetPeakHRGradeId");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("false");

                entity.Property(e => e.MaxTargetPeakHrscale)
                    .HasColumnName("MaxTargetPeakHRScale")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.MinTargetPeakHrscale)
                    .HasColumnName("MinTargetPeakHRScale")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.TargetPeakHraction).HasColumnName("TargetPeakHRAction");
            });

            modelBuilder.Entity<BehavioralType>(entity =>
            {
                entity.HasKey(e => e.TypeId);

                entity.ToTable("Tbl_Type");
            });

            modelBuilder.HasSequence("Tbl_CurrentEatingActivityHist_CurrentEatingActivityHistoryI_seq");

            modelBuilder.HasSequence("Tbl_CurrentEatingActivityOpti_CurrentEatingAcivityOptionsId_seq");

            modelBuilder.HasSequence("Tbl_MotivatedEatingActivityGr_MotivatedEatingActivityGradeI_seq");

            modelBuilder.HasSequence("Tbl_MotivatedEatingActivityHi_MotivatedEatingActivityHistor_seq");

            modelBuilder.HasSequence("Tbl_MotivatedEatingActivityOp_MotivatedEatingActivityOption_seq");
        }
    }
}
