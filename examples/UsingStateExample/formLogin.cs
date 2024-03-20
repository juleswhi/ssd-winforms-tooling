namespace UsingStateExample;

public partial class formLogin : Form
{

    // In practice, these details would be stored on disk, ideally hashed 
    private const string _correctUsername = "root";
    private const string _correctPassword = "password";


    public formLogin()
    {
        InitializeComponent();

        // Hide the error message
        lblWrongDetails.Hide();
    }

    // Simply check if the details are correct
    private void btnLogin_Click(object sender, EventArgs e)
    {
        // Bring the textbox data into strings
        string username = txtBoxUsername.Text;
        string password = txtBoxPassword.Text;

        // Ensure the user inputted the right username
        if (username != _correctUsername)
        {
            lblWrongDetails.Show();
            return;
        }

        // Ensure the user inputted the right password
        if (password != _correctPassword)
        {
            lblWrongDetails.Show();
            return;
        }

        // Username and Password must both be correct, so open up main menu
        // In this case we are just passing the username, but usually you would have a whole user etc.

        // We can pass the username through with a `STATE_USERNAME` StateType so we can grab it later.
        // We can also pass a success flag which will indicate to the consumer of the state that the login was a success.

        Trigger<formMenu>(
            username.GetState(STATE_USERNAME),
            FlagSuccess
            );
    }
}
