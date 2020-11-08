using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace Matchflix__GITHUB_ {
    class Program {

        public static async Task Main() {

            string movieid = "81043135";
            var matchflix = new Matchflix(movieid);

            // You must call `getdetails` and `getcountries` before writing info. //

            await matchflix.GetDetailsAysnc();
            await matchflix.GetCountriesAsync();

            Console.WriteLine(matchflix.Title);
            // Output = "Hot Gimmick: Girl Meets Boy" //
        }

    }
}
