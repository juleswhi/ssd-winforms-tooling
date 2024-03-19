using System.Collections.Immutable;

namespace Scraper;

/// <summary>
/// A list of ImmutableHashsets that contain preset values for each enum value in ScrapeType
/// </summary>
public static class ScrapeSets
{
    public static readonly ImmutableHashSet<string> DEFAULT =
        ImmutableHashSet.Create("Size", "Location", "ForeColor", "BackColor", "Font");
}
