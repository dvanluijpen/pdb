using System;
using System.Collections.Generic;

namespace PeelseDartBond.Model.Entities
{
    public class MatrixRow : BaseEntity
    {
        public int _rowNumber;
        public List<string> _columns;

        public MatrixRow()
        {
            Columns = new List<string>();
        }

        public int RowNumber
        {
            get { return _rowNumber; }
            set { SetProperty(ref _rowNumber, value); }
        }

        public List<string> Columns
        {
            get { return _columns; }
            set { SetProperty(ref _columns, value); }
        }
    }
}
