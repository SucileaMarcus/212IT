namespace HarissAndSonsContactManager
{
    partial class ContactMenu
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
            this.btn_Personal = new System.Windows.Forms.Button();
            this.btnBusinessContact = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Personal
            // 
            this.btn_Personal.Location = new System.Drawing.Point(67, 49);
            this.btn_Personal.Name = "btn_Personal";
            this.btn_Personal.Size = new System.Drawing.Size(75, 37);
            this.btn_Personal.TabIndex = 0;
            this.btn_Personal.Text = "Personal Contact";
            this.btn_Personal.UseVisualStyleBackColor = true;
            this.btn_Personal.UseWaitCursor = true;
            this.btn_Personal.Click += new System.EventHandler(this.btn_Personal_Click);
            // 
            // btnBusinessContact
            // 
            this.btnBusinessContact.Location = new System.Drawing.Point(67, 125);
            this.btnBusinessContact.Name = "btnBusinessContact";
            this.btnBusinessContact.Size = new System.Drawing.Size(75, 35);
            this.btnBusinessContact.TabIndex = 1;
            this.btnBusinessContact.Text = "Business Contact";
            this.btnBusinessContact.UseVisualStyleBackColor = true;
            this.btnBusinessContact.Click += new System.EventHandler(this.btnBusinessContact_Click);
            // 
            // ContactMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 287);
            this.Controls.Add(this.btnBusinessContact);
            this.Controls.Add(this.btn_Personal);
            this.Name = "ContactMenu";
            this.Text = "ContactMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Personal;
        private System.Windows.Forms.Button btnBusinessContact;
    }
}

