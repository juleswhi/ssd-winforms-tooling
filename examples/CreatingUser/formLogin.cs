namespace CreatingUser;

public partial class formLogin : Form
{
    private const string _correctUsername = "user";
    private const string _correctPassword = "password";
    public formLogin()
    {
        InitializeComponent();
        lblDetailsIncorrect.Hide();
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        string username = txtBoxUsername.Text;
        string password = txtBoxPassword.Text;

        if (username != _correctUsername)
        {
            lblDetailsIncorrect.Show();
            return;
        }

        if(password != _correctPassword)
        {
            lblDetailsIncorrect.Show();
            return;
        }

        // User is added to global state automatically
        var _ = User.From(username, password);

        Trigger<formMenu>();
    }
}