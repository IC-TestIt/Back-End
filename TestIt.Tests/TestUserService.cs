using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Business;
using TestIt.Model.Entities;
using TestIt.Tests.MockRepositories;
using Xunit;

namespace TestIt.Tests
{
    public class TestUserService
    {
        public IUserService service;
        public MockUserRepository repository;

        public TestUserService()
        {
            repository = new MockUserRepository();
            service = new Business.Services.UserService(repository);
        }

        [Fact]
        public void TestValidLogin()
        {
            var result = service.ValidLogin("test@email.com", "test");

            Assert.True(result);
        }

        [Fact]
        public void TestInvalidLogin()
        {
            var result = service.ValidLogin("test@email", "pswd");

            Assert.False(result);
        }

        [Fact]
        public void TestEmptyLogin()
        {
            var result = service.ValidLogin("", "");

            Assert.False(result);
        }
    }
}
