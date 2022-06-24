using KpProjects.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KpProjects.Connector
{
    public class KpProjectsApiClient
    {
        private HttpClient _httpClient;

        public KpProjectsApiClient(string baseAddress)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseAddress);

            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<TDataClass>> LoadList<TDataClass>()
            where TDataClass : DataClass
        {
            TDataClass[] items = new TDataClass[0];

            HttpResponseMessage response = await _httpClient.GetAsync($"{typeof(TDataClass).Name}");

            if (response.IsSuccessStatusCode)
            {
                items = await response.Content.ReadAsAsync<TDataClass[]>();
            }

            return items?.ToList();
        }
    }
}
