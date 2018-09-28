using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmrAbdelwahabCodingQuestion.Models
{
    public class Vertex
    {
        private int _iX;
        private int _iY;

        public Vertex(int iX, int iY)
        {
            this._iX = iX;
            this._iY = iY;
        }

        public int X
        {
            get
            {
                return this._iX;
            }
        }

        public int Y
        {
            get
            {
                return this._iY;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Vertex);
        }

        public bool Equals(Vertex other)
        {
            return other.X == this.X && other.Y == this.Y;
        }
    }
}