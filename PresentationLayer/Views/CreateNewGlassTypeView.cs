using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class CreateNewGlassTypeView : Form, ICreateNewGlassTypeView
    {
        public CreateNewGlassTypeView()
        {
            InitializeComponent();
        }


        public void ShowThis()
        {
            this.Show();
        }

        public void CloseThis()
        {
            this.Hide();
        }

    }
}
