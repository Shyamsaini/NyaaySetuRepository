using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyaaySetu.Data.Context
{
    public class DbContext
    {
        public ConnectionStringOptions ConnectionStringOptions;
        public DbContext(IOptionsMonitor<ConnectionStringOptions> optionMonitor)
        {
            ConnectionStringOptions = optionMonitor.CurrentValue;
        }
        public IDbConnection CreateConnection() => new SqlConnection(ConnectionStringOptions.SqlConnection);
    }
}
