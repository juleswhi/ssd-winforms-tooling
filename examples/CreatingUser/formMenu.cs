namespace CreatingUser;

public partial class formMenu : Form, IState
{
    public formMenu()
    {
        InitializeComponent();
    }

    public void State(State state)
    {
        var user = state.GetFirst<User>(STATE_USER);

        if (user is null)
        {
            return;
        }

        lblHello.Text += user.Username + "!";
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        Trigger<formLogin>();
    }
}
