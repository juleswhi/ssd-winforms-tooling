namespace StateSystem;

public class State : Dictionary<IEnumerable<StateType>, object?>
{
    public static State From()
    {
        return GetGlobalState();
    }

    // Way of storing objects stored with arbitrary strings
}
