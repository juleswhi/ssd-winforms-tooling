namespace UsingStateExample;

public partial class formMenu : Form, IState
{
    public formMenu()
    {
        InitializeComponent();
    }

    public void State(State state)
    {
        // The state is the same state that was passed through from formLogin, only with global state added.

        // We can get a value from state by using `Get` to return a IEnumerable of values, or GetFirst to return just one
        // Passing a type in <> allows the state value to be cast into the type automatically.
        // Non-generic methods of Get and GetFirst are also available

        var username = state.GetFirst<string>(STATE_USERNAME);

        // Finally, let's use this state to say hello!
        lblMainMenu.Text = $"Welcome, {username}";
    }

    private void btnBackToLogin_Click(object sender, EventArgs e)
    {
        // No state needs passed so we can ignore it all together.
        Trigger<formLogin>();
    }
}
