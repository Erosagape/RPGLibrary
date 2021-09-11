
namespace RpgEditor
{
    partial class FormShieldDetails
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnRemoveAllowed = new System.Windows.Forms.Button();
            this.btnMoveAllowed = new System.Windows.Forms.Button();
            this.lbAllowedClasses = new System.Windows.Forms.ListBox();
            this.lbClasses = new System.Windows.Forms.ListBox();
            this.mtbDefenseModifier = new System.Windows.Forms.MaskedTextBox();
            this.mtbDefenseValue = new System.Windows.Forms.MaskedTextBox();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.mtbPrice = new System.Windows.Forms.MaskedTextBox();
            this.tbType = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(406, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 74;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(320, 178);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 73;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAllowed
            // 
            this.btnRemoveAllowed.Location = new System.Drawing.Point(368, 87);
            this.btnRemoveAllowed.Name = "btnRemoveAllowed";
            this.btnRemoveAllowed.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAllowed.TabIndex = 72;
            this.btnRemoveAllowed.Text = "<<";
            this.btnRemoveAllowed.UseVisualStyleBackColor = true;
            // 
            // btnMoveAllowed
            // 
            this.btnMoveAllowed.Location = new System.Drawing.Point(368, 58);
            this.btnMoveAllowed.Name = "btnMoveAllowed";
            this.btnMoveAllowed.Size = new System.Drawing.Size(75, 23);
            this.btnMoveAllowed.TabIndex = 71;
            this.btnMoveAllowed.Text = ">>";
            this.btnMoveAllowed.UseVisualStyleBackColor = true;
            // 
            // lbAllowedClasses
            // 
            this.lbAllowedClasses.FormattingEnabled = true;
            this.lbAllowedClasses.ItemHeight = 15;
            this.lbAllowedClasses.Location = new System.Drawing.Point(449, 23);
            this.lbAllowedClasses.Name = "lbAllowedClasses";
            this.lbAllowedClasses.Size = new System.Drawing.Size(133, 139);
            this.lbAllowedClasses.TabIndex = 70;
            // 
            // lbClasses
            // 
            this.lbClasses.FormattingEnabled = true;
            this.lbClasses.ItemHeight = 15;
            this.lbClasses.Location = new System.Drawing.Point(241, 23);
            this.lbClasses.Name = "lbClasses";
            this.lbClasses.Size = new System.Drawing.Size(121, 139);
            this.lbClasses.TabIndex = 69;
            // 
            // mtbDefenseModifier
            // 
            this.mtbDefenseModifier.Location = new System.Drawing.Point(98, 192);
            this.mtbDefenseModifier.Mask = "000";
            this.mtbDefenseModifier.Name = "mtbDefenseModifier";
            this.mtbDefenseModifier.Size = new System.Drawing.Size(91, 23);
            this.mtbDefenseModifier.TabIndex = 68;
            // 
            // mtbDefenseValue
            // 
            this.mtbDefenseValue.Location = new System.Drawing.Point(98, 161);
            this.mtbDefenseValue.Mask = "000";
            this.mtbDefenseValue.Name = "mtbDefenseValue";
            this.mtbDefenseValue.Size = new System.Drawing.Size(92, 23);
            this.mtbDefenseValue.TabIndex = 67;
            // 
            // nudWeight
            // 
            this.nudWeight.Location = new System.Drawing.Point(98, 96);
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(130, 23);
            this.nudWeight.TabIndex = 65;
            // 
            // mtbPrice
            // 
            this.mtbPrice.Location = new System.Drawing.Point(98, 66);
            this.mtbPrice.Mask = "00000";
            this.mtbPrice.Name = "mtbPrice";
            this.mtbPrice.Size = new System.Drawing.Size(130, 23);
            this.mtbPrice.TabIndex = 64;
            // 
            // tbType
            // 
            this.tbType.Location = new System.Drawing.Point(98, 35);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(130, 23);
            this.tbType.TabIndex = 63;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(98, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(130, 23);
            this.tbName.TabIndex = 62;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 15);
            this.label11.TabIndex = 61;
            this.label11.Text = "Character Classes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(449, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 15);
            this.label10.TabIndex = 60;
            this.label10.Text = "Allowed Classes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 59;
            this.label8.Text = "Modifier";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 58;
            this.label7.Text = "Value";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 57;
            this.label6.Text = "Defense :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 55;
            this.label4.Text = "Weight :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 54;
            this.label3.Text = "Price :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 53;
            this.label2.Text = "Type :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 52;
            this.label1.Text = "Name :";
            // 
            // FormShieldDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 225);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnRemoveAllowed);
            this.Controls.Add(this.btnMoveAllowed);
            this.Controls.Add(this.lbAllowedClasses);
            this.Controls.Add(this.lbClasses);
            this.Controls.Add(this.mtbDefenseModifier);
            this.Controls.Add(this.mtbDefenseValue);
            this.Controls.Add(this.nudWeight);
            this.Controls.Add(this.mtbPrice);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormShieldDetails";
            this.Text = "FormShieldDetails";
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnRemoveAllowed;
        private System.Windows.Forms.Button btnMoveAllowed;
        private System.Windows.Forms.ListBox lbAllowedClasses;
        private System.Windows.Forms.ListBox lbClasses;
        private System.Windows.Forms.MaskedTextBox mtbDefenseModifier;
        private System.Windows.Forms.MaskedTextBox mtbDefenseValue;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.MaskedTextBox mtbPrice;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}