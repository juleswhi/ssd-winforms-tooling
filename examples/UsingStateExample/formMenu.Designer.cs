namespace UsingStateExample
{
    partial class formMenu
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
            lblMainMenu = new Label();
            btnBackToLogin = new Button();
            SuspendLayout();
            // 
            // lblMainMenu
            // 
            lblMainMenu.AutoSize = true;
            lblMainMenu.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblMainMenu.Location = new Point(269, 154);
            lblMainMenu.Name = "lblMainMenu";
            lblMainMenu.Size = new Size(275, 47);
            lblMainMenu.TabIndex = 0;
            lblMainMenu.Text = "Welcome, User!";
            // 
            // btnBackToLogin
            // 
            btnBackToLogin.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnBackToLogin.Location = new Point(334, 214);
            btnBackToLogin.Name = "btnBackToLogin";
            btnBackToLogin.Size = new Size(132, 48);
            btnBackToLogin.TabIndex = 1;
            btnBackToLogin.Text = "Back to login";
            btnBackToLogin.UseVisualStyleBackColor = true;
            btnBackToLogin.Click += btnBackToLogin_Click;
            // 
            // formMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBackToLogin);
            Controls.Add(lblMainMenu);
            Name = "formMenu";
            Text = "formMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMainMenu;
        private Button btnBackToLogin;
    }
}