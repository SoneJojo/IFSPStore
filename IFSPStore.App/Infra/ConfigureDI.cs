using IFSPStore.App.Register;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Repository.Context;
using IFSPStore.Repository.Repository;
using IFSPStore.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;

namespace IFSPStore.App.Infra
{
    public static class ConfigureDI
    {
        public static ServiceCollection services;
        public static IcmpV4Statistics? serviceProvider;

        public static void ConfigureServices()
        {
            //Database Config
            var DBConfigFile = "Config/DbConfig.txt";
            var strCon = File.ReadAllText(DBConfigFile); //Config do copiar se for mais novo em dbconfig.txt
            services = new ServiceCollection();
            services.AddDbContext<IFSPStoreContext>(options =>
            {
                options.LogTo(Console.WriteLine);
                options.UseMySQL(strCon);
            });
            services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
            services.AddScoped<IBaseService<Category>, BaseService<Category>>();
            services.AddScoped<CategoryForm, CategoryForm>();
            serviceProvider = services.BuildServiceProvider();
        }
    }
}
