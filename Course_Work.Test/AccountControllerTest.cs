using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using Course_Work.Context;
using Course_Work.Controllers;
using Microsoft.AspNetCore.Identity;
using Course_Work.Models;

namespace SuperCource.Test
{
    public class AccountControllerTest
    {
        private dbcontext db;
        [Fact]
        public void IndexReturnsAViewResultWithAListOfPhones()
        {
            // Arrange
            var userManagerMoq = new Mock<UserManager<User>>();
            var signInManagerMoq = new Mock<SignInManager<User>>();
            
        var controller = new AccountController(userManagerMoq.Object, signInManagerMoq.Object, db);

            // Act
            var result = controller.Register();

            // Assert
            Assert.IsType<ViewResult>(result);
        }
    }
}
