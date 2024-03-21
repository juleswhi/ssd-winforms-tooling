using Newtonsoft.Json;
using UserSystem;
using JsonString = string;

namespace CourseworkTooling;

/// <summary>
/// A collection of methods to enable easy serialization to json and writing to files 
/// </summary>
public static class FileHandler
{

    /// <summary>
    /// A lookup for default file locations of different types
    /// </summary>
    public static Dictionary<Type, string> TypeToFilePathMap = new()
    {
        { typeof(User), "users.json" },
    };

    /// <summary>
    /// Takes an object and serializes it, then writes it a specific file
    /// </summary>
    /// <typeparam name="T">The type of object to serialize</typeparam>
    /// <param name="data">The object to be serialized</param>
    /// <param name="path">The location of where the json should be written to</param>
    public static State SerializeWrite<T>(this T? data, string? path = null)
    {
        JsonString json = data.Serialize().Unwrap<string>();

        json.Write<T>();

        return FlagSuccess;
    }

    /// <summary>
    /// Reads file from a path and deserializes it into a proper object.
    /// </summary>
    /// <typeparam name="T">The type of object you want from the file</typeparam>
    /// <param name="path">The path to read from</param>
    /// <returns>A nullable instance of the object</returns>
    public static State ReadDeserialize<T>(this string path)
    {
        if (path.Read().IfNull().ElseUnwrap(out JsonString? json).IsFailure())
        {
            return FlagFailure;
        }

        T? data = json!.Deserialize<T>();

        if (data is T val)
        {
            return val.CreateSuccess();
        }

        return FlagFailure;
    }

    /// <summary>
    /// Takes an object and turns it into a json string
    /// </summary>
    /// <typeparam name="T">The type of object to serialize</typeparam>
    /// <param name="data">The actual object to serialize</param>
    /// <returns>The json string of the serialized object</returns>
    public static State Serialize<T>(this T data)
    {
        JsonString json = string.Empty;

        try
        {
            json = JsonConvert.SerializeObject(data);
        }
        catch(Exception)
        {
            return FlagFailure;
        }

        return json.CreateSuccess();

    }

    /// <summary>
    /// Turns a json string into an object
    /// </summary>
    /// <typeparam name="T">The type of object to deserialize</typeparam>
    /// <param name="str">The json string</param>
    /// <returns>An instance of the object</returns>
    public static T? Deserialize<T>(this JsonString str)
    {
        return JsonConvert.DeserializeObject<T>(str);
    }

    /// <summary>
    /// Writes a string to the specified path
    /// </summary>
    /// <typeparam name="T">If the path is left null, then this generic is used to decide on the path</typeparam>
    /// <param name="data">Contents of what should be printed</param>
    /// <param name="path">Where the streamwriter should open</param>
    public static State Write<T>(this string data, string? path = null)
    {
        path ??= TypeToFilePathMap.ContainsKey(typeof(T)) ?
            TypeToFilePathMap[typeof(T)] : null;

        if (path is null)
        {
            return FlagFailure;
        }

        using StreamWriter sw = new(path, false);

        try
        {
            sw.WriteLine(data);
        }
        catch(Exception)
        {
            return FlagFailure;
        }

        return FlagSuccess;
    }

    /// <summary>
    /// Reads a path and returns the contents
    /// </summary>
    /// <param name="path">The location to read</param>
    /// <returns>A string of the contents</returns>
    public static State Read(this string path)
    {
        string allText = string.Empty; 
        try
        {
            allText = File.ReadAllText(path);
        }
        catch(Exception)
        {
            return FlagFailure;
        }

        return allText.CreateSuccess();
    }
}
