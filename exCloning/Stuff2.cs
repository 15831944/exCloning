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
    class Stuff2
    {
        public static void main(List<_Assembly> wrongAssemblys)
        {
            foreach (_Assembly currentAssembly in wrongAssemblys)
            {
                ArrayList parts = currentAssembly._assembly.GetSecondaries();
                TSM.Part mainPart = currentAssembly._assembly.GetMainPart() as TSM.Part;
                parts.Add(mainPart);

                foreach (TSM.Part currentPart in parts)
                {
                    swapHandler(currentPart);
                }

                swapTopInForm(mainPart);
            }
        }

        private static void swapHandler(TSM.Part part)
        {
            if (part is TSM.Beam)
            {
                TSM.Beam beam = part as TSM.Beam;
                swapBeam(beam);
            }
        }

        private static void swapTopInForm(TSM.Part part)
        {
            int topInForm = 6;
            part.GetUserProperty("FixedMainView", ref topInForm);

            if (part is TSM.Beam)
            {
                if (topInForm == (int)TopInFormEnum.FRONT)
                {
                    part.SetUserProperty("FixedMainView", (int)TopInFormEnum.BACK);
                }
                else if (topInForm == (int)TopInFormEnum.BACK)
                {
                    part.SetUserProperty("FixedMainView", (int)TopInFormEnum.FRONT);
                }
            }
        }

        private static void swapBeam(TSM.Beam beam)
        {
            List<TSM.Reinforcement> oldReinf = getReinforcements(beam);

            swapBeamHandles(beam);
            swapEndForces(beam);

            beam.Modify();
            new TSM.Model().CommitChanges();

            List<TSM.Reinforcement> newReinf = getReinforcements(beam);

            repositionReinforcement(oldReinf, newReinf);

            beam.Modify();
            new TSM.Model().CommitChanges();
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

        public static void swapBeamHandles(TSM.Beam beam)
        {
            T3D.Point startPoint = beam.StartPoint;
            T3D.Point endPoint = beam.EndPoint;
            beam.StartPoint = endPoint;
            beam.EndPoint = startPoint;

            if (beam.Position.Plane == TSM.Position.PlaneEnum.RIGHT)
            {
                beam.Position.Plane = TSM.Position.PlaneEnum.LEFT;
            }
            else if (beam.Position.Plane == TSM.Position.PlaneEnum.LEFT)
            {
                beam.Position.Plane = TSM.Position.PlaneEnum.RIGHT;
            }
        }


        public static void repositionReinforcement(List<TSM.Reinforcement> old, List<TSM.Reinforcement> news)
        {
            for (int i = 0; i < news.Count; i++)
            {
                for (int j = 0; j < old.Count; j++)
                {
                    if (news[i].Identifier.ID == old[j].Identifier.ID)
                    {
                        news[i] = old[j];
                        news[i].Modify();
                        break;
                    }
                }
            }
        }

        private static void swapEndForces(TSM.ModelObject part)
        {
            var originalEnd1 = string.Empty;
            var originalEnd2 = string.Empty;
            part.GetUserProperty("BM_FORCE1", ref originalEnd1);
            part.GetUserProperty("BM_FORCE2", ref originalEnd2);
            part.SetUserProperty("BM_FORCE1", originalEnd2);
            part.SetUserProperty("BM_FORCE2", originalEnd1);
        }
    }
}
