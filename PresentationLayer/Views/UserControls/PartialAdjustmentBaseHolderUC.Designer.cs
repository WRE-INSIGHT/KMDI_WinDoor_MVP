namespace PresentationLayer.Views.UserControls
{
    partial class PartialAdjustmentBaseHolderUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_BaseHolderPnl = new System.Windows.Forms.Panel();
            this.btn_addItemQty = new System.Windows.Forms.Button();
            this.lbl_ItemNo = new System.Windows.Forms.Label();
            this.btn_Expnd = new System.Windows.Forms.Button();
            this.pnl_BaseHolderBody = new System.Windows.Forms.Panel();
            this.pnl_BaseHolderPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_BaseHolderPnl
            // 
            this.pnl_BaseHolderPnl.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_BaseHolderPnl.Controls.Add(this.btn_addItemQty);
            this.pnl_BaseHolderPnl.Controls.Add(this.lbl_ItemNo);
            this.pnl_BaseHolderPnl.Controls.Add(this.btn_Expnd);
            this.pnl_BaseHolderPnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_BaseHolderPnl.Location = new System.Drawing.Point(0, 0);
            this.pnl_BaseHolderPnl.Name = "pnl_BaseHolderPnl";
            this.pnl_BaseHolderPnl.Size = new System.Drawing.Size(732, 29);
            this.pnl_BaseHolderPnl.TabIndex = 0;
            // 
            // btn_addItemQty
            // 
            this.btn_addItemQty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_addItemQty.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_addItemQty.Location = new System.Drawing.Point(676, 0);
            this.btn_addItemQty.Name = "btn_addItemQty";
            this.btn_addItemQty.Size = new System.Drawing.Size(28, 29);
            this.btn_addItemQty.TabIndex = 6;
            this.btn_addItemQty.UseVisualStyleBackColor = true;
            this.btn_addItemQty.Click += new System.EventHandler(this.btn_addItemQty_Click);
            // 
            // lbl_ItemNo
            // 
            this.lbl_ItemNo.AutoSize = true;
            this.lbl_ItemNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ItemNo.Location = new System.Drawing.Point(5, 5);
            this.lbl_ItemNo.Name = "lbl_ItemNo";
            this.lbl_ItemNo.Size = new System.Drawing.Size(20, 17);
            this.lbl_ItemNo.TabIndex = 5;
            this.lbl_ItemNo.Text = "...";
            // 
            // btn_Expnd
            // 
            this.btn_Expnd.BackgroundImage = global::PresentationLayer.Properties.Resources.down_arrow_square_outlined_button;
            this.btn_Expnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Expnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Expnd.Location = new System.Drawing.Point(704, 0);
            this.btn_Expnd.Name = "btn_Expnd";
            this.btn_Expnd.Size = new System.Drawing.Size(28, 29);
            this.btn_Expnd.TabIndex = 0;
            this.btn_Expnd.UseVisualStyleBackColor = true;
            this.btn_Expnd.Click += new System.EventHandler(this.btn_Expnd_Click);
            // 
            // pnl_BaseHolderBody
            // 
            this.pnl_BaseHolderBody.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnl_BaseHolderBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_BaseHolderBody.Location = new System.Drawing.Point(0, 29);
            this.pnl_BaseHolderBody.Name = "pnl_BaseHolderBody";
            this.pnl_BaseHolderBody.Size = new System.Drawing.Size(732, 171);
            this.pnl_BaseHolderBody.TabIndex = 1;
            // 
            // PartialAdjustmentBaseHolderUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pnl_BaseHolderBody);
            this.Controls.Add(this.pnl_BaseHolderPnl);
            this.Name = "PartialAdjustmentBaseHolderUC";
            this.Size = new System.Drawing.Size(732, 200);
            this.Load += new System.EventHandler(this.PartialAdjustmentBaseHolderUC_Load);
            this.pnl_BaseHolderPnl.ResumeLayout(false);
            this.pnl_BaseHolderPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_BaseHolderPnl;
        private System.Windows.Forms.Panel pnl_BaseHolderBody;
        private System.Windows.Forms.Button btn_Expnd;
        private System.Windows.Forms.Label lbl_ItemNo;
        private System.Windows.Forms.Button btn_addItemQty;
    }
}
