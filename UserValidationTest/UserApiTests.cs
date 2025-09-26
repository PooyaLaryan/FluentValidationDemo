using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FluentValidationDemo.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace UserValidationTest
{

    public class ApiResponse<T>
    {
        public string message { get; set; } = "";
        public T data { get; set; }
    }


    public class UserApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public UserApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateUser_Should_Return_BadRequest_When_Invalid()
        {
            var user = new User
            {
                FirstName = "",   // نام خالی
                LastName = "Test",
                Age = 15,         // سن نامعتبر
                Email = "wrong"   // ایمیل نامعتبر
            };

            var response = await _client.PostAsJsonAsync("/user", user);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task CreateUser_Should_Return_Ok_When_Valid()
        {
            var user = new User
            {
                FirstName = "Pouya",
                LastName = "Lariyan",
                Age = 30,
                Email = "pouya@example.com"
            };

            var response = await _client.PostAsJsonAsync("/user", user);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadFromJsonAsync<ApiResponse<User>>();

            Assert.NotNull(result);
            Assert.Equal("کاربر با موفقیت ایجاد شد", result!.message);
            Assert.Equal("Pouya", result.data.FirstName);
            Assert.Equal("Lariyan", result.data.LastName);
        }

        //[Fact]
        //public async Task ShowRoutes()
        //{
        //    var response = await _client.GetAsync("/swagger/index.html");
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //}
    }
}
