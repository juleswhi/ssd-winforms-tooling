namespace StateSystem;

/// <summary>
/// A default implementation of the IState interface
/// </summary>
public interface IDefaultState : IState
{
    public new void State(State state)
    {}
}
