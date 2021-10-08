
namespace RpgEditor
{
    partial class FormWeaponDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbType = new System.Windows.Forms.TextBox();
            this.mtbPrice = new System.Windows.Forms.MaskedTextBox();
            this.nudWeight = new System.Windows.Forms.NumericUpDown();
            this.cboHands = new System.Windows.Forms.ComboBox();
            this.mtbAttackValue = new System.Windows.Forms.MaskedTextBox();
            this.mtbAttackModifier = new System.Windows.Forms.MaskedTextBox();
            this.mtbDamageModifier = new System.Windows.Forms.MaskedTextBox();
            this.mtbDamageValue = new System.Windows.Forms.MaskedTextBox();
            this.lbClasses = new System.Windows.Forms.ListBox();
            this.lbAllowedClasses = new System.Windows.Forms.ListBox();
            this.btnMoveAllowed = new System.Windows.Forms.Button();
            this.btnRemoveAllowed = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Price :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Weight :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Hands :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Attack :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Value";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(447, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Modifier";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(286, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Damage :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(337, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 15);
            this.label10.TabIndex = 9;
            this.label10.Text = "Allowed Classes";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(55, 169);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 15);
            this.label11.TabIndex = 10;
            this.label11.Text = "Character Classes";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(118, 13);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(130, 23);
            this.tbName.TabIndex = 1;
            // 
            // tbType
            // 
            this.tbType.Location = new System.Drawing.Point(118, 43);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(130, 23);
            this.tbType.TabIndex = 2;
            // 
            // mtbPrice
            // 
            this.mtbPrice.Location = new System.Drawing.Point(118, 74);
            this.mtbPrice.Mask = "00000";
            this.mtbPrice.Name = "mtbPrice";
            this.mtbPrice.Size = new System.Drawing.Size(130, 23);
            this.mtbPrice.TabIndex = 3;
            // 
            // nudWeight
            // 
            this.nudWeight.Location = new System.Drawing.Point(118, 104);
            this.nudWeight.Name = "nudWeight";
            this.nudWeight.Size = new System.Drawing.Size(130, 23);
            this.nudWeight.TabIndex = 4;
            // 
            // cboHands
            // 
            this.cboHands.FormattingEnabled = true;
            this.cboHands.Location = new System.Drawing.Point(118, 135);
            this.cboHands.Name = "cboHands";
            this.cboHands.Size = new System.Drawing.Size(130, 23);
            this.cboHands.TabIndex = 5;
            // 
            // mtbAttackValue
            // 
            this.mtbAttackValue.Location = new System.Drawing.Point(349, 31);
            this.mtbAttackValue.Mask = "000";
            this.mtbAttackValue.Name = "mtbAttackValue";
            this.mtbAttackValue.Size = new System.Drawing.Size(92, 23);
            this.mtbAttackValue.TabIndex = 6;
            this.mtbAttackValue.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.maskedTextBox2_MaskInputRejected);
            // 
            // mtbAttackModifier
            // 
            this.mtbAttackModifier.Location = new System.Drawing.Point(447, 31);
            this.mtbAttackModifier.Mask = "000";
            this.mtbAttackModifier.Name = "mtbAttackModifier";
            this.mtbAttackModifier.Size = new System.Drawing.Size(91, 23);
            this.mtbAttackModifier.TabIndex = 7;
            // 
            // mtbDamageModifier
            // 
            this.mtbDamageModifier.Location = new System.Drawing.Point(447, 60);
            this.mtbDamageModifier.Mask = "000";
            this.mtbDamageModifier.Name = "mtbDamageModifier";
            this.mtbDamageModifier.Size = new System.Drawing.Size(91, 23);
            this.mtbDamageModifier.TabIndex = 9;
            // 
            // mtbDamageValue
            // 
            this.mtbDamageValue.Location = new System.Drawing.Point(349, 60);
            this.mtbDamageValue.Mask = "000";
            this.mtbDamageValue.Name = "mtbDamageValue";
            this.mtbDamageValue.Size = new System.Drawing.Size(92, 23);
            this.mtbDamageValue.TabIndex = 8;
            // 
            // lbClasses
            // 
            this.lbClasses.FormattingEnabled = true;
            this.lbClasses.ItemHeight = 15;
            this.lbClasses.Location = new System.Drawing.Point(57, 188);
            this.lbClasses.Name = "lbClasses";
            this.lbClasses.Size = new System.Drawing.Size(191, 139);
            this.lbClasses.TabIndex = 20;
            // 
            // lbAllowedClasses
            // 
            this.lbAllowedClasses.FormattingEnabled = true;
            this.lbAllowedClasses.ItemHeight = 15;
            this.lbAllowedClasses.Location = new System.Drawing.Point(337, 188);
            this.lbAllowedClasses.Name = "lbAllowedClasses";
            this.lbAllowedClasses.Size = new System.Drawing.Size(191, 139);
            this.lbAllowedClasses.TabIndex = 21;
            // 
            // btnMoveAllowed
            // 
            this.btnMoveAllowed.Location = new System.Drawing.Point(256, 229);
            this.btnMoveAllowed.Name = "btnMoveAllowed";
            this.btnMoveAllowed.Size = new System.Drawing.Size(75, 23);
            this.btnMoveAllowed.TabIndex = 22;
            this.btnMoveAllowed.Text = ">>";
            this.btnMoveAllowed.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAllowed
            // 
            this.btnRemoveAllowed.Location = new System.Drawing.Point(256, 258);
            this.btnRemoveAllowed.Name = "btnRemoveAllowed";
            this.btnRemoveAllowed.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAllowed.TabIndex = 23;
            this.btnRemoveAllowed.Text = "<<";
            this.btnRemoveAllowed.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(366, 116);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 24;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(447, 116);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormWeaponDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 335);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnRemoveAllowed);
            this.Controls.Add(this.btnMoveAllowed);
            this.Controls.Add(this.lbAllowedClasses);
            this.Controls.Add(this.lbClasses);
            this.Controls.Add(this.mtbDamageModifier);
            this.Controls.Add(this.mtbDamageValue);
            this.Controls.Add(this.mtbAttackModifier);
            this.Controls.Add(this.mtbAttackValue);
            this.Controls.Add(this.cboHands);
            this.Controls.Add(this.nudWeight);
            this.Controls.Add(this.mtbPrice);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormWeaponDetails";
            this.Text = "FormWeaponDetails";
            ((System.ComponentModel.ISupportInitialize)(this.nudWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.MaskedTextBox mtbPrice;
        private System.Windows.Forms.NumericUpDown nudWeight;
        private System.Windows.Forms.ComboBox cboHands;
        private System.Windows.Forms.MaskedTextBox mtbAttackValue;
        private System.Windows.Forms.MaskedTextBox mtbAttackModifier;
        private System.Windows.Forms.MaskedTextBox mtbDamageModifier;
        private System.Windows.Forms.MaskedTextBox mtbDamageValue;
        private System.Windows.Forms.ListBox lbClasses;
        private System.Windows.Forms.ListBox lbAllowedClasses;
        private System.Windows.Forms.Button btnMoveAllowed;
        private System.Windows.Forms.Button btnRemoveAllowed;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}