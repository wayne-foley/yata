using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIServer.Models
{
    public interface ITodoRepository {
        Task<IEnumerable<TodoItem>> GetAllItems();
        Task<TodoItem> GetItem(string id);

        Task<TodoItem> AddItem(TodoItem item);

        Task<TodoItem> UpdateItem(TodoItem item);

        Task RemoveItem(string id);

        Task Clear();
    }

    public class TodoRepository : ITodoRepository
    {
        private List<TodoItem> items = null;
        private static TodoRepository singleton = null;

        private TodoRepository() {
            if(items == null) {
                items = new List<TodoItem>();
            }
        }

        public static ITodoRepository Create()
        {
            if(singleton == null) {
                singleton = new TodoRepository();
            }
            return singleton;
        }

        Task<TodoItem> ITodoRepository.AddItem(TodoItem item)
        {
            if(String.IsNullOrEmpty(item.Name))
            {
                throw new Exception("Item must have a name");
            }
            
            item.ID = Guid.NewGuid().ToString();
            this.items.Add(item);
            
            return Task.FromResult(item);
        }

        Task ITodoRepository.RemoveItem(string id)
        {
            var item = items.Find(i => i.ID == id);
            items.Remove(item);
            return Task.FromResult(true);
        }

        Task ITodoRepository.Clear()
        {
            items.Clear();
            return Task.FromResult(true);
        }

        Task<IEnumerable<TodoItem>> ITodoRepository.GetAllItems()
        {
            return Task.FromResult<IEnumerable<TodoItem>>(items);
        }

        Task<TodoItem> ITodoRepository.GetItem(string id)
        {
            if(String.IsNullOrEmpty(id))
            {
                throw new Exception("ID cannot be blank");
            }
            
            var item = items.Find(i => i.ID == id);
            return Task.FromResult(item);
        }

        Task<TodoItem> ITodoRepository.UpdateItem(TodoItem item)
        {
            if(String.IsNullOrEmpty(item.ID))
            {
                throw new Exception("Item's ID cannot be blank");
            }

            var tmp = items.Find(i => i.ID == item.ID);
            items.Remove(tmp);
            items.Add(item);
            return Task.FromResult(item);
        }
    }
}