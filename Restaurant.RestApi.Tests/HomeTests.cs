namespace Restaurant.RestApi.Tests
{
    public class HomeTests
    {
        //configures a test client that receives a success status code when establishing connection to Home
        [Fact]
        public async Task HomeIsOk()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7113/", UriKind.Absolute);

            var response = await client
                .GetAsync(new Uri("", UriKind.Relative))
                .ConfigureAwait(false);

            Assert.True(
                response.IsSuccessStatusCode,
                $"Actual status code: {response.StatusCode}.");
        }

        //configures a test client that receives a JSON 
        [Fact] 
        public async Task HomeReturnsJson() {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7113/", UriKind.Absolute);

            using var request = new HttpRequestMessage(HttpMethod.Get, "");
            request.Headers.Accept.ParseAdd("application/json");

            var response = await client.SendAsync(request);

            Assert.True(
                response.IsSuccessStatusCode,
                $"Actual status code: {response.StatusCode}.");
            Assert.Equal(
                "application/json",
                response.Content.Headers.ContentType?.MediaType);
        }
    }
}