using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

class Matchflix {

    private string MovieId;


    public string Title { get; private set; }
    public string Plot { get; private set; }
    public string RunTime { get; private set; }
    public string MatLabel { get; private set; }
    public string Img { get; private set; }
    public string Genre { get; private set; }
    public string Year { get; private set; }
    public string Synopsis { get; private set; }


    private List<string> Countries;
    private GetDetails Details;
    public Matchflix(string movieid) {
        this.MovieId = movieid;
    }

    public async Task GetCountriesAsync() {


        var client = new HttpClient();

        var request = new HttpRequestMessage {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://unogsng.p.rapidapi.com/title?netflixid=81043135"),
            Headers = {
                { "x-rapidapi-key", "44f2c854c9msh70052d5b0318de0p115f87jsna34187fcf3fb" },
                { "x-rapidapi-host", "unogsng.p.rapidapi.com" },
            },
        };

        using (var response = await client.SendAsync(request)) {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();

            var Countries = JsonSerializer.Deserialize<GetCountries>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            List<string> countries = new List<string>();

            for (int i = 0; i < Countries.Results.Length; i++) {
                countries.Add(Countries.Results[i].Country);
            }
            this.Countries = countries;
        }


    }

    public async Task GetDetailsAysnc() {

        var client = new HttpClient();

        var request = new HttpRequestMessage {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://unogsng.p.rapidapi.com/title?netflixid=81043135"),
            Headers = {
                { "x-rapidapi-key", "44f2c854c9msh70052d5b0318de0p115f87jsna34187fcf3fb" },
                { "x-rapidapi-host", "unogsng.p.rapidapi.com" },
            },
        };

        using (var response = await client.SendAsync(request)) {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            this.Details = JsonSerializer.Deserialize<GetDetails>(body, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }


        // You can obviously pull more information from the response from below //

        this.Title = Details.Results[0].Title.ToString();
        this.Plot = Details.Results[0].Imdbplot.ToString();
        this.Year = Details.Results[0].Year.ToString();
        this.RunTime = Details.Results[0].Imdbruntime.ToString();
        this.MatLabel = Details.Results[0].Matlabel.ToString();
        this.Img = Details.Results[0].Img.ToString();
        this.Genre = Details.Results[0].Imdbgenre.ToString();
        this.Synopsis = Details.Results[0].Synopsis.ToString();


    }

    public bool IsInCountry(string country) {

        if (this.Countries.Contains(country)) {
            return true;
        }
        else {
            return false;
        }

    }



}


public class GetDetails {
    public double Elapse { get; set; }

    public DetailResult[] Results { get; set; }
}

public class DetailResult {
    public object Matlevel { get; set; }

    public long Year { get; set; }

    public string Img { get; set; }

    public string Title { get; set; }

    public string Imdbawards { get; set; }

    public string Imdbruntime { get; set; }

    public string Matlabel { get; set; }

    public string Imdbgenre { get; set; }

    public string Synopsis { get; set; }

    public string Imdbplot { get; set; }

}

public class GetCountries {
    public double Elapse { get; set; }

    public long Total { get; set; }

    public CountryResult[] Results { get; set; }
}

public class CountryResult {
    public string Uhd { get; set; }

    public object Expiredate { get; set; }

    public string Subtitle { get; set; }

    public string Cc { get; set; }

    public string Country { get; set; }

    public string Hd { get; set; }

}
