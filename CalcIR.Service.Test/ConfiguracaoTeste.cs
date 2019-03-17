using CalcIR.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CalcIR.Service.Test
{
    public class ConfiguracaoTeste
    {
        private static CalcIRContext Context { get; set; }

        public static CalcIRContext ObterContexto()
        {
            if (Context == null)
            {
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);

                var root = configurationBuilder.Build();
                string defaultConnection = root.GetConnectionString("DefaultConnection");

                var contextOptions = new DbContextOptionsBuilder<CalcIRContext>();
                contextOptions.UseSqlServer(defaultConnection);

                Context = new CalcIRContext(contextOptions.Options);
            }

            return Context;
        }
    }
}
