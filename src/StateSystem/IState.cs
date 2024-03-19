namespace StateSystem;

/// <summary>
/// An interface which ensures all consumers impl the State(State state) method.
/// </summary>
public interface IState
{
    /// <summary>
    /// A method which can handle state in all consumers
    /// </summary>
    /// <param name="state">The state that should be handled</param>
    void State(State state);
}
