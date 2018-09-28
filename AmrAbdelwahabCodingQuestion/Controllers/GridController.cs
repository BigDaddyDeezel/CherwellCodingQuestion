using AmrAbdelwahabCodingQuestion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AmrAbdelwahabCodingQuestion.Controllers
{
     [RoutePrefix("api/Grid")]
    public class GridController : ApiController
    {
        const int iNumRows = 6;
        const int iNumCols = 6;
        const int iNonHypLen = 10;
        char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        List<IsoscelesRightTriangle> lstIRT = new List<IsoscelesRightTriangle>();

        private void InitializeTriangleGrid()
        {            
            for (int y = 0, row = 0; y < iNumRows * iNonHypLen; y += iNonHypLen, row++)
            {
                for (int x = 0, col = 1; x < iNumCols * iNonHypLen; x += iNonHypLen)
                {
                    // Add first triangle (odd column)
                    Vertex[] vertices = new Vertex[3];
                    vertices[0] = new Vertex(x, y);
                    vertices[1] = new Vertex(x, y + iNonHypLen);
                    vertices[2] = new Vertex(x + iNonHypLen, y + iNonHypLen);
                    lstIRT.Add(new IsoscelesRightTriangle(vertices, string.Format("{0}{1}", alpha[row], col++)));

                    // Add second triangle (even column)
                    vertices = new Vertex[3];
                    vertices[0] = new Vertex(x, y);
                    vertices[1] = new Vertex(x + iNonHypLen, y + iNonHypLen);
                    vertices[2] = new Vertex(x + iNonHypLen, y);
                    lstIRT.Add(new IsoscelesRightTriangle(vertices, string.Format("{0}{1}", alpha[row], col++)));
                }
            }
        }

        [Route("GetTriangleByLabel")]
        public Vertex[] GetTriangleByLabel(string Label)
        {
            string UCLabel = Label.ToUpper().Trim();

            this.InitializeTriangleGrid();

            Vertex[] verts = null;

            var triangles = from triangle in lstIRT
                            where triangle.Label == UCLabel
                            select triangle;

            if (triangles.Count() == 1)
            {
                IsoscelesRightTriangle irt = triangles.ToArray()[0];
                verts = irt.Vertices;
            }

            return verts;
        }

        [Route("GetTriangleByVertices")]
        public string GetTriangleByVertices(int x1, int y1, int x2, int y2, int x3, int y3)
        {            
            this.InitializeTriangleGrid();

            Vertex v1 = new Vertex(x1, y1);
            Vertex v2 = new Vertex(x2, y2);
            Vertex v3 = new Vertex(x3, y3);
            string Label = string.Empty;

            var triangles = from triangle in lstIRT
                            where triangle.Vertices.Contains(v1) && triangle.Vertices.Contains(v2) && triangle.Vertices.Contains(v3)
                            select triangle;

            if (triangles.Count() == 1)
            {
                IsoscelesRightTriangle irt = triangles.ToArray()[0];
                Label = irt.Label;
            }

            return Label;
        }   
    }
}
