using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Task.API;
using Task.API.Entity;

namespace Task.Web.Controllers
{
    public class DataController : Controller
    {
        private readonly HttpClient _httpclient;
        public DataController(HttpClient httpClient)
        {
            _httpclient = httpClient;
        }

        public async Task<IActionResult> List()
        {

            var response = await _httpclient.GetAsync("https://seffaflik.epias.com.tr/transparency/service/market/intra-day-trade-history?endDate=2021-02-26&startDate=2021-02-26");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var Datas = JsonConvert.DeserializeObject<Base>(result);
                //var sumPrice = Datas.Body.intraDayTradeHistoryList.GroupBy(x=>x.Conract).Select(x=>x.Sum(q=>q.Price));
                var data = Datas.Body.intraDayTradeHistoryList.GroupBy(x => x.Conract).Select(x => new Data
                {Conract = x.Key,
                Price = x.Sum(i=>(i.Price*i.Quantity)/10),
                Quantity = x.Sum(a=>a.Quantity/10)
                }).ToList();
                return View(data);
            }
            else
            {
                return null;
            }
        }
    }
}
