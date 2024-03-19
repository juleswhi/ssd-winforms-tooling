namespace FormSystem;

/// <summary>
/// A static class which provides properties to modify how forms and controls are updated
/// </summary>
public static class FormConfiguration
{
    /// <summary>
    /// A set of actions to be run when a control is made.
    /// </summary>
    public static HashSet<Action<Control>> ControlDefaultConfiguration { get; set; } = [];

    /// <summary>
    /// A set of actions to be run when a form is made
    /// </summary>
    public static HashSet<Action<Form>> FormDefaultConfiguration { get; set; } = [];

    /// <summary>
    /// A set of actions to be run a control is updated ( position etc. )
    /// </summary>
    public static HashSet<Action<Control>> ControlUpdateStack { get; set; } = [];
}
