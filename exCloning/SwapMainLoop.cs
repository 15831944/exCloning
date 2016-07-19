using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using Tekla.Structures;
using TSM = Tekla.Structures.Model;
using T3D = Tekla.Structures.Geometry3d;

namespace exCloning
{
    class SwapMainLoop
    {
        public static void main(List<_Assembly> wrongAssemblys)
        {
            foreach (_Assembly currentAssembly in wrongAssemblys)
            {
                ArrayList parts = new ArrayList();
                parts = currentAssembly._assembly.GetSecondaries();
                TSM.Part mainPart = currentAssembly._assembly.GetMainPart() as TSM.Part;
                parts.Add(mainPart);

                foreach (TSM.Part currentPart in parts)
                {
                    SwapHandler.main(currentPart);
                }
            }

            new TSM.Model().CommitChanges();
        }

    }
}
