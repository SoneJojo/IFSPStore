using AutoMapper;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Repository.Context;
using IFSPStore.Repository.Repository;
using IFSPStore.Service.Service;
using IFSPStore.Service.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Abstractions;
using System.Text.Json;

namespace IFSPStore.Test
{
    [TestClass]
    public class ServiceTest
    {
        private ServiceCollection _services;

        public ServiceProvider ConfigureServices()
        {
            _services = new ServiceCollection();
            _services.AddDbContext<IFSPStoreContext>();
            _services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            _services.AddScoped<IBaseService<User>, BaseService<User>>();
            _services.AddSingleton(new MapperConfiguration(c => { c.CreateMap<User, User>(); }, NullLoggerFactory.Instance).CreateMapper());
            return _services.BuildServiceProvider();
        }

       

        [TestMethod]
        public void TestUserService()
        {
            var serviceProvider = ConfigureServices();
            var userService = serviceProvider.GetService<IBaseService<User>>();

            var user = new User
            {
                Name = "Maria",
                Login = "_maria",
                Email = "maria@gmail.com",
                Password = "maRia123!",
                RegisterDate = DateTime.Now,
                LoginDate = DateTime.Now,
                IsActive = true
            };

            var result = userService.Add<User, User, UserValidator>(user);
            Console.WriteLine(JsonSerializer.Serialize(result));
        }
    }
}
