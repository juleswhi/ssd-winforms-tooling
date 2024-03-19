namespace StateSystem;

/// <summary>
/// Some useful extension methods for State as it is merely an alias for a Dictionary type
/// </summary>
public static class StateHelper
{
    /// <summary>
    /// Allows the merging of two States. 
    /// If there are any duplicate keys, State A will overwrite State B
    /// </summary>
    /// <param name="a">The priority State</param>
    /// <param name="b">Second State</param>
    /// <returns>A combined state</returns>
    public static State AddState(this State a, State b)
    {
        foreach (var kvp in b)
        {
            if (!a.ContainsKey(kvp.Key))
            {
                a.Add(kvp.Key, kvp.Value);
            }
        }

        return a;
    }
}
