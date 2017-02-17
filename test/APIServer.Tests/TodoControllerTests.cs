using Xunit;
using APIServer.Controllers;

namespace APIServer.Tests
{
    public class TodoControllerTests
    {
        [Fact]
        public void CanGetAllTodos()
        {
            //Arange
            var controller = new TodoController();

            //Act
            var todos = controller.Get();

            //Assert
            Assert.NotNull(todos);
            Assert.Empty(todos);
        }
    }
}
