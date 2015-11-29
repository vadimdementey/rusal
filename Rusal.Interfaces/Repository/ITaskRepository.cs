using Rusal.Interfaces.Filtration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Interfaces.Repository
{
    public interface ITaskRepository
    {
        ITask GetTask(Guid taskId);
        ITask GetTaskWithChilds(Guid taskId);
        IEnumerable<ITask> GetTasks(Guid employeeId, int maxCount);
        IPage<ITask> GetTasksByFilter(ITaskFilter filter);
        ITask AddNewTask(Guid? parentTask , Guid authorId, Guid employeeId, string name);
        void UpdateTask(ITask task);
        void RemoveTask(Guid taskId);
    }
}
