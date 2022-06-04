
using HotelMoonHUB.Domain.Entities.BaseSearchFormat;

public class HotelLegsRequest : BaseRequest
{
    public int hotel { get; set; }
    public string checkInDate { get; set; }
    public int numberOfNights { get; set; }
    public int guests { get; set; }
    public int rooms { get; set; }
    public string currency { get; set; }
}
