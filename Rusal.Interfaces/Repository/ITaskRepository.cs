using Rusal.Interfaces.Filtration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Interfaces.Repository
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetTasks(Guid employeeId, int maxCount);
        IPage<Task> GetTasks(ITaskFilter filter);
        ITask AddNewTask(Guid authorId, Guid employeeId, string name);
        void UpdateTask(ITask task);
    }
}
