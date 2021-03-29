using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Task.API.Entity;

namespace Task.API
{
    public class APIService
    {
        private readonly HttpClient _httpclient;
        public APIService(HttpClient httpClient)
        {
            _httpclient = httpClient;
        }

        public async Task<IEnumerable<Data>> GetAllAsync()
        {
            IEnumerable<Data> Datas = null;
            var response = await _httpclient.GetAsync("baseUrl");
            if (response.IsSuccessStatusCode)
            {
                Datas = JsonConvert.DeserializeObject<IEnumerable<Data>>(await response.Content.ReadAsStringAsync());
                return Datas;
            }
            else
            {
                return null;
            }
        }
    }
}
