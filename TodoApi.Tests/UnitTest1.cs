using unifacema_tde_devops.src.TodoApi.Models;

namespace TodoApi.Tests
{
    public class TodoItemTests
    {
        [Fact]
        public void CanChangeName()
        {
            // Arrange
            var todo = new TodoItem { Name = "Test Item" };

            // Act
            todo.Name = "New Name";

            // Assert
            Assert.Equal("New Name", todo.Name);
        }

        [Fact]
        public void IsComplete_DefaultsToFalse()
        {
            // Arrange & Act
            var todo = new TodoItem();

            // Assert
            Assert.False(todo.IsComplete);
        }
    }
}
