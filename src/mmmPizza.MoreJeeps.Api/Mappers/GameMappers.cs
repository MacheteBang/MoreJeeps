namespace mmmPizza.MoreJeeps.Mappers;

public static class GameMappers
{
    public static GameResponse ToGameResponse(this Game model)
    {
        return new GameResponse
        {
            PlayerScores = model.PlayerScores
        };
    }
}