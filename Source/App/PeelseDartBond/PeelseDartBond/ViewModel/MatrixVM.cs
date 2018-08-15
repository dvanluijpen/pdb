using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PeelseDartBond.Model;
using PeelseDartBond.Model.Entities;
using PeelseDartBond.Model.EventArgs;
using PeelseDartBond.Services;

namespace PeelseDartBond.ViewModel
{
    public class MatrixVM : BaseRefreshViewModel
    {
        List<MatrixRow> _matrix;

        public MatrixVM() : base()
        {
            Matrix = new List<MatrixRow>();

            PdbService.MatrixLoaded += MatrixLoaded;
        }

        public List<MatrixRow> Matrix
        {
            get { return _matrix; }
            set { SetProperty(ref _matrix, value); }
        }

        void MatrixLoaded(object sender, MatrixEventArgs e)
        {
            Matrix = e.Matrix;   
        }

        public async override Task Load()
        {
            if(PdbService.Matrix == null)
            {
                await PdbService.GetMatrixAsync();
            }
            else
            {
                Matrix = PdbService.Matrix;
            }
        }
    }
}
