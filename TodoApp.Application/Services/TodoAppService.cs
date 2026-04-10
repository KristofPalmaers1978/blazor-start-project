using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Application.Interfaces;
using TodoApp.Domain.Entities;

namespace TodoApp.Application.Services
{
    public class TodoAppService
    {
        private readonly ITodoRepository _repository;

        public TodoAppService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TodoItem>> GetTodosAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<TodoItem?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task AddTodoAsync(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be empty");

            var todo = new TodoItem
            {
                Title = title,
                IsDone = false
            };

            await _repository.AddAsync(todo);
        }

        public Task UpdateTodoAsync(TodoItem item)
        {
            if (string.IsNullOrWhiteSpace(item.Title))
                throw new ArgumentException("Title cannot be empty");

            return _repository.UpdateAsync(item);
        }

        public Task DeleteTodoAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public async Task ToggleDoneAsync(int id)
        {
            var todo = await _repository.GetByIdAsync(id);

            if (todo == null)
                throw new Exception("Todo not found");

            todo.IsDone = !todo.IsDone;

            await _repository.UpdateAsync(todo);
        }
    }
}
