using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Parse
{
    class SqlQueryCreator
    {
        public string PathErrorLog { get; set; }

        public string PathSnilsLog { get; set; }

        private ICollection<string> GetErrorsSNILS()
        {
            ICollection<string> result = new List<string>();
            ICollection<string> linesErr = new List<string>();
            ICollection<string> lineSnl = new List<string>();
            linesErr = File.ReadAllLines(PathErrorLog);
            lineSnl = File.ReadAllLines(PathSnilsLog);
            foreach (var s in linesErr)
            {
                List<string> list = new List<string>();
                list = s.Split(';').Where(ss => ss.Equals(ss)).ToList();
                foreach(var sl in lineSnl)
                {
                    List<string> listn = new List<string>();
                    listn = sl.Split(';').Where(q => q.Equals(q)).ToList();
                    if (listn.Contains(list.FirstOrDefault()))
                    {
                        result.Add(listn.ElementAt(1));
                        if(listn.ElementAt(1).Equals(listn.ElementAt(2)))
                        {
                            result.Add(listn.ElementAt(2));
                        }
                    }
                }
            }
            return result.Distinct().ToList();
        }

        public string CreateQuerySQL()
        {
            List<string> list = new List<string>();
            list = GetErrorsSNILS().ToList();
            string result = "SELECT NPS FROM F2 WHERE NPS = '";
            foreach(var r in list)
            {
                result += r + "' OR NPS = '";
            }
            return result;
        }
    }
}
