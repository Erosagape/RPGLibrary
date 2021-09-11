
namespace RpgEditor
{
    partial class FormArmor
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // lbDetails
            // 
            this.lbDetails.Location = new System.Drawing.Point(12, 53);
            this.lbDetails.Size = new System.Drawing.Size(419, 229);
            // 
            // menuStrip1
            // 
            // 
            // loadToolStripMenuItem
            // 
            // 
            // saveToolStripMenuItem
            // 
            // 
            // FormArmor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 329);
            this.Name = "FormArmor";
            this.Text = "FormArmor";
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.lbDetails, 0);
            this.Controls.SetChildIndex(this.btnEdit, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}