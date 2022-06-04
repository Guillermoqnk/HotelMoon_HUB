
public class HotelLegsReponse
{
    public Result[] results { get; set; }
}

public class Result
{
    public int room { get; set; }
    public int meal { get; set; }
    public bool canCancel { get; set; }
    public float price { get; set; }
}

