using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonComponents;
using static EnumerationTypeLayer.EnumerationTypes;
using EnumerationTypeLayer;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_HandlePropertyUC : UserControl, IPP_HandlePropertyUC
    {
        public PP_HandlePropertyUC()
        {
            InitializeComponent();
        }

        private void SetHandleTypeDatasource()
        {
            //cmb_HandleType.DataBindings.Clear();
            //List<Handle_Type> hType = new List<Handle_Type>();
            //if (Panel_SashProfileArtNo == SashProfile_ArticleNo._7581 ||
            //    Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
            //{
            //    hType.Add(Handle_Type._Rotoswing);
            //}

            //if (Frame_ArtNo == FrameProfile_ArticleNo._7507 &&
            //    Panel_SashProfileArtNo == SashProfile_ArticleNo._374)
            //{
            //    hType.Add(Handle_Type._Rio);
            //    hType.Add(Handle_Type._Rotoline);
            //    hType.Add(Handle_Type._MVD);
            //}

            //hType.Add(Handle_Type._Rotary);
            //cmb_HandleType.DataSource = hType;
        }

        private FrameProfile_ArticleNo _frameArtNO;
        public FrameProfile_ArticleNo Frame_ArtNo
        {
            get
            {
                return _frameArtNO;
            }

            set
            {
                _frameArtNO = value;
                SetHandleTypeDatasource();
            }
        }

        private SashProfile_ArticleNo _panelSashProfileArtNo;
        public SashProfile_ArticleNo Panel_SashProfileArtNo
        {
            get
            {
                return _panelSashProfileArtNo;
            }

            set
            {
                _panelSashProfileArtNo = value;
                SetHandleTypeDatasource();
            }
        }

        public event EventHandler PPHandlePropertyLoadEventRaised;
        public event EventHandler cmbHandleTypeSelectedValueEventRaised;

        private void PP_HandlePropertyUC_Load(object sender, EventArgs e)
        {
            List<Handle_Type> rio = new List<Handle_Type>();
            foreach (Handle_Type item in Handle_Type.GetAll())
            {
                rio.Add(item);
            }
            cmb_HandleType.DataSource = rio;

            EventHelpers.RaiseEvent(this, PPHandlePropertyLoadEventRaised, e);
        }

        private void cmb_HandleType_SelectedValueChanged(object sender, EventArgs e)
        {
            EventHelpers.RaiseEvent(sender, cmbHandleTypeSelectedValueEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_HandleType.DataBindings.Add(ModelBinding["Panel_HandleType"]);
            this.DataBindings.Add(ModelBinding["Panel_HandleOptionsVisibility"]);
            this.DataBindings.Add(ModelBinding["Panel_HandleOptionsHeight"]);
            this.DataBindings.Add(ModelBinding["Frame_ArtNo"]);
            this.DataBindings.Add(ModelBinding["Panel_SashProfileArtNo"]);
        }

        public Panel GetHandleTypePNL()
        {
            return pnl_HandleTypeOptions;
        }
    }
}
