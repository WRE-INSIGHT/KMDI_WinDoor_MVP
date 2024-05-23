using CommonComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static EnumerationTypeLayer.EnumerationTypes;

namespace PresentationLayer.Views.UserControls.PanelProperties_Modules
{
    public partial class PP_HandlePropertyUC : UserControl, IPP_HandlePropertyUC
    {
        public PP_HandlePropertyUC()
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
                cmb_HandleType.Refresh();
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
                cmb_HandleType.Refresh();
            }
        }

        public string ProfileType_FromMainPresenter { get; set; }

        public event EventHandler PPHandlePropertyLoadEventRaised;
        public event EventHandler cmbHandleTypeSelectedValueEventRaised;


        private bool _initialLoad = true;
        private void PP_HandlePropertyUC_Load(object sender, EventArgs e)
        {
            List<Handle_Type> rio = new List<Handle_Type>();
            foreach (Handle_Type item in Handle_Type.GetAll())
            {
                if (ProfileType_FromMainPresenter.Contains("Alutek"))
                {
                    if (item == Handle_Type._CremonHandle)
                    {
                        rio.Add(item);
                    }
                }
                else
                {
                    if (item != Handle_Type._CremonHandle)
                    {
                        rio.Add(item);
                    } 
                }
            }
            cmb_HandleType.DataSource = rio;

            EventHelpers.RaiseEvent(this, PPHandlePropertyLoadEventRaised, e);

            _initialLoad = false;
        }

        private void cmb_HandleType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!_initialLoad)
            {
                Handle_Type sel_handleType = (Handle_Type)((ComboBox)sender).SelectedValue;
                 if (sel_handleType == Handle_Type._Rotoswing)
                {
                    if (!(Frame_ArtNo == FrameProfile_ArticleNo._7502 &&
                        Panel_SashProfileArtNo == SashProfile_ArticleNo._7581) &&
                        !(Frame_ArtNo == FrameProfile_ArticleNo._7507 &&
                        Panel_SashProfileArtNo == SashProfile_ArticleNo._7581) &&
                        !(Frame_ArtNo == FrameProfile_ArticleNo._7507 &&
                        Panel_SashProfileArtNo == SashProfile_ArticleNo._395) &&
                        !(Frame_ArtNo == FrameProfile_ArticleNo._2060 &&
                        Panel_SashProfileArtNo == SashProfile_ArticleNo._2067) &&
                        !((Frame_ArtNo == FrameProfile_ArticleNo._6050 || Frame_ArtNo == FrameProfile_ArticleNo._6052) &&
                         Panel_SashProfileArtNo == SashProfile_ArticleNo._6040))
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", "Handle Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (sel_handleType == Handle_Type._Rio  || sel_handleType == Handle_Type._MVD)
                {
                    if (sel_handleType == Handle_Type._Rio)
                    {
                        if (!(Frame_ArtNo == FrameProfile_ArticleNo._7507 &&
                             (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 || Panel_SashProfileArtNo == SashProfile_ArticleNo._373)) &&
                            !(Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                              Panel_SashProfileArtNo == SashProfile_ArticleNo._6041))
                        {
                            MessageBox.Show("You've selected an incompatible item, be advised", "Handle Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    } 
                }
                else if ( sel_handleType == Handle_Type._Rotoline)
                {
                    if (!(Frame_ArtNo == FrameProfile_ArticleNo._6050 &&
                          (Panel_SashProfileArtNo == SashProfile_ArticleNo._6040 || Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)) &&
                        !(Frame_ArtNo == FrameProfile_ArticleNo._7507 &&
                         (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 || Panel_SashProfileArtNo == SashProfile_ArticleNo._373)) &&
                        !(Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                          Panel_SashProfileArtNo == SashProfile_ArticleNo._6041))
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", "Handle Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (sel_handleType == Handle_Type._PopUp)
                {
                    if (!(Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                        Panel_SashProfileArtNo == SashProfile_ArticleNo._6040))
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", "Handle Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else if (sel_handleType == Handle_Type._D ||
                         sel_handleType == Handle_Type._D_IO_Locking ||
                         sel_handleType == Handle_Type._DummyD ||
                         sel_handleType == Handle_Type._RotoswingForSliding)
                {
                    if (!(Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                        Panel_SashProfileArtNo == SashProfile_ArticleNo._6041))
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", "Handle Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (sel_handleType == Handle_Type._CremonHandle)
                {
                    if (Frame_ArtNo != FrameProfile_ArticleNo._84100)
                    {
                        MessageBox.Show("You've selected an incompatible item, be advised", "Handle Property", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
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

        private void cmb_HandleType_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background 
            e.DrawBackground();

            // Get the item text    
            string text = ((ComboBox)sender).Items[e.Index].ToString();

            if (text.Contains("None"))
            {
                e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);

            }
            else if (text.Contains("Rotary"))
            {
                if (Frame_ArtNo == FrameProfile_ArticleNo._6050 || Frame_ArtNo == FrameProfile_ArticleNo._6052)
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
            }
            else if (text == "Rotoswing Handle")
            {
                if ((Frame_ArtNo == FrameProfile_ArticleNo._7502 &&
                    Panel_SashProfileArtNo == SashProfile_ArticleNo._7581) ||
                    (Frame_ArtNo == FrameProfile_ArticleNo._7507 &&
                    Panel_SashProfileArtNo == SashProfile_ArticleNo._7581) ||
                    (Frame_ArtNo == FrameProfile_ArticleNo._7507 &&
                    Panel_SashProfileArtNo == SashProfile_ArticleNo._395) ||
                    (Frame_ArtNo == FrameProfile_ArticleNo._2060 &&
                    Panel_SashProfileArtNo == SashProfile_ArticleNo._2067) ||
                    ((Frame_ArtNo == FrameProfile_ArticleNo._6050 || Frame_ArtNo == FrameProfile_ArticleNo._6052) &&
                    Panel_SashProfileArtNo == SashProfile_ArticleNo._6040))
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
            }
            else if (text.Contains("Rio") || text.Contains("Rotoline") || text.Contains("MVD"))
            {
                if (text == "Rio Handle")
                {
                    if ((Frame_ArtNo == FrameProfile_ArticleNo._7507 &&
                       (Panel_SashProfileArtNo == SashProfile_ArticleNo._374 ||
                       Panel_SashProfileArtNo == SashProfile_ArticleNo._373)) ||
                       (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                       Panel_SashProfileArtNo == SashProfile_ArticleNo._6041))
                    {
                        e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                    }
                    else
                    {
                        e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                    }
                }
                else if (text.Contains("Rotoline"))
                {
                    if (Frame_ArtNo == FrameProfile_ArticleNo._6050 &&
                       ( Panel_SashProfileArtNo == SashProfile_ArticleNo._6040 || Panel_SashProfileArtNo == SashProfile_ArticleNo._6041))
                    {
                        e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                    }
                    else
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
                }
                else
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

            }
            else if (text.Contains("Pop-up Handle"))
            {
                if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                    Panel_SashProfileArtNo == SashProfile_ArticleNo._6040)
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
            }
            else if (text.Contains("D Handle") ||
                     text.Contains("D Handle In & Out Locking") ||
                     text.Contains("Dummy D Handle") ||
                     text.Contains("Rotoswing(Sliding) Handle"))
            {
                if (Frame_ArtNo == FrameProfile_ArticleNo._6052 &&
                     Panel_SashProfileArtNo == SashProfile_ArticleNo._6041)
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
            }
            else if (text.Contains("Cremon"))
            {
                if (Frame_ArtNo != FrameProfile_ArticleNo._84100)
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Firebrick, e.Bounds.X, e.Bounds.Y);
                }
                else
                {
                    e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
                }
            }
            // Draw the text    
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(this.Parent.Name);
        }
        private void cmb_HandleType_MouseWheel(object sender, MouseEventArgs e)
        {
            ((HandledMouseEventArgs)e).Handled = true;

        }

        private void cmb_HandleType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
