using FormSystem.Forms;
using StateSystem;

namespace FormSystem;

public static class FormManager
{
    #region State Management

    internal static State GlobalState { get; set; } = new State();

    private static IFormMaster? _master;

    public static void Start<T>(Action<formMaster>? callback = null) where T : Form, new()
    {
        _master = new formMaster();

        Trigger<T>();

        if (callback is Action<IFormMaster> action)
        {
            action(_master);
        }

        Application.Run((formMaster)_master);
    }

    public static void Start<TMasterForm, TStartForm>(Action<TMasterForm>? callback = null) 
        where TMasterForm : Form, IFormMaster, new() 
        where TStartForm : Form, new()
    {
        // Create instance of TMasterForm
        var master = CreateForm<TMasterForm>();

        _master = master;

        Trigger<TStartForm>();

        if(callback is Action<IFormMaster> action)
        {
            action(_master);
        }

        Application.Run((TMasterForm)_master);

    }

    /// <summary>
    /// A method which loads another form to the master form
    /// </summary>
    /// <typeparam name="T">The type of form to load</typeparam>
    /// <param name="state">Any state to pass through</param>
    /// <returns>A state representing either a Success or Failure</returns>
    public static State Trigger<T>(State? state = null) where T : Form, new()
    {
        if(_master is null)
        {
            return FlagFailure;
        }

        state ??= new();

        T form = CreateForm<T>(state);

        _master.LoadForm(form);

        return FlagSuccess;
    }

    /// <summary>
    /// A method which loads another form to the master form
    /// </summary>
    /// <typeparam name="T">The type of form to load</typeparam>
    /// <param name="state">An array of any state to pass through</param>
    /// <returns>A state representing either a Success or Failure</returns>
    public static State Trigger<T>(params State[] state) where T : Form, new()
    {
        if(_master is null)
        {
            return FlagFailure;
        }

        T form = CreateForm<T>(AddStates(state));

        _master.LoadForm(form);

        return FlagSuccess;
    }

    public static void Trigger<T>(object obj, params StateType[] stateTypes)
    {
        State state = obj.GetState(stateTypes);

        Trigger<T>(state);
    }

    /// <summary>
    /// Creates a form from a type, and attempts to pass state through 
    /// </summary>
    /// <typeparam name="T">The type of form to create</typeparam>
    /// <param name="state">The state to be passed through</param>
    /// <returns>The form object</returns>
    private static T CreateForm<T>(State? state = null) where T : Form, new()
    {
        state ??= new State();

        T form = Activator.CreateInstance<T>();

        form.PassStateToForm(state.AddState(GlobalState));

        return form;
    }


    /// <summary>
    /// Attempts to pass state to the form
    /// </summary>
    /// <typeparam name="T">The type of form to be passed into</typeparam>
    /// <param name="instance">The actual form to be state-ified</param>
    /// <param name="state">The state to be passed into the form</param>
    private static State PassStateToForm<T>(this T instance, State state) where T : Form, new()
    {
        var method = typeof(IState).GetMethods()[0];

        if (method is not null && typeof(IState).IsAssignableFrom(typeof(T)))
        {
            method!.Invoke(instance, [state]);
            return FlagSuccess;
        }

        return FlagFailure;

    }
    #endregion
}
