namespace Scraper;

/// <summary>
/// A static configuration class 
/// </summary>
public static class ScraperConfig
{
    /// <summary>
    /// Where the scraped information should be saved
    /// </summary>
    public static string Path { get; set; } = "FormDetails.txt";

    /// <summary>
    /// What type of properties should be scraped
    /// </summary>
    public static ScrapeType Type { get; set; }

    /// <summary>
    /// A custom filter to scrape by.
    /// Only scrapes by this filter if the ScraperConfig.Type is CUSTOM
    /// </summary>
    public static HashSet<string> ScrapeFilter { get; set; } = [];
}
