using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using src.Model;
using System.Linq;
namespace src.Services
{
    public interface IColorService
    {
        Task<Color> GetColor(string hexColorCode);
        Task<IEnumerable<Color>> GetColors();
    }

    public class ColorService : IColorService
    {
        private readonly HttpClient httpClient;

        public ColorService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Color>> GetColors()
        {
            var response = await httpClient.GetStringAsync("");
            var colors = JsonConvert.DeserializeObject<IEnumerable<Color>>(response);
            return colors;
        }

        public async Task<Color> GetColor(string hexColorCode)
        {
            // The sample api (https://sampleapis.com/css-color-names/api/colors)
            // only allow to get all data, maybe use cache?
            var response = await httpClient.GetStringAsync("");
            var colors = JsonConvert.DeserializeObject<IEnumerable<Color>>(response);
            var color = colors.FirstOrDefault( c => c.Hex.Substring(1) == hexColorCode);
            return color;
        }
    }
}
