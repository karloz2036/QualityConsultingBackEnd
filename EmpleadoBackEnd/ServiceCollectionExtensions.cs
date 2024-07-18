using ExamenData.Class;
using ExamenData.Interfaces;

namespace ExamenBackEnd
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataEmpleado, DataEmpleado>();
            services.AddSingleton<IDataPuesto, DataPuesto>();
            services.AddSingleton<IDataEstado, DataEstado>();
            return services;
        }
    }
}
