using Claims_Mgmt_Backend.Repository;

namespace Claims_Mgmt_Backend.Helpers
{
    public static class RegisterServices
    {
        public static IServiceCollection RegisterService(this IServiceCollection services)
        {
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IClaimRepository, ClaimRepository>();
            return services;
        }
    }
}
