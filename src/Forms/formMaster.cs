namespace FormSystem.Forms;

public partial class formMaster : Form, IFormMaster
{
    public formMaster()
    {
        InitializeComponent();
        panelHolder.Dock = DockStyle.Fill;
    }

    public Panel GetHolder() => panelHolder;

    public void LoadForm(Form form)
    {
        form.TopLevel = false;
        form.Dock = DockStyle.Fill;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Enabled = true;
        form.Visible = true;

        panelHolder.Controls.Clear();
        panelHolder.Controls.Add(form);
        panelHolder.Show();
        form.Show();

        Refresh();
    }
}
