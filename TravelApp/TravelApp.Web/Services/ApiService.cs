using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TravelApp.Web.Models;

namespace TravelApp.Web.Services
{
    public class ApiService
    {
        #region Fields
        private readonly HttpClient _httpClient;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiService"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the transport types asynchronous.
        /// </summary>
        /// <returns>List<TransportTypeModel></returns>
        /// <exception cref="System.Exception">Error occured while getting Transport types</exception>
        public async Task<List<TransportTypeModel>> GetTransportTypesAsync()
        {
            var response = await _httpClient.GetAsync("/api/TransportType/GetList");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<TransportTypeModel>>(
                    await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Error occured while getting Transport types");
            }
        }

        /// <summary>
        /// Gets the travel details asynchronous.
        /// </summary>
        /// <param name="searchModel">The search model.</param>
        /// <returns>List<TravelModel></returns>
        /// <exception cref="System.Exception">Error occured while getting travel details</exception>
        public async Task<List<TravelModel>> GetTravelDetailsAsync(SearchModel searchModel)
        {
            var queryString = $"TravelType={searchModel.TravelType}&TravelDate={searchModel.TravelDate}&Source={HttpUtility.UrlEncode(searchModel.Source)}&Destination={HttpUtility.UrlEncode(searchModel.Destination)}";

            var response = await _httpClient.GetAsync($"/api/Fare/GetList?{queryString}");

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<TravelModel>>(
                    await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("Error occured while getting travel details");
            }
        }
        #endregion
    }
}
