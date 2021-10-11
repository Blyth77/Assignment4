using Assignment4.Core;
using System.Collections.Generic;
using System;
using static Assignment4.Core.Response;

namespace Assignment4.Entities

{
    public class TaskRepository : ITaskRepository
    {
        private readonly IKanbanContext _context;


        public TaskRepository(IKanbanContext context)
        {
            _context = context;
        }

        public IReadOnlyCollection<TaskDTO> All()
        {
            throw new NotImplementedException();
        }

        
        public int Create(TaskDTO task) 
        {
            throw new NotImplementedException();
        }

        public void Delete(int taskId){
           // if (!taskId.)

           /* var year = Wizard.Wizards.Value.Where(w => w.Name.StartsWith("Darth"))
                                            .OrderBy(w => w.Year)
                                            .Select(w => w.Year)
                                            .First();

            return year; */
            throw new NotImplementedException();
        }

        public TaskDetailsDTO FindById(int id) 
        {
            throw new NotImplementedException();
        }

        public Response Update(TaskUpdateDTO task) 
        {
            var entity = _context.Tasks.Find(task.Id);

            if (entity == null)
            { 
                return NotFound;
            }

            entity.Id = task.Id;
            entity.Title = task.Title;
            //entity.AssignedTo = task.AssignedTo;
            entity.Description = task.Description;
            entity.State = task.State;
            //entity.Tags = task.Tags;
            

            _context.SaveChanges();

            return Updated;

           //return Response.NotFound;
        }

        public void Dispose() 
        {
            throw new NotImplementedException();
        }
    }
}
