
namespace RpgEditor
{
    partial class FormChestDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
/// <summary>
/// Clean up any resources being used.
/// </summary>
/// <param name="disposing">true if managed resources should be disposed; otherwise,false.</param>
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDifficulty = new System.Windows.Forms.ComboBox();
            this.cbLock = new System.Windows.Forms.CheckBox();
            this.cbTrap = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbTrap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbKeyName = new System.Windows.Forms.TextBox();
            this.tbKeyType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudKeys = new System.Windows.Forms.NumericUpDown();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.nudMinGold = new System.Windows.Forms.NumericUpDown();
            this.nudMaxGold = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxGold)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(99, 16);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(148, 23);
            this.tbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chest Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lock Difficulty:";
            // 
            // cboDifficulty
            // 
            this.cboDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDifficulty.Enabled = false;
            this.cboDifficulty.FormattingEnabled = true;
            this.cboDifficulty.Location = new System.Drawing.Point(102, 38);
            this.cboDifficulty.Name = "cboDifficulty";
            this.cboDifficulty.Size = new System.Drawing.Size(116, 23);
            this.cboDifficulty.TabIndex = 2;
            // 
            // cbLock
            // 
            this.cbLock.AutoSize = true;
            this.cbLock.Location = new System.Drawing.Point(26, 19);
            this.cbLock.Name = "cbLock";
            this.cbLock.Size = new System.Drawing.Size(64, 19);
            this.cbLock.TabIndex = 0;
            this.cbLock.Text = "Locked";
            this.cbLock.UseVisualStyleBackColor = true;
            // 
            // cbTrap
            // 
            this.cbTrap.AutoSize = true;
            this.cbTrap.Location = new System.Drawing.Point(8, 19);
            this.cbTrap.Name = "cbTrap";
            this.cbTrap.Size = new System.Drawing.Size(68, 19);
            this.cbTrap.TabIndex = 0;
            this.cbTrap.Text = "Trapped";
            this.cbTrap.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 41);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Trap Name:";
            // 
            // tbTrap
            // 
            this.tbTrap.Enabled = false;
            this.tbTrap.Location = new System.Drawing.Point(88, 38);
            this.tbTrap.Name = "tbTrap";
            this.tbTrap.Size = new System.Drawing.Size(116, 23);
            this.tbTrap.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Key Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Key Type:";
            // 
            // tbKeyName
            // 
            this.tbKeyName.Enabled = false;
            this.tbKeyName.Location = new System.Drawing.Point(102, 68);
            this.tbKeyName.Margin = new System.Windows.Forms.Padding(4);
            this.tbKeyName.Name = "tbKeyName";
            this.tbKeyName.Size = new System.Drawing.Size(116, 23);
            this.tbKeyName.TabIndex = 4;
            // 
            // tbKeyType
            // 
            this.tbKeyType.Enabled = false;
            this.tbKeyType.Location = new System.Drawing.Point(102, 97);
            this.tbKeyType.Margin = new System.Windows.Forms.Padding(4);
            this.tbKeyType.Name = "tbKeyType";
            this.tbKeyType.Size = new System.Drawing.Size(116, 23);
            this.tbKeyType.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Keys Needed:";
            // 
            // nudKeys
            // 
            this.nudKeys.Enabled = false;
            this.nudKeys.Location = new System.Drawing.Point(102, 124);
            this.nudKeys.Name = "nudKeys";
            this.nudKeys.Size = new System.Drawing.Size(116, 23);
            this.nudKeys.TabIndex = 8;
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.ItemHeight = 15;
            this.lbItems.Location = new System.Drawing.Point(5, 20);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(315, 304);
            this.lbItems.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(104, 329);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 22);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(176, 329);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(66, 22);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Minimum Gold:";
            // 
            // nudMinGold
            // 
            this.nudMinGold.Location = new System.Drawing.Point(102, 20);
            this.nudMinGold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMinGold.Name = "nudMinGold";
            this.nudMinGold.Size = new System.Drawing.Size(116, 23);
            this.nudMinGold.TabIndex = 0;
            // 
            // nudMaxGold
            // 
            this.nudMaxGold.Location = new System.Drawing.Point(102, 46);
            this.nudMaxGold.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxGold.Name = "nudMaxGold";
            this.nudMaxGold.Size = new System.Drawing.Size(116, 23);
            this.nudMaxGold.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Maximum Gold:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDifficulty);
            this.groupBox1.Controls.Add(this.tbKeyName);
            this.groupBox1.Controls.Add(this.tbKeyType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbLock);
            this.groupBox1.Controls.Add(this.nudKeys);
            this.groupBox1.Location = new System.Drawing.Point(15, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 153);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lock Properties";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbTrap);
            this.groupBox2.Controls.Add(this.tbTrap);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(10, 206);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(236, 77);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trap Properties";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudMinGold);
            this.groupBox3.Controls.Add(this.nudMaxGold);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(10, 289);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 82);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gold Properties";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbItems);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Controls.Add(this.btnRemove);
            this.groupBox4.Location = new System.Drawing.Point(264, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(329, 355);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Item Properties";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(229, 389);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 22);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(312, 389);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 22);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormChestDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 422);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormChestDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chest";
            ((System.ComponentModel.ISupportInitialize)(this.nudKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxGold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDifficulty;
        private System.Windows.Forms.CheckBox cbLock;

        private System.Windows.Forms.CheckBox cbTrap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbTrap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbKeyName;
        private System.Windows.Forms.TextBox tbKeyType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudKeys;
        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudMinGold;
        private System.Windows.Forms.NumericUpDown nudMaxGold;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}