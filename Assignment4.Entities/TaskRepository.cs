using Assignment4.Core;
using System.Collections.Generic;
using System;
using System.Linq;
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


        public Response Update(TaskUpdateDTO task)  
        {
            var entity = _context.Tasks.Find(task.Id);

            if (entity == null)
            { 
                return NotFound;
            }

            entity.Id = task.Id;
            entity.Title = task.Title;
            entity.Description = task.Description;
            entity.State = task.State;

            // Kan man ikke
            // Man kan lave forespørgsel i context efter alle tags der har Tag navne fra TaskUpdateDTO
            //entity.Tags = (ICollection<Tag>)task.Tags;
            
            _context.Tasks.Update(entity);

            return Updated;
        }

        public Response Delete(int taskId)
        {
            var entity = _context.Tasks.Find(taskId);
        
            if (entity == null)
            { 
                return NotFound;
            }
            if (entity.State == State.Active){
                entity.State = State.Removed;
                return Deleted;
            }

            if (entity.State != State.New){
                return Conflict;
            }
            
            entity.Id = taskId;
            _context.Tasks.Remove(entity);
            
            return Deleted;
        }

        public (Response Response, int TaskId) Create(TaskCreateDTO task)
        {
            var entity = _context.Tasks.Where(e => e.Title == task.Title).Single();

            if (entity != null)
            { 
                return (Conflict, entity.Id);
            }

            entity.Title = task.Title;
            entity.Id = task.AssignedToId.Value;
            entity.Description = task.Description;

            // Kan man ikke
            // Man kan lave forespørgsel i context efter alle tags der har Tag navne fra TaskUpdateDTO
            //entity.Tags = (ICollection<Tag>)task.Tags;

            entity.Tags = _context.Tags.Where(e => task.Tags.Contains(e.Name)).ToList(); 

            entity.State = State.New;
            entity.Created = DateTime.UtcNow;
            entity.StateUpdated = DateTime.UtcNow;
            

            _context.Tasks.Add(entity);
                       
            return(Created, entity.Id);
        }

        public TaskDetailsDTO Read(int taskId)
        {
            
            
            throw new NotImplementedException();
        }









        // public Response Delete(TaskUpdateDTO task)
        // {
        //     var entity = _context.Tasks.Find(task.Id);
        
        //     if (entity == null)
        //     { 
        //         return NotFound;
        //     }
            
        //     entity.Id = task.Id;
        //     _context.Tasks.Remove(entity);
            
        //     return Deleted;
        //     //throw new NotImplementedException();
        // }


        // public void Delete(int taskId){
        //    // if (!taskId.)

        //    /* var year = Wizard.Wizards.Value.Where(w => w.Name.StartsWith("Darth"))
        //                                     .OrderBy(w => w.Year)
        //                                     .Select(w => w.Year)
        //                                     .First();

        //     return year; */
        //     throw new NotImplementedException();
        // }



        // public IReadOnlyCollection<TaskDTO> All()
        // {
        //     throw new NotImplementedException();
        // }

        
        // public int Create(TaskDTO task) 
        // {
        //     throw new NotImplementedException();
        // }

        

        

        // public TaskDetailsDTO FindById(int id) 
        // {
        //     throw new NotImplementedException();
        // }

        

        // public void Dispose() 
        // {
        //     throw new NotImplementedException();
        // }




        


        public IReadOnlyCollection<TaskDTO> ReadAll()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<TaskDTO> ReadAllRemoved()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<TaskDTO> ReadAllByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<TaskDTO> ReadAllByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<TaskDTO> ReadAllByState(State state)
        {
            throw new NotImplementedException();
        }

        
    }
}
