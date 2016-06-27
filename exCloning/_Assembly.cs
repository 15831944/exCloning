using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tekla.Structures;
using TSM = Tekla.Structures.Model;

namespace exCloning
{
    class _Assembly
    {
        public string _objClass;
        public TSM.Assembly _assembly;
        public TopInFormEnum _topInFrom;

        public _Assembly(TSM.Assembly assembly)
        {
            _assembly = assembly;
            _objClass = (assembly.GetMainPart() as TSM.Part).Class;

            TSM.Part mainPart = assembly.GetMainPart() as TSM.Part;
            _topInFrom = getTopInForm(mainPart);
        }

        private TopInFormEnum getTopInForm(TSM.Part part)
        {
            int topInForm = 6;
            part.GetUserProperty("FixedMainView", ref topInForm);
            TopInFormEnum value = (TopInFormEnum)topInForm;
            return value;
        }
    }
}
