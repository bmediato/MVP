namespace Domain.Commands.v1.Restaurants.Save;

public class RestaurantsSaveCommandResponse
{
    public RestaurantsSaveCommandResponse Error(string message)
    {
        Success = false;
        Message = message;

        return this;
    }

    public bool Success { get; set; } = true;
    public string Message { get; set; }
}
