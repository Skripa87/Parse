using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Parse
{
    class SqlQueryCreator
    {
        public string InputFilePath { get; set; }

        private string GetFioCod()
        {
            string result = "SELECT ID FROM F2 WHERE ";
            var linesStrFioCode = File.ReadAllLines(InputFilePath);
            foreach (var s in linesStrFioCode)
            {
                if (s == "" || s == null)
                    break;
                else
                {
                    List<string> list = new List<string>();
                    list = s.Split(';').Where(ss => ss.Equals(ss)).ToList();
                    result += "(Famil = '" + list[0] + "' AND IMJA = '" + list[1] + "' AND OTCH = '" + list[2] + "' AND DROG = '" + list[3] + "') OR ";
                }
            }
            return result + " (Famil = 'XXXXXX' AND IMJA = 'XXXXX' AND OTCH = 'XXXXXX')";
        }

        private string CreateInsertSqlQuery(string codePU)
        {
            string result = "", str = "Insert into f1 (f2_id, isu, datisun, pr, datpkor, notice, pr2) ";
            var lineStrFioCode = File.ReadAllLines(InputFilePath);
            foreach(var s in lineStrFioCode)
            {
                result += str + " \n values ('" + s + "' , '"+ codePU + "' , '01.01.2015', '', '01.01.2015', '', 'Р')" + "\n";
            }
            return result;
        }

        public string CreateFirstQuerySQL()
        {
            return GetFioCod();
        }

        public string CreateSecondQuerySQL(string codePU)
        {
            return CreateInsertSqlQuery(codePU);
        }
    }
}
