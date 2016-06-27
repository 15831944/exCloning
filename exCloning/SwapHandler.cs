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
    class SwapHandler
    {
        public static void main(TSM.Part part)
        {
            List<TSM.Reinforcement> oldReinf = TeklaHandler.getReinforcements(part);

            if (part is TSM.Beam)
            {
                TSM.Beam beam = part as TSM.Beam;
                SwapHandler.swapBeam(beam);
            }
            else if (part is TSM.PolyBeam)
            {
                TSM.PolyBeam polybeam = part as TSM.PolyBeam;
                SwapHandler.swapContour(polybeam);
            }
            else if (part is TSM.ContourPlate)
            {
                TSM.ContourPlate plate = part as TSM.ContourPlate;
                SwapHandler.swapContour(plate);
            }

            part.Modify();

            swapEndForces(part);
            swapOffsetPlanes(part);
            swapTopInForm(part);

            part.Modify();

            List<TSM.Reinforcement> newReinf = TeklaHandler.getReinforcements(part);
            restoreReinforcement(oldReinf, newReinf);

            new TSM.Model().CommitChanges();
        }

        private static void swapBeam(TSM.Beam part)
        {
            T3D.Point startPoint = part.StartPoint;
            T3D.Point endPoint = part.EndPoint;
            part.StartPoint = endPoint;
            part.EndPoint = startPoint;
        }

        private static void swapContour(TSM.PolyBeam part)
        {
            ArrayList points = part.Contour.ContourPoints;
            points.Reverse();
            part.Contour.ContourPoints = points;
        }

        private static void swapContour(TSM.ContourPlate part)
        {
            ArrayList points = part.Contour.ContourPoints;
            points.Reverse();
            part.Contour.ContourPoints = points;
        }

        private static void swapOffsetPlanes(TSM.Part part)
        {
            if (part is TSM.ContourPlate)
            {
                if (part.Position.Depth == TSM.Position.DepthEnum.BEHIND)
                {
                    part.Position.Depth = TSM.Position.DepthEnum.FRONT;
                }
                else if (part.Position.Depth == TSM.Position.DepthEnum.FRONT)
                {
                    part.Position.Depth = TSM.Position.DepthEnum.BEHIND;
                }
            }
            else
            {
                if (part.Position.Plane == TSM.Position.PlaneEnum.RIGHT)
                {
                    part.Position.Plane = TSM.Position.PlaneEnum.LEFT;
                }
                else if (part.Position.Plane == TSM.Position.PlaneEnum.LEFT)
                {
                    part.Position.Plane = TSM.Position.PlaneEnum.RIGHT;
                }
                if (part.Position.Plane == TSM.Position.PlaneEnum.MIDDLE)
                {
                    part.Position.PlaneOffset = -part.Position.PlaneOffset;
                }

                if (part.Position.RotationOffset != 0)
                {
                    part.Position.RotationOffset = -part.Position.RotationOffset;
                }
            }
        }

        private static void restoreReinforcement(List<TSM.Reinforcement> old, List<TSM.Reinforcement> news)
        {
            for (int i = 0; i < news.Count; i++)
            {
                for (int j = 0; j < old.Count; j++)
                {
                    if (news[i].Identifier.ID == old[j].Identifier.ID)
                    {
                        news[i] = old[j];
                        news[i].Modify();
                        old.RemoveAt(j);
                        break;
                    }
                }
            }
        }

        private static void swapTopInForm(TSM.Part part)
        {
            int topInForm = 6;
            part.GetUserProperty("FixedMainView", ref topInForm);

            if (topInForm == (int)TopInFormEnum.FRONT)
            {
                part.SetUserProperty("FixedMainView", (int)TopInFormEnum.BACK);
            }
            else if (topInForm == (int)TopInFormEnum.BACK)
            {
                part.SetUserProperty("FixedMainView", (int)TopInFormEnum.FRONT);
            }
            else if (topInForm == (int)TopInFormEnum.START)
            {
                part.SetUserProperty("FixedMainView", (int)TopInFormEnum.END);
            }
            else if (topInForm == (int)TopInFormEnum.END)
            {
                part.SetUserProperty("FixedMainView", (int)TopInFormEnum.START);
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
