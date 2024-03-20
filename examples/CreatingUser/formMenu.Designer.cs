namespace CreatingUser
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
            lblHello = new Label();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblHello
            // 
            lblHello.AutoSize = true;
            lblHello.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblHello.Location = new Point(329, 183);
            lblHello.Name = "lblHello";
            lblHello.Size = new Size(100, 40);
            lblHello.TabIndex = 0;
            lblHello.Text = "Hello, ";
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnLogin.Location = new Point(311, 226);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(198, 47);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Back to Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // formMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLogin);
            Controls.Add(lblHello);
            Name = "formMenu";
            Text = "formMenu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHello;
        private Button btnLogin;
    }
}