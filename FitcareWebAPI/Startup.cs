using FitcareWebAPI.IServices.InterfaceRepository;
using FitcareWebAPI.Model; 
using FitcareWebAPI.Model.Model.DB;
using FitcareWebAPI.Services.ServiceRepository; 
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace FitcareWebAPIModel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => {
                        options.TokenValidationParameters =
                             new TokenValidationParameters
                             {
                                 ValidateIssuer = true,
                                 ValidateAudience = true,
                                 ValidateLifetime = true,
                                 ValidateIssuerSigningKey = true,

                                 ValidIssuer = "Test.Security.Bearer",
                                 ValidAudience = "Test.Security.Bearer",
                                 IssuerSigningKey =
                                 Provider.JWT.JwtSecurityKey.Create("Test-secret-key-1234")
                             };

                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                                return Task.CompletedTask;
                            }
                        };

                    });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Employee",
                    policy => policy.RequireClaim("EmployeeNumber"));
                options.AddPolicy("Hr",
                    policy => policy.RequireClaim("EmployeeNumber"));
                options.AddPolicy("Founder",
                    policy => policy.RequireClaim("EmployeeNumber", "1","2","3","4","5"));
            });

            // Add framework services.IMotivatedEatingActivityGradesService 

            services.AddDbContext<FitCareDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("EFCoreDBFirstDemoDatabase")));
            services.AddTransient<IPlayerProfileService, PlayerProfileServiceService>();
            services.AddTransient<IAchievementsService, AchievementsService>();
            services.AddTransient<ICurrentEatingActivitiesService, CurrentEatingActivitiesService>();
            services.AddTransient<ICurrentEatingActivityGradesService, CurrentEatingActivityGradesService>();
            services.AddTransient<ICurrentEatingActivityHistoriesService, CurrentEatingActivityHistoriesService>();
            services.AddTransient<ICurrentEatingActivityOptionsService, CurrentEatingActivityOptionsService>();
            services.AddTransient<ICustomizationAvatarsService, CustomizationAvatarsService>();
            services.AddTransient<IGameLevelsService, GameLevelsService>();
            services.AddTransient<IMotivatedEatingActivitiesService, MotivatedEatingActivitiesService>();
            services.AddTransient<IMotivatedEatingActivityGradesService, MotivatedEatingActivityGradesService>();
            services.AddTransient<IMotivatedEatingActivityHistoriesService, MotivatedEatingActivityHistoriesService>();
            services.AddTransient<IMotivatedEatingActivityOptionsService, MotivatedEatingActivityOptionsService>();
            services.AddTransient<INotificationMessagesService, NotificationMessagesService>();
            services.AddTransient<IPlayerAchievementInfoesService, PlayerAchievementInfoesService>();
            services.AddTransient<IPlayerDetailsService, PlayerDetailsService>();
            services.AddTransient<IPlayerGameInfoesService, PlayerGameInfoesService>();
            services.AddTransient<IPlayerQuestInfoesService, PlayerQuestInfoesService>();
            services.AddTransient<IPlayerShopInfoesService, PlayerShopInfoesService>();
            services.AddTransient<IPowerUpsService, PowerUpsService>();
            services.AddTransient<IQuestsService, QuestsService>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IShopsService, ShopsService>();
            services.AddTransient<IRpegradeService, RpegradeService>();
            services.AddTransient<IReinforcementMsgsService, ReinforcementMsgsService>();
            services.AddTransient<ICompletionGradesService, CompletionGradesService>();
            services.AddTransient<ICriterionPeriodsService, CriterionPeriodsService>();
            services.AddTransient<IBehavioralTypesService, BehavioralTypesService>();
            services.AddTransient<IHeartRateGradeService, HeartRateGradeService>();
            services.AddTransient<IEncouragementMsgsService, EncouragementMsgsService>();



            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();
            
        }
    }
}
