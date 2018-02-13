using System;
using System.Collections.Generic;
using System.IO;
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
            sq.InputFilePath = args[0];
            string res = "";
            if (args[1] == "1")
            {
                res = sq.CreateFirstQuerySQL();
            }
            else if(args[1] == "2")
            {
                res = sq.CreateSecondQuerySQL(args[2]);
            }
            File.WriteAllText("result.txt",res);
        }
    }
}
