using System;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using BLL.Interfaces.Services;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        public static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolverConsole();
        }

        static void Main(string[] args)
        {
            var service = resolver.Get<IUserService>();
            var users = service.GetAllUserEntities().ToList();
            foreach (var user in users)
            {
                Console.WriteLine(user.Name+" "+user.Role.Name);
                foreach (var item in user.Lots)
                {
                    Console.WriteLine(" -"+item.Name);
                }
                foreach (var item in user.Bids)
                {
                    Console.WriteLine(" -" + item.Price);
                }

            }
            Console.ReadKey();
        }
    }
}
