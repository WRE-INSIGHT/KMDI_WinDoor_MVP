using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public interface IExplosionView
    {
        event EventHandler ExplosionViewLoadEventRaised;

        DataGridView Get_DgvExplosionMaterialList();
        void ShowThisDialog();
    }
}