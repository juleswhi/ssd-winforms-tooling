using StateSystem;

namespace FormSystem;

public static class FormManager
{
    #region State Management
    public static State GlobalState { get; set; } = new State();

    public static Forms.formMaster GetActiveForm() 
    {
        Form? active = Form.ActiveForm;

        if(active is null)
        {
            // Create form
            return CreateForm<Forms.formMaster>()!;
        }

        if(active is Forms.formMaster master)
        {
            return master;
        }

        throw new Exception($"Active form must be of type: {nameof(Forms.formMaster)}");
    }

    // Name "Activate" is already used as part of the Form namespace
    public static void Trigger<T>(State? state = null) where T : Form, new()
    {
        T form = CreateForm<T>(state);

        form.TopLevel = false;
        form.Dock = DockStyle.Fill;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Enabled = true;
        form.Visible = true;

        Panel? formHolder = GetActiveForm().Controls.OfType<Panel>().FirstOrDefault();

        if(formHolder is null)
        {
            return;
        }

        formHolder.Controls.Clear();
        formHolder.Controls.Add(form);
        formHolder.Show();
    }

    // Create the form instance and pass both global state and scoped state
    private static T CreateForm<T>(State? scopedState = null) where T : Form, new()
    {
        scopedState ??= new State();

        T form = CreateFormInstace<T>();

        form.PassStateToForm(scopedState.AddState(GlobalState));

        return form;
    }

    private static T CreateFormInstace<T>() where T : Form, new()
    {
        T instance = Activator.CreateInstance<T>();

        if(instance is null)
        {
            return CreateFormInstace<T>();
        }

        return instance;
    }

    private static void PassStateToForm<T>(this T instance, State state) where T : Form, new()
    {
        var method = typeof(IState).GetMethods()[0];

        if(method is not null && typeof(IState).IsAssignableFrom(typeof(T)))
        {
            method!.Invoke(instance, [state]);
        }
    }
    #endregion
}
