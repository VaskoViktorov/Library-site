namespace Library.Web.Infrastructure.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using System.Linq;
    using System.Reflection;

    using static WebConstants;

    /// <summary>
    /// Service injector.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            Assembly
                .GetAssembly(typeof(IService))
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == string.Format(InterfaceName,t.Name)))
                .Select(t => new
                {
                    Interface = t.GetInterface(string.Format(InterfaceName, t.Name)),
                    Implementation = t
                })
                .ToList()
                .ForEach(s => services.AddTransient(s.Interface, s.Implementation));

            return services;
        }
    }
}