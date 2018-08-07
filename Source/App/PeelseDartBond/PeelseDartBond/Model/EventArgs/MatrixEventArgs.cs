using System;
using System.Collections.Generic;
using PeelseDartBond.Model.Entities;

namespace PeelseDartBond.Model.EventArgs
{
    public class MatrixEventArgs : System.EventArgs
    {
        readonly List<MatrixRow> _matrix;

        public MatrixEventArgs(List<MatrixRow> matrix) : base()
        {
            _matrix = matrix;
        }

        public List<MatrixRow> Matrix { get { return _matrix; } }
    }
}
