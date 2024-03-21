using FormSystem;

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

    public static State GetGlobalState()
    {
        return FormManager.GlobalState;
    }

    public static State AddStates(params State[] states)
    {
        return states.Aggregate((x, y) => x.AddState(y));
    }

    public static State AddStates(this IEnumerable<State> states)
    {
        return AddStates(states);
    }

    public static IEnumerable<object> Get(this State state, params StateType[] stateTypes)
    {
        return state.Where(x => x.Key == stateTypes)
            .Select(x => { if (x.Value is not null) return x.Value; return null; })
            .Where(x => x is not null)!;
    }

    public static IEnumerable<T> Get<T>(this State state, params StateType[] stateTypes)
    {
        return state.Get(stateTypes).Select(x => (T?)x).Where(x => x is not null)!;
    }
    public static IEnumerable<object> Get(this State state, StateType stateType)
    {
        return state.Where(x => x.Key.Any(x => x == stateType))
            .Select(x => { if (x.Value is not null) return x.Value; return null; })
            .Where(x => x is not null)!;
    }

    public static IEnumerable<T> Get<T>(this State state, StateType stateType)
    {
        return state.Get(stateType).Select(x => (T?)x).Where(x => x is not null)!;
    }

    public static object? GetFirst(this State state, params StateType[] stateTypes)
    {
        return state.Get(stateTypes).FirstOrDefault();
    }

    public static T? GetFirst<T>(this State state, params StateType[] stateTypes)
    {
        return (T?)state.Get(stateTypes).FirstOrDefault();
    }

    public static object? GetFirst(this State state, StateType stateType)
    {
        return state.Get(stateType).FirstOrDefault();
    }

    public static T? GetFirst<T>(this State state, StateType stateType)
    {
        return (T?)state.Get(stateType).FirstOrDefault();
    }


    public static IEnumerable<T?> GetWhere<T>(this State state, params StateType[] stateTypes)
    {
        foreach(var type in stateTypes)
        {
            if (!state.ContainsKey([type])) continue;

            yield return (T?)state[[type]];
        }
    }

    public static IEnumerable<T?> GetAll<T>(this State state, StateType stateType)
    {
        return state.Where(x => x.Key.Any(y => y == stateType)).Select(z => (T?)z.Value);
    }

    public static bool Has(this State state, StateType stateType)
    {
        return state.Any(x => x.Key.Any(y => y == stateType) );
    }

    public static bool HasFlag(this State state, StateType stateType)
    {
        return state.Has(FLAG) && state.Has(stateType);
    }

    public static IEnumerable<string> GetFlags(this State state)
    {
        return state.Get<string>(FLAG);
    }

    public static bool Flag(this State state)
    {
        return state.Has(FLAG);
    }

    public static bool HasFlag(this State state, string value)
    {
        return state.Any(x => x.Key.Any(y => y == FLAG) && (string?)x.Value == value);
    }

    public static State GetState(this object obj, params StateType[] stateTypes)
    {
        return StateFrom(obj, stateTypes);
    }

    public static State GetState<T>(this T obj)
    {
        StateType[] stateTypes = typeof(T).Name switch
        {
            "User" => [STATE_USER],
            _ => [FLAG]
        };

        return obj!.GetState(stateTypes);
    }

    public static State StateFrom(object? obj, params StateType[] stateTypes)
    {
        return new State()
        {
            { stateTypes, obj }
        };
    }

    public static State StateFrom(params (object obj, StateType[] stateTypes)[] states)
    {
        State state = new();
        foreach(var subState in states)
        {
            state.Add(subState.Item2, subState.Item1);
        }
        return state;
    }

    public static bool IsSuccess(this State state)
    {
        return state.Has(FLAG_SUCCESS);
    }

    public static bool IsFailure(this State state)
    {
        return state.Has(FLAG_FAILURE);
    }

    public static State GenerateFlag()
    {
        return StateFrom(null, FLAG);
    }

    public static State GlobalStateAdd(State state)
    {
        FormManager.GlobalState.AddState(state);
        return FlagSuccess;
    }

    public static State GlobalStateRemove(State state)
    {
        FormManager.GlobalState = FormManager.GlobalState.Where(x => !state.ContainsKey(x.Key)).ToDictionary(x => x.Key, x => x.Value);
        return FlagFailure;
    }

    public static State FlagSuccess => StateFrom(FLAG_SUCCESS);
    public static State FlagFailure => StateFrom(FLAG_FAILURE);
}
