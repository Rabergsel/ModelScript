using ModelScript.Graphs.Graph2D;
using ModelScript.Graphs.Utilities.Gradients;
using ModelScript.Maths.Numeric.Matrices;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Graphs.SimuGraphs
{
    public class FieldGraph : SimulationGraphBase
    {

        public int matrixHeight = 10;
        public int matrixWidth = 10;

        public string plane = "XY";

        private MatrixGraph matrixgraph = new MatrixGraph(new Maths.Numeric.Matrices.Matrix(1, 1), new BWGradient(128));
        public GradientBase gradient = new BWGradient(100);

        public string attribute = "";

        public override void render(int width, int height, ref SKCanvas canvas)
        {
            var matrix = new Matrix(matrixWidth + 1, matrixHeight + 1);
            evaluateParticleBoundaries();
            var space = maxPoint - minPoint;

            float matrixwidth = 10f;
            float matrixheight = 10f;

            if (plane[0] == 'X') matrixwidth = space.x / matrixWidth;
            if (plane[0] == 'Y') matrixwidth = space.y / matrixWidth;
            if (plane[0] == 'Z') matrixwidth = space.z / matrixWidth;

            if (plane[1] == 'X') matrixheight = space.x / matrixHeight;
            if (plane[1] == 'Y') matrixheight = space.y / matrixHeight;
            if (plane[1] == 'Z') matrixheight = space.z / matrixHeight;

            for(int x = 0; x <  matrixWidth; x++)
            {
                for(int y = 0; y < matrixHeight; y++)
                {

                    foreach(var p in particleList)
                    {
                        int val1 = 0;
                        int val2 = 0;

                        if (plane[0] == 'X') val1 = (int)((p.position.x - minPoint.x) / matrixwidth);
                        if (plane[0] == 'Y') val1 = (int)((p.position.y - minPoint.y) / matrixwidth);
                        if (plane[0] == 'Z') val1 = (int)((p.position.z - minPoint.z) / matrixwidth);

                        if (plane[1] == 'X') val2 = matrixHeight - (int)((p.position.x - minPoint.x) / matrixheight);
                        if (plane[1] == 'Y') val2 = matrixHeight - (int)((p.position.y - minPoint.y) / matrixheight);
                        if (plane[1] == 'Z') val2 = matrixHeight - (int)((p.position.z - minPoint.z) / matrixheight);

                        


                       //     Console.WriteLine("Particle @ {0} got index ({1}|{2})\t#part at that index is {3}", p.position, val1, val2, matrix.getValue(val1, val2));


                            if (attribute == "") matrix.setValue(val1, val2, matrix.getValue(val1, val2) + 1);
                          else matrix.setValue(val1, val2, matrix.getValue(val1, val2) + p.attributes[attribute]);
                        


                    }

                }
            }
            matrixgraph.values = matrix;
            matrixgraph.gradient = gradient;



            matrixgraph.render(width, height, ref canvas);


        }



    }
}
