using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;
using CommonComponents;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_EspagnolettePropertyUC : UserControl, IPP_EspagnolettePropertyUC
    {
        public PP_EspagnolettePropertyUC()
        {
            InitializeComponent();
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
                cmb_Espagnolette.Refresh();
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
                cmb_Espagnolette.Refresh();
            }
        }

        public event EventHandler PPEspagnolettePropertyLoadEventRaised;
        public event EventHandler cmbEspagnoletteSelectedValueEventRaised;

        private bool _initialLoad = true;

        private void PP_EspagnolettePropertyUC_Load(object sender, EventArgs e)
        {
            List<Espagnolette_ArticleNo> espArtNo = new List<Espagnolette_ArticleNo>();
            foreach (Espagnolette_ArticleNo item in Espagnolette_ArticleNo.GetAll())
            {
                espArtNo.Add(item);
            }
            cmb_Espagnolette.DataSource = espArtNo;

            EventHelpers.RaiseEvent(this, PPEspagnolettePropertyLoadEventRaised, e);

            _initialLoad = false;
        }

        private void cmb_Espagnolette_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                Espagnolette_ArticleNo espag = (Espagnolette_ArticleNo)((ComboBox)sender).SelectedValue;

                if (espag == Espagnolette_ArticleNo._741012 || espag == Espagnolette_ArticleNo._EQ87NT ||
                    espag == Espagnolette_ArticleNo._628806 || espag == Espagnolette_ArticleNo._628807 ||
                    espag == Espagnolette_ArticleNo._628809)
                {
                    if (!(Frame_ArtNo == FrameProfile_ArticleNo._7502 && Panel_SashProfileArtNo == SashProfile_ArticleNo._7581) &&
                        !(Frame_ArtNo == FrameProfile_ArticleNo._7507 && Panel_SashProfileArtNo == SashProfile_ArticleNo._7581))
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", "Espagnolette Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (espag == Espagnolette_ArticleNo._642105 || espag == Espagnolette_ArticleNo._642089 ||
                     espag == Espagnolette_ArticleNo._630963)
                {
                    if (!(Frame_ArtNo == FrameProfile_ArticleNo._7507 && 
                        (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                         Panel_SashProfileArtNo == SashProfile_ArticleNo._373)))
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", "Espagnolette Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (espag == Espagnolette_ArticleNo._N110A00006 || espag == Espagnolette_ArticleNo._N110A01006 ||
                         espag == Espagnolette_ArticleNo._N110A02206 || espag == Espagnolette_ArticleNo._N110A03206 ||
                         espag == Espagnolette_ArticleNo._N110A04206 || espag == Espagnolette_ArticleNo._N110A05206 ||
                         espag == Espagnolette_ArticleNo._N110A06206)
                {
                    if (!(Frame_ArtNo == FrameProfile_ArticleNo._7507 && Panel_SashProfileArtNo == SashProfile_ArticleNo._395))
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", "Espagnolette Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            EventHelpers.RaiseEvent(sender, cmbEspagnoletteSelectedValueEventRaised, e);
        }

        public void ThisBinding(Dictionary<string, Binding> ModelBinding)
        {
            cmb_Espagnolette.DataBindings.Add(ModelBinding["Panel_EspagnoletteArtNo"]);
            this.DataBindings.Add(ModelBinding["Panel_EspagnoletteOptionsVisibility"]);
            this.DataBindings.Add(ModelBinding["Frame_ArtNo"]);
            this.DataBindings.Add(ModelBinding["Panel_SashProfileArtNo"]);
        }

        private void cmb_Espagnolette_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background 
            e.DrawBackground();

            // Get the item text    
            string text = ((ComboBox)sender).Items[e.Index].ToString();
            Espagnolette_ArticleNo espag = (Espagnolette_ArticleNo)((ComboBox)sender).Items[e.Index];

            if (espag == Espagnolette_ArticleNo._741012 || espag == Espagnolette_ArticleNo._EQ87NT || 
                espag == Espagnolette_ArticleNo._628806 || espag == Espagnolette_ArticleNo._628807 ||
                espag == Espagnolette_ArticleNo._628809)
            {
                if ((Frame_ArtNo == FrameProfile_ArticleNo._7502 && Panel_SashProfileArtNo == SashProfile_ArticleNo._7581) ||
                    (Frame_ArtNo == FrameProfile_ArticleNo._7507 && Panel_SashProfileArtNo == SashProfile_ArticleNo._7581))
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
            }
            else if (espag == Espagnolette_ArticleNo._642105 || espag == Espagnolette_ArticleNo._642089 ||
                     espag == Espagnolette_ArticleNo._630963)
            {
                if (Frame_ArtNo == FrameProfile_ArticleNo._7507 && 
                    (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                     Panel_SashProfileArtNo == SashProfile_ArticleNo._373))
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
            }
            else if (espag == Espagnolette_ArticleNo._N110A00006 || espag == Espagnolette_ArticleNo._N110A01006 ||
                     espag == Espagnolette_ArticleNo._N110A02206 || espag == Espagnolette_ArticleNo._N110A03206 ||
                     espag == Espagnolette_ArticleNo._N110A04206 || espag == Espagnolette_ArticleNo._N110A05206 ||
                     espag == Espagnolette_ArticleNo._N110A06206)
            {
                if (Frame_ArtNo == FrameProfile_ArticleNo._7507 && Panel_SashProfileArtNo == SashProfile_ArticleNo._395)
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
            }
            else
            {
                e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
            }
        }
    }
}
