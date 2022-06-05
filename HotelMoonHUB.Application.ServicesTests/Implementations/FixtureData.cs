
public static class FixtureData
{
    #region HUBRequest

    public static HUBRequest hubRequest = new HUBRequest()
    {
        hotelId = 1,
        checkIn = "2022-2-12",
        checkOut = "2022-2-15",
        numberOfGuests = 3,
        numberOfRooms = 1,
        currency = "EUR"
    };

    #endregion

    #region HUBRequest_null

    public static HUBRequest? hubRequest_Null = null;

    #endregion

    public static HUBReponse? hubReponse_null = null;

    #region HUBReponse_Full

    public static HUBReponse hubReponse = new HUBReponse()
    {
        rooms = new Room[]
        {
            room1,
            room2,
            room3,
        },
    };

    public static Room room1 = new Room()
    {
        roomId = 1,
        rates = new Rate[]
        {
            rate1,
        },
    };

    public static Room room2 = new Room()
    {
        roomId = 2,
        rates = new Rate[]
        {
            rate1,
            rate2,
        },
    };

    public static Room room3 = new Room()
    {
        roomId = 3,
        rates = new Rate[]
        {
            rate1,
            rate3,
        },
    };

    public static Rate rate1 = new Rate()
    {
        mealPlanId = 1,
        isCancellable = true,
        price = 145
    };

    public static Rate rate2 = new Rate()
    {
        mealPlanId = 2,
        isCancellable = true,
        price = 165
    };

    public static Rate rate3 = new Rate()
    {
        mealPlanId = 1,
        isCancellable = true,
        price = 155
    };

    #endregion

    #region HUBReponse_WithoutRooms

    public static HUBReponse hubReponse_NoRooms = new HUBReponse()
    {
        rooms = new Room[0]
    };

    #endregion

    #region HUBReponse_WithoutRates

    public static HUBReponse hubReponse_NoRates = new HUBReponse()
    {
        rooms = new Room[]
        {
            room4,
            room5,
            room6,
        },
    };

    public static Room room4 = new Room()
    {
        roomId = 1,
        rates = new Rate[0],
    };

    public static Room room5 = new Room()
    {
        roomId = 2,
        rates = new Rate[0],
    };

    public static Room room6 = new Room()
    {
        roomId = 3,
        rates = new Rate[0],
    };

    #endregion

    #region HotelLegsRequest

    public static HotelLegsRequest hotelLegsRequest = new HotelLegsRequest()
    {
        hotel = 1,
        checkInDate = "2022-2-12",
        numberOfNights = 4,
        guests = 3,
        rooms = 1,
        currency = "EUR"
    };

    #endregion

    #region HotelLegsReponse_Full
    public static HotelLegsReponse hotelLegsReponse_Full = new HotelLegsReponse()
    {
        results = new Result[]
        {
            result1,
            result2,
            result3,
        },
    };

    public static Result result1 = new Result()
    {
        room = 1,
        meal = 2,
        canCancel = false,
        price = 155
    };

    public static Result result2 = new Result()
    {
        room = 1,
        meal = 1,
        canCancel = true,
        price = 145
    };

    public static Result result3 = new Result()
    {
        room = 2,
        meal = 1,
        canCancel = false,
        price = 143
    };

    #endregion

    #region HotelLegsReponse_WithoutResults
    public static HotelLegsReponse hotelLegsReponse_NoResults = new HotelLegsReponse()
    {
        results = new Result[0],
    };
    #endregion
}
