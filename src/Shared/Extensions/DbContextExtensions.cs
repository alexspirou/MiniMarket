using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Extensions;
public static class DbContextExtension
{
    public static IServiceCollection AddDbContextCommon<T>(this IServiceCollection services, IConfiguration configuration)
       where T : DbContext
    {
        var connectionString = configuration.GetConnectionString("MiniMarketDb");
        services.AddDbContext<T>(options => options.UseSqlServer(connectionString));
        return services;
    }

}

