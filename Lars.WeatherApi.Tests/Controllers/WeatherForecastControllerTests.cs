using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;

namespace Lars.WeatherApi.Tests.Controllers
{
    public class WeatherForecastControllerTests
        : IClassFixture<WebApplicationFactory<Lars.WeatherApi.Startup>>, IDisposable
    {
        private bool disposedValue;

        protected HttpClient Http { get; }

        public WeatherForecastControllerTests(WebApplicationFactory<Lars.WeatherApi.Startup> webApplicationFactory)
        {
            this.Http = webApplicationFactory.CreateClient();
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
            {
                return;
            }

            if (disposing)
            {
                this.Http.Dispose();
            }

            this.disposedValue = true;
        }

        public class Get : WeatherForecastControllerTests
        {
            public Get(WebApplicationFactory<Lars.WeatherApi.Startup> webApplicationFactory)
                : base(webApplicationFactory)
            {
            }

            protected string Endpoint { get; } = "/weatherforecast";

            [Fact]
            public async Task RespondsWithSuccess()
            {
                var response = await this.Http.GetAsync(this.Endpoint);

                response.EnsureSuccessStatusCode();
            }

            [Fact]
            public async Task RespondsWithA5DayWeatherForecast()
            {
                var response = await this.Http.GetAsync(this.Endpoint);

                var forecast = await this.ToJsonAsync<IEnumerable<WeatherForecast>>(response);
                Assert.Equal(5, forecast.Count());
            }

            private async Task<TValue> ToJsonAsync<TValue>(HttpResponseMessage response)
            {
                var content = await response.Content.ReadAsStreamAsync();

                return await JsonSerializer.DeserializeAsync<TValue>(content);
            }
        }
    }
}
