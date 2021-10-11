using System;
using System.IO;
using System.Collections.Generic;
using Assignment4.Core;
using Assignment4.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Xunit;
using static Assignment4.Core.Response;


namespace Assignment4.Entities.Tests 
{
    // Your code must use an in-memory database for testing.

    
    public class TaskRepositoryTests : IDisposable
    {
        private readonly KanbanContext _context;
        private readonly TaskRepository _repository;

        public TaskRepositoryTests() 
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var builder = new DbContextOptionsBuilder<KanbanContext>();
            builder.UseSqlite(connection);
            var context = new KanbanContext(builder.Options);
            context.Database.EnsureCreated();

                
            // _context.SaveChanges();

            _context = context;
            _repository = new TaskRepository(_context);
        }

        // Update_given_non_existing_id_returns_NotFound
        [Fact]
        public void Trying_To_Update_Non_Existing_Task_Should_Return_Not_Found() 
        {
            var repository = new TaskRepository(_context); 

            var task = new TaskUpdateDTO{
                Id = 696969,
                Title = "Din mor",
                Description = "Din far", 
                AssignedToId = 0,
                State = State.Active,   
            };

            var updated = repository.Update(task);

            Assert.Equal(NotFound, updated);
        }
        
        [Fact]
        public void Trying_To_Delete_Non_Existing_Task_Should_Return_Not_Found() 
        {
            //var delete = _repository.Delete(TaskDTO);

            //Assert.Equal(NotFound, delete);
        }

        //Create, Read, and Update should return a proper Response.

        //Your are not allowed to write throw new ... - use the Response instead.

        //If a task, tag, or user is not found, return null.

        // Only tasks with the state New can be deleted from the database.

        // Deleting a task which is Active should set its state to Removed.

        // Deleting a task which is Resolved, Closed, or Removed should return Conflict.

        // Creating a task will set its state to New and Created/StateUpdated to current time in UTC.

        // Create/update task must allow for editing tags.

        // Updating the State of a task will change the StateUpdated to current time in UTC.

        // Assigning a user which does not exist should return BadRequest.

        // TaskRepository may not depend on TagRepository or UserRepository.
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
