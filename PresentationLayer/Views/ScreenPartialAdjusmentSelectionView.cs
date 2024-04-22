using CommonComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class ScreenPartialAdjusmentSelectionView : Form, IScreenPartialAdjusmentSelectionView
    {
        public ScreenPartialAdjusmentSelectionView()
        {
            InitializeComponent();
        }

        public void ShowPartialAdjustmentSelectionView()
        {
            this.ShowDialog();
        }

        public void ClosePartialAdjustmentSelecionView()
        {
            this.Close();
        }

        public CheckedListBox GetCheckListBox()
        {
            return chklst_itemList;
        }

        public Button GetAddToListButton()
        {
            return btn_addToList;
        }

        public event EventHandler btn_addToList_ClickEventRaised;
        public event EventHandler ScreenPartialAdjusmentSelectionView_LoadEventRaised;

        private void btn_addToList_Click(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, btn_addToList_ClickEventRaised, e);
        }

        private void ScreenPartialAdjusmentSelectionView_Load(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, ScreenPartialAdjusmentSelectionView_LoadEventRaised, e);
        }
    }
}
