namespace CreatingUser
{
    partial class formLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBoxUsername = new TextBox();
            txtBoxPassword = new TextBox();
            btnRegister = new Button();
            lblDetailsIncorrect = new Label();
            SuspendLayout();
            // 
            // txtBoxUsername
            // 
            txtBoxUsername.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxUsername.Location = new Point(307, 133);
            txtBoxUsername.Name = "txtBoxUsername";
            txtBoxUsername.PlaceholderText = "Username..";
            txtBoxUsername.Size = new Size(214, 39);
            txtBoxUsername.TabIndex = 0;
            // 
            // txtBoxPassword
            // 
            txtBoxPassword.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            txtBoxPassword.Location = new Point(307, 178);
            txtBoxPassword.Name = "txtBoxPassword";
            txtBoxPassword.PlaceholderText = "Password..";
            txtBoxPassword.Size = new Size(214, 39);
            txtBoxPassword.TabIndex = 1;
            // 
            // btnRegister
            // 
            btnRegister.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegister.Location = new Point(305, 227);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(216, 43);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Register User";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // lblDetailsIncorrect
            // 
            lblDetailsIncorrect.AutoSize = true;
            lblDetailsIncorrect.Font = new Font("Segoe UI", 15.75F, FontStyle.Italic, GraphicsUnit.Point);
            lblDetailsIncorrect.ForeColor = Color.Red;
            lblDetailsIncorrect.Location = new Point(230, 273);
            lblDetailsIncorrect.Name = "lblDetailsIncorrect";
            lblDetailsIncorrect.Size = new Size(387, 30);
            lblDetailsIncorrect.TabIndex = 3;
            lblDetailsIncorrect.Text = "Either username or password are incorrect";
            // 
            // formLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblDetailsIncorrect);
            Controls.Add(btnRegister);
            Controls.Add(txtBoxPassword);
            Controls.Add(txtBoxUsername);
            Name = "formLogin";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxUsername;
        private TextBox txtBoxPassword;
        private Button btnRegister;
        private Label lblDetailsIncorrect;
    }
}