using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Collections.Generic;
using Domain;
using System.Text;
using DataAccess;

namespace Test
{
    public class BookControllerTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        public HttpClient Client { get; }

        readonly SampleContext db;

        public BookControllerTests(WebApplicationFactory<Api.Startup> fixture)
        {
            Client = fixture.CreateClient();
            db = (SampleContext)fixture.Services.GetService(typeof(SampleContext));
        }

        [Fact]
        public async Task Book_List_NoQuery()
        {
            var response = await Client.GetAsync("api/Book/List?query=");
            Assert.True(response.StatusCode == HttpStatusCode.OK);
            var bookList = JsonConvert.DeserializeObject<List<ListBookModel>>(await response.Content.ReadAsStringAsync());
            Assert.True(bookList.Count > 1);
        }

        [Fact]
        public async Task Book_List_WithQuery()
        {
            var response = await Client.GetAsync("api/Book/List?query=ount");
            Assert.True(response.StatusCode == HttpStatusCode.OK);
            var bookList = JsonConvert.DeserializeObject<List<ListBookModel>>(await response.Content.ReadAsStringAsync());
            Assert.True(bookList.Count == 1);
        }

        [Fact]
        public async Task Book_New_NameCannotBeBlank()
        {
            var postingData = new NewBookModel { Name = "", PageCount = 10 };

            var response = await Client.PostAsync("api/Book/New", new StringContent(JsonConvert.SerializeObject(postingData), Encoding.UTF8, "application/json"));

            Assert.True(response.StatusCode == HttpStatusCode.OK);

            var result = JsonConvert.DeserializeObject<Result<NewBookModel>>(await response.Content.ReadAsStringAsync());

            Assert.True(result.IsErrorExists);
            Assert.True(result.ErrorList.Count == 1);
        }

        [Fact]
        public async Task Book_New_NameNotBlankButPageCountSmaller()
        {
            var postingData = new NewBookModel { Name = "Lord Of The Rings", PageCount = 10 };

            var response = await Client.PostAsync("api/Book/New", new StringContent(JsonConvert.SerializeObject(postingData), Encoding.UTF8, "application/json"));

            Assert.True(response.StatusCode == HttpStatusCode.OK);

            var result = JsonConvert.DeserializeObject<Result<NewBookModel>>(await response.Content.ReadAsStringAsync());

            Assert.True(result.IsErrorExists);
            Assert.True(result.ErrorList.Count == 1);
        }

        [Fact]
        public async Task Book_New_Success()
        {
            var postingData = new NewBookModel { Name = "Lord Of The Rings", PageCount = 500 };

            var response = await Client.PostAsync("api/Book/New", new StringContent(JsonConvert.SerializeObject(postingData), Encoding.UTF8, "application/json"));

            Assert.True(response.StatusCode == HttpStatusCode.OK);

            var result = JsonConvert.DeserializeObject<Result<NewBookModel>>(await response.Content.ReadAsStringAsync());

            Assert.True(!result.IsErrorExists);

            var lastRecord = db.Books.Find(result.Id);

            Assert.True(lastRecord != null);

            if (lastRecord != null)
            {
                Assert.True(lastRecord.Name == postingData.Name);
                Assert.True(lastRecord.PageCount == postingData.PageCount);
            }
        }

    }
}
