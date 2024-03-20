namespace UsingStateExample
{
    partial class formLogin
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
            lblLogin = new Label();
            txtBoxUsername = new TextBox();
            txtBoxPassword = new TextBox();
            btnLogin = new Button();
            lblWrongDetails = new Label();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblLogin.Location = new Point(329, 92);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(87, 32);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "LOGIN";
            // 
            // txtBoxUsername
            // 
            txtBoxUsername.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxUsername.Location = new Point(282, 143);
            txtBoxUsername.Name = "txtBoxUsername";
            txtBoxUsername.PlaceholderText = "Username...";
            txtBoxUsername.Size = new Size(192, 46);
            txtBoxUsername.TabIndex = 1;
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxPassword.Location = new Point(282, 195);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PlaceholderText = "Password...";
            txtBoxPassword.Size = new Size(192, 46);
            txtBoxPassword.TabIndex = 2;
            txtBoxPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(282, 258);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(192, 47);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login!";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // lblWrongDetails
            // 
            lblWrongDetails.AutoSize = true;
            lblWrongDetails.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblWrongDetails.ForeColor = Color.Red;
            lblWrongDetails.Location = new Point(194, 325);
            lblWrongDetails.Name = "lblWrongDetails";
            lblWrongDetails.Size = new Size(376, 25);
            lblWrongDetails.TabIndex = 4;
            lblWrongDetails.Text = "Your username and/or password are wrong";
            // 
            // formLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblWrongDetails);
            Controls.Add(btnLogin);
            Controls.Add(txtBoxPassword);
            Controls.Add(txtBoxUsername);
            Controls.Add(lblLogin);
            Name = "formLogin";
            Text = "formLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogin;
        private TextBox txtBoxUsername;
        private TextBox txtBoxPassword;
        private Button btnLogin;
        private Label lblWrongDetails;
    }
}