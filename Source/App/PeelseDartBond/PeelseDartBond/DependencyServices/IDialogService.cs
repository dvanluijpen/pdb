using System;
namespace PeelseDartBond.DependencyServices
{
    public interface IDialogService
    {
        void ShowProgressDialog(string message);
        void HideProgressDialog();
    }
}
