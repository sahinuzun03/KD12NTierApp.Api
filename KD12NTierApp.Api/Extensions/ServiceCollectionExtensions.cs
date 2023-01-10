using KD12NTierApp.Bussiness.Abstract;
using KD12NTierApp.Bussiness.Concrete;
using KD12NTierApp.DataAccess.Abstract;
using KD12NTierApp.DataAccess.EntityFramework.Concrete;

namespace KD12NTierApp.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void Scope(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();


            //Dependency Injection(DI) ifade eder / Inversion of Control (IoC)
            //AddSingelton --> Proje başladığı andan itibaren 1 tane nesne oluşturulur.Bütün kullanıcılar bu nesneyi kullanır.
            //AddScoper --> Her gelen request için 1 tane nesne oluşturur
            //AddTransient --> Her seferinde yeni bir nesne oluşturup kullanır.
        }
    }
}
