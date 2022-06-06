
public class HUBReponse
{
    public Room[] rooms { get; set; }
}

public class Room
{
    public int roomId { get; set; }
    public Rate[]? rates    { get; set; }
}

public class Rate
{
    public int mealPlanId { get; set; }
    public bool isCancellable { get; set; }
    public float price { get; set; }
}

