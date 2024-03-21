namespace UserSystem.Rating;

public static class RatingConfig
{
    public static int K { get; set; } = 32;
    public static int V { get; set; } = 4;
    public static int ExpectedOutcomeModifier { get; set; } = 400;
    public static int InitialRating { get; set; } = 750;
    public static int MinimumRating { get; set; } = 200;
}
