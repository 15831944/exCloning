using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tekla.Structures;
using TSM = Tekla.Structures.Model;

namespace exCloning
{
    class TeklaHandler
    {
        public static List<_Assembly> getPartInfo()
        {
            List<_Assembly> parsedAssemblys = new List<_Assembly>();

            TSM.ModelObjectEnumerator selectedObjects = getSelectedObjects();
            List<TSM.Assembly> selectedAssemblys = getSelectedAssemblys(selectedObjects);

            foreach (TSM.Assembly currentPart in selectedAssemblys)
            {
                _Assembly parsed = new _Assembly(currentPart);
                parsedAssemblys.Add(parsed);
            }

            return parsedAssemblys;
        }

        private static TSM.ModelObjectEnumerator getSelectedObjects()
        {
            var selector = new TSM.UI.ModelObjectSelector();
            TSM.ModelObjectEnumerator selectionEnum = selector.GetSelectedObjects();

            return selectionEnum;
        }

        private static List<TSM.Assembly> getSelectedAssemblys(TSM.ModelObjectEnumerator selectedObjects)
        {
            List<TSM.Assembly> selectedAssemblys = new List<TSM.Assembly>();

            while (selectedObjects.MoveNext())
            {
                if (selectedObjects.Current is TSM.Assembly)
                {
                    TSM.Assembly assembly = selectedObjects.Current as TSM.Assembly;
                    selectedAssemblys.Add(assembly);
                }
            }

            return selectedAssemblys;
        }

        public static List<TSM.Reinforcement> getReinforcements(TSM.Part part)
        {
            List<TSM.Reinforcement> reinf = new List<TSM.Reinforcement>();
            TSM.ModelObjectEnumerator reinforcementEnum = part.GetReinforcements();

            while (reinforcementEnum.MoveNext())
            {
                reinf.Add(reinforcementEnum.Current as TSM.Reinforcement);
            }

            return reinf;
        }
    }
}