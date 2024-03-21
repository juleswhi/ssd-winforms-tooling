namespace FormSystem;

public interface IFormMaster
{
    Panel GetHolder();
    void LoadForm(Form form)
    {

        form.TopLevel = false;
        form.Dock = DockStyle.Fill;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Enabled = true;
        form.Visible = true;

        var panel = GetHolder();

        panel.Controls.Clear();
        panel.Controls.Add(form);
        panel.Show();
        form.Show();

        form.Refresh();
    }
}
