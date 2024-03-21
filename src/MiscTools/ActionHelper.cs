namespace CourseworkTooling;

public static class ActionHelper
{
    public static Action EmptyAction() => () => { };
    public static Action<T1> EmptyAction<T1>() => (_) => { };
    public static Action<T1, T2> EmptyAction<T1, T2>() => (_, _) => { };
}
