using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parse
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlQueryCreator sq = new SqlQueryCreator();
            sq.PathErrorLog = "D:\\ErrorLog.csv";
            sq.PathSnilsLog = "D:\\SnilsLog.csv";
            var res = sq.CreateQuerySQL();
        }
    }
}
