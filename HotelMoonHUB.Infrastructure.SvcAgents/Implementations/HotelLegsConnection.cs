using HotelMoonHUB.Infrastructure.SvcAgents.Contracts;

namespace HotelMoonHUB.Infrastructure.SvcAgents
{
    public class HotelLegsConnection : IHotelLegsConnection
    {

        public async Task<HotelLegsReponse> Search(HotelLegsRequest request)
        {
            //Here the request would be sent and we return the reponse

            return hotelLegsReponse; //This is an example for the execution
        }

        #region Example_Execution
        public HotelLegsReponse hotelLegsReponse = new HotelLegsReponse()
        {
            results = new Result[]
            {
                result1,
                result2,
                result3,
            }
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
    }
}
