namespace Restaurant.RestApi.Tests
{
    public class HomeTests
    {
        [Fact]
        public async Task HomeIsOk()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7113", UriKind.Absolute);


            var response = await client
                .GetAsync(new Uri("", UriKind.Relative))
                .ConfigureAwait(false);

            Assert.True(
                response.IsSuccessStatusCode,
                $"Actual status code: {response.StatusCode}.");
        }
    }
}