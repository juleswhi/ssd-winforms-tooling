using Conf = UserSystem.Rating.RatingConfig;

namespace UserSystem.Rating;

/// <summary>
/// Used to store a user score, modelled after Arpad Elo's famous system;
/// </summary>
public class Rating
{

    public int Value { get; set; } = Conf.InitialRating;

    public List<int> PastRatings { get; } = new();

    /// <summary>
    /// Allows the user to update their elo after a matchup
    /// </summary>
    /// <param name="win"></param>
    /// <param name="opponentRating"></param>
    public State Update(float result, int opponentRating)
    {
        if (result < 0 || result > 1)
        {
            return FlagFailure;
        }

        float qa = (float)Math.Pow(10, Value / 400);
        float qb = (float)Math.Pow(10, opponentRating / 400);

        float ea = qa / (qa + qb);

        float ra = Value + Conf.K * (result - ea) + result * Conf.V;

        if(ra < Conf.MinimumRating)
        {
            return FlagFailure;
        }

        PastRatings.Add(Value);

        Value = (int)ra;

        return FlagSuccess;
    }
}
