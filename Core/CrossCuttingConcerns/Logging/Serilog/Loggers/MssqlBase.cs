using Serilog.Sinks.MSSqlServer;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class MssqlLogger : LoggerServiceBase
    {
        //public MssqlLogger()
        //{

        //}
        public MssqlLogger()
        {
            //MssqlConfiguration logConfiguration = configuration.GetSection("SerilogConfigurations:MssqlConfiguration")
            //    .Get<MssqlConfiguration>() ?? throw new Exception("");
            MSSqlServerSinkOptions sinkOptions = new()
            { TableName = "Logs", AutoCreateSqlTable = true };

            ColumnOptions columnOptions = new();
            global::Serilog.Core.Logger serilogConfig = new LoggerConfiguration().WriteTo
                .MSSqlServer("Server=EBGAZ;Database=TobetoDotNet3ADB;Trusted_Connection=true;TrustServerCertificate =true", sinkOptions, columnOptions: columnOptions).CreateLogger();
            Logger = serilogConfig;


        }
    }
}
