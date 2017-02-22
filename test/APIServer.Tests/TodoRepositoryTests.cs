using Xunit;
using APIServer.Models;
using System.Threading.Tasks;
using System.Linq;

namespace APIServer.Tests
{
    public class TodoRepositoryTests
    {
        [Fact]
        public async Task CanAddAndGetAllItems()
        {
            //Arange
            ITodoRepository repo = TodoRepository.Create();
            var item1 = new TodoItem() { Name = "Item1", Description = "Hello World" };
            var item2 = new TodoItem() { Name = "Item2", Description = "World Hello" };

            //Act
            await repo.AddItem(item1);
            await repo.AddItem(item2);
            var todos = await repo.GetAllItems();
            var todoArray = todos.ToArray();

            var todo1 = todoArray.First(i => i.Name == item1.Name);
            var todo2 = todoArray.First(i => i.Name == item2.Name);

            await repo.Clear();

            //Assert
            Assert.Equal(todoArray.Length, 2);

            Assert.Equal(todo1, item1);
            Assert.Equal(todo2, item2);
        }

        [Fact]
        public async Task CanGetItem()
        {
            //Arange
            ITodoRepository repo = TodoRepository.Create();
            var item = new TodoItem() { Name = "Item1", Description = "Hello World" };

            //Act
            item = await repo.AddItem(item);
            var todo = await repo.GetItem(item.ID);

            await repo.Clear();

            //Assert
            Assert.NotNull(todo);
            Assert.Equal(todo, item);
        }

        [Fact]
        public async Task CanAddThenRemoveItems()
        {
            //Arange
            ITodoRepository repo = TodoRepository.Create();
            var item1 = new TodoItem() { Name = "Item1", Description = "Hello World" };
            var item2 = new TodoItem() { Name = "Item2", Description = "World Hello" };

            //Act
            item1 = await repo.AddItem(item1);
            item2 = await repo.AddItem(item2);
            var todos = await repo.GetAllItems();
            var todoArray = todos.ToArray();
            var originalCount = todoArray.Length;
            await repo.RemoveItem(item1.ID);
            todos = await repo.GetAllItems();
            todoArray = todos.ToArray();
            var todo = await repo.GetItem(item2.ID);

            await repo.Clear();


            //Assert
            Assert.NotNull(todoArray);
            Assert.Equal(originalCount, 2);
            Assert.Equal(todoArray.Length, 1);
            
            Assert.NotNull(todo);
            Assert.Equal(todo, item2);
        }

        [Fact]
        public async Task CanAddThenUpdateAnItem()
        {
            //Arange
            ITodoRepository repo = TodoRepository.Create();
            var item = new TodoItem() { Name = "My Item", Description = "Hello World" };

            //Act
            item = await repo.AddItem(item);
            item.Description = "World Hello";
            var retItem = await repo.UpdateItem(item);
            
            var todos = await repo.GetAllItems();
            var todoArray = todos.ToArray();

            await repo.Clear();


            //Assert
            Assert.NotNull(todoArray);
            Assert.Equal(todoArray.Length, 1);
            Assert.Equal(todoArray[0], item);
        }

        [Fact]
        public async Task TodoRepositoryCanBeCreatedMultipleTimes()
        {
            //Arange
            ITodoRepository repo1 = TodoRepository.Create();
            ITodoRepository repo2 = TodoRepository.Create();
            var item1 = new TodoItem() { Name = "Item1", Description = "Hello World" };
            var item2 = new TodoItem() { Name = "Item2", Description = "World Hello" };

            //Act
            await repo1.AddItem(item1);
            await repo2.AddItem(item2);
            var todos = await repo1.GetAllItems();
            var todoArray = todos.ToArray();

            var todo1 = todoArray.First(i => i.Name == item1.Name);
            var todo2 = todoArray.First(i => i.Name == item2.Name);

            await repo1.Clear();

            //Assert
            Assert.Equal(todoArray.Length, 2);

            Assert.Equal(todo1, item1);
            Assert.Equal(todo2, item2);
        }
    }
}