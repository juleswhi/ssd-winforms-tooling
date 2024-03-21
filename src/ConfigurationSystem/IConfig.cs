using CourseworkTooling;

namespace ConfigurationSystem;
public interface IConfig
{
    static string? Path { get; set; } = "config.json";

    State UpdateConfig()
    {
        if(Path is null)
        {
            return FlagFailure; 
        }

        return FileHandler.SerializeWrite(this, Path);
    }

    static State GetConfig<T>()
    {
        if(Path is null)
        {
            return FlagFailure;
        }

        return FileHandler.ReadDeserialize<T>(Path);
    }
}