using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmrAbdelwahabCodingQuestion.Models
{
    public class IsoscelesRightTriangle
    {
        private Vertex[] _vertices;
        private string _strLabel;

        public IsoscelesRightTriangle(Vertex[] vertices, string strLabel)
        {
            this._vertices = vertices;
            this._strLabel = strLabel;
        }

        public string Label
        {
            get
            {
                return this._strLabel;
            }
        }

        public Vertex[] Vertices
        {
            get
            {
                return this._vertices;
            }
        }
    }
}