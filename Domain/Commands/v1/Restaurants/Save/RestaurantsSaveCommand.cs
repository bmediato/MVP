namespace Domain.Commands.v1.Restaurants.Save;

public class RestaurantsSaveCommand : IRequest<RestaurantsSaveCommandResponse>
{
    public RestaurantsSaveCommand(string name,
        RestaurantCategory category,
        string description,
        string address,
        string phoneNumber,
        string logo,
        string banner,
        IEnumerable<Dishes> dishes)
    {
        Name = name;
        Category = category;
        Description = description;
        Address = address;
        PhoneNumber = phoneNumber;
        Logo = logo;
        Dishes = dishes;
        Banner = banner;
        UserId = Guid.NewGuid();
    }
    public Guid? UserId { get; set; }
    public string Name { get; set; }
    public RestaurantCategory Category { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Logo { get; set; }
    public string Banner { get; set; }
    public IEnumerable<Dishes> Dishes { get; set; }
}
public class Dishes
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Image { get; set; }
}