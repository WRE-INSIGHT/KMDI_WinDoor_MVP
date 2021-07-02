using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class CreateNewGlassSpacerView : Form, ICreateNewGlassSpacerView
    {
        public CreateNewGlassSpacerView()
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
