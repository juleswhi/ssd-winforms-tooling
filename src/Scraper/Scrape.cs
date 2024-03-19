using System.Collections.Immutable;
using Config = Scraper.ScraperConfig;

namespace Scraper;

/// <summary>
/// Allows data of all forms in the project to be scraped and output in a file
/// </summary>
public static class Scraper
{
    /// <summary>
    /// Calls the base Scrape() method using a custom hashset
    /// </summary>
    /// <param name="hashset">A custom set of property names to filter by</param>
    public static void Scrape(HashSet<string> hashset)
    {
        Config.ScrapeFilter = hashset;

        // Ensure that the assembly is preserved
        Scrape(CUSTOM, Assembly.GetCallingAssembly());
    }

    /// <summary>
    /// This method scrapes all forms and outputs the data to a file
    /// </summary>
    /// <param name="scrapeType">The type that should be filtered by</param>
    /// <param name="assembly">The calling assembly</param>
    public static void Scrape(ScrapeType? scrapeType = null, Assembly? assembly = null)
    {
        // Grab the default stuff from config
        scrapeType ??= Config.Type;
        assembly ??= Assembly.GetCallingAssembly();

        if (!File.Exists(Config.Path))
        {
            File.Create(Config.Path);
        }

        // get rid of old data
        ClearFile(Config.Path);

        using StreamWriter sw = new(Config.Path, true);

        if (sw is null)
        {
            return;
        }

        Type[] types = assembly.GetTypes();

        Type form = typeof(Form);
        List<Type> forms = types.Where(x => x.IsSubclassOf(form) || x == form).ToList();

        foreach (Type type in forms)
        {
            var instance = Activator.CreateInstance(type);

            sw!.WriteLine($"--- {type.Name} ---");

            sw!.WriteLine();

            var controlProp = type.GetProperty("Controls");

            if (controlProp is null)
            {
                continue;
            }

            Control.ControlCollection? controls = controlProp.GetValue(instance) as Control.ControlCollection;

            if (controls is null)
            {
                continue;
            }


            ImmutableHashSet<string> filter = scrapeType switch
            {
                DEFAULT => ScrapeSets.DEFAULT,
                _ => Config.ScrapeFilter.ToImmutableHashSet()
            };

            if (filter is null)
            {
                continue;
            }

            foreach (Control control in controls)
            {
                sw!.WriteLine($"{control.Name}:");

                foreach (var str in GetInformation(control, filter))
                {
                    sw!.WriteLine(str);
                }

                sw!.WriteLine();
            }

            sw!.WriteLine();
        }
        GC.Collect();
    }


    /// <summary>
    /// Gets the property information of a control, and filters it by the appropriate hashset
    /// </summary>
    /// <typeparam name="T">The type of control to get information from</typeparam>
    /// <param name="control">The control itself</param>
    /// <param name="filter">The immutablehashet to filter through</param>
    /// <returns>All the keys and their values of the filtered properties</returns>
    private static IEnumerable<string> GetInformation<T>(T control, ImmutableHashSet<string> filter) where T : Control
    {
        var props = control.GetType().GetProperties();

        foreach (var prop in props)
        {
            if (filter is null || !filter.Contains(prop.Name))
            {
                continue;
            }

            string str;

            try
            {
                str = $"\t\t{prop.Name}: {PrettyPrint(prop.GetMethod?.Invoke(control, []))}";
            }
            catch (Exception)
            {
                continue;
            }

            yield return str;
        }
    }

    /// <summary>
    /// If the type is a common control property, print it in a more readable way
    /// </summary>
    /// <param name="obj">The object to check for</param>
    /// <returns>The prettified string</returns>
    private static string? PrettyPrint(object? obj)
    {
        // Refactor to switch
        if (obj is Font font)
        {
            return $"{font.Name} - {font.Size}px";
        }

        if (obj is Point point)
        {
            return $"[{point.X}, {point.Y}]";
        }

        if (obj is Size size)
        {
            return $"[{size.Width}, {size.Height}]";
        }

        return (string?)obj;
    }

    /// <summary>
    /// Overwrites contents of a file with null text
    /// </summary>
    /// <param name="path">The path to the file</param>
    private static void ClearFile(string path)
    {
        File.WriteAllText(path, "");
    }
}
