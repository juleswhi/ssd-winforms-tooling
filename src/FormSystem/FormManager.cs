using FormSystem.Forms;
using StateSystem;

namespace FormSystem;

public static class FormManager
{
    #region State Management

    internal static State GlobalState { get; set; } = new State();

    private static formMaster _master = new();

    public static void Start<T>(Action<formMaster>? callback = null) where T : Form, new()
    {
        _master = new formMaster();

        Trigger<T>();

        if (callback is Action<formMaster> action)
        {
            action(_master);
        }

        Application.Run(_master);
    }

    // Name "Activate" is already used as part of the Form namespace
    public static void Trigger<T>(State? state = null) where T : Form, new()
    {
        state ??= new();

        T form = CreateForm<T>(state);

        _master.LoadForm(form);
    }

    public static void Trigger<T>(params State[] state) where T : Form, new()
    {
        T form = CreateForm<T>(AddStates(state));

        _master.LoadForm(form);
    }

    public static void Trigger<T>(object obj, params StateType[] stateTypes)
    {
        State state = obj.GetState(stateTypes);

        Trigger<T>(state);
    }

    // Create the form instance and pass both global state and scoped state
    private static T CreateForm<T>(State? state = null) where T : Form, new()
    {
        state ??= new State();

        T form = Activator.CreateInstance<T>();

        form.PassStateToForm(state.AddState(GlobalState));

        return form;
    }


    private static void PassStateToForm<T>(this T instance, State state) where T : Form, new()
    {
        var method = typeof(IState).GetMethods()[0];

        if (method is not null && typeof(IState).IsAssignableFrom(typeof(T)))
        {
            method!.Invoke(instance, [state]);
        }
    }
    #endregion
}
