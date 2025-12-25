using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.CoreLayer.Options
{
    public class ConnectionStringOption
    {
        //Güvenli Sql Connection Alma
        public const string Key = "ConnectionStrings";
        public string SqlServer { get; set; }
    }
}
