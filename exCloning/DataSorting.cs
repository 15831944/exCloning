using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exCloning
{
    class DataSorting
    {
        public static string main(List<_Assembly> data)
        {
            StringBuilder report = new StringBuilder();
            List<string> nameFilter = new List<string>();

            var DistinctItems = data.GroupBy(x => x._objClass).Select(y => y.First());
            foreach (_Assembly item in DistinctItems)
            {
                nameFilter.Add(item._objClass);
            }

            foreach (string objClass in nameFilter)
            {
                report.AppendLine("CLASS:" + objClass);

                foreach (TopInFormEnum status in Enum.GetValues(typeof(TopInFormEnum)))
                {
                    string count = data.
                        Where(x => x._objClass == objClass).ToList().
                        Where(y => y._topInFrom == status).
                        ToList().Count.ToString();

                    report.AppendLine(" - " + status.ToString() + ": " + count);
                }
                report.AppendLine("");
            }

            return report.ToString();
        }
    }
}
