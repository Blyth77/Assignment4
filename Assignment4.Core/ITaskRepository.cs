using System;
using System.Collections.Generic;

namespace Assignment4.Core
{
    public interface ITaskRepository
    {
        (Response Response, int TaskId) Create(TaskCreateDTO task);
        IReadOnlyCollection<TaskDTO> ReadAll();
        IReadOnlyCollection<TaskDTO> ReadAllRemoved();
        IReadOnlyCollection<TaskDTO> ReadAllByTag(string tag);
        IReadOnlyCollection<TaskDTO> ReadAllByUser(int userId);
        IReadOnlyCollection<TaskDTO> ReadAllByState(State state);
        TaskDetailsDTO Read(int taskId);
        Response Update(TaskUpdateDTO task);
        Response Delete(int taskId);
    }
}




// public interface ITaskRepository : IDisposable
    // {
    //     IReadOnlyCollection<TaskDTO> All();

    //     /// <summary>
    //     ///
    //     /// </summary>
    //     /// <param name="task"></param>
    //     /// <returns>The id of the newly created task</returns>
    //     int Create(TaskDTO task);

    //     void Delete(int taskId);

    //     TaskDetailsDTO FindById(int id);

    //     Response Update(TaskUpdateDTO task);

    //     Response Delete(TaskUpdateDTO task);
    // }