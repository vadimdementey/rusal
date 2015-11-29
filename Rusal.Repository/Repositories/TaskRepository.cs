using Rusal.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rusal.Interfaces;
using Rusal.Interfaces.Filtration;
using Rusal.Entities;
using System.Data.Entity;

namespace Rusal.Repository.Repositories
{
    internal class TaskRepository : RepositoryBase, ITaskRepository
    {

        public TaskRepository(RepositoryFactory factory) : base(factory) { }



        public ITask AddNewTask(Guid? parentTaskId, Guid authorId, Guid employeeId,  string name)
        {
            TaskEntity newTask = CreateNew<TaskEntity>();

            newTask.ParentTaskId    = parentTaskId;
            newTask.AuthorId        = authorId;
            newTask.EmployeeId      = employeeId;
            newTask.CreatedDateTime = DateTime.Now;
            newTask.Name            = name;


            Context.SaveChanges();
            return newTask;
        }


        private IQueryable<TaskEntity> SetOfTask()
        {
            return Context.Set<TaskEntity>()
                        .Include("Author")
                        .Include("EmployeeTo")
                        .AsNoTracking();

        }


        public ITask GetTask(Guid taskId)
        {
          return SetOfTask().FirstOrDefault(x => x.Id == taskId);
        }

        public IPage<ITask> GetTasksByFilter(ITaskFilter filter)
        {

            IQueryable<TaskEntity> tasks = SetOfTask();


            if (filter.PriorityCode.HasValue)
            {
                tasks = tasks.Where(x => x.PriorityCode == filter.PriorityCode);
            }

            if (filter.StartCreatedDate.HasValue)
            {
                DateTime from = filter.StartCreatedDate.Value.Date;
                tasks = tasks.Where(x => x.CreatedDateTime >= from);
            }

            if (filter.EndCreatedDate.HasValue)
            {
                DateTime to = filter.EndCreatedDate.Value.Date.AddDays(1).AddSeconds(-1);
                tasks = tasks.Where(x => x.CreatedDateTime <= to);
            }

            if (!string.IsNullOrWhiteSpace(filter.SearchText))
            {
                tasks = tasks.Where(x => x.Name.Contains(filter.SearchText) || x.Description.Contains(filter.SearchText));
            }

            return new PageResult<ITask>(filter.PageIndex, filter.PageSize).ExecuteWith(tasks);
        }

        public IEnumerable<ITask> GetTasks(Guid employeeId, int maxCount)
        {
            return SetOfTask().Where(x => x.EmployeeId == employeeId).Take(maxCount).ToArray();
        }

        public ITask GetTaskWithChilds(Guid taskId)
        {
            TaskEntity parentTask = SetOfTask().FirstOrDefault(x => x.Id == taskId);

            if (parentTask != null)
            {
                parentTask.ChildTasks = SetOfTask().Where  (x => x.ParentTaskId == taskId)
                                                   .AsEnumerable()
                                                   .Select(x => 
                                                   {
                                                       x.ParentTask = parentTask;
                                                       return x;
                                                   })   
                                                   .ToArray(); 
            }

            return parentTask;
        }

        public void RemoveTask(Guid taskId)
        {

            var taskSet     = Context.Set<TaskEntity>().AsNoTracking();

            TaskEntity task = taskSet.FirstOrDefault(x => x.Id == taskId);


            if (task == null || taskSet.Any(x => x.ParentTaskId == taskId))
            {
                return;
            }


            Context.Set<TaskEntity>().Remove(task);
            Context.SaveChanges();

        }

        public void UpdateTask(ITask task)
        {
            TaskEntity taskEntity = Context.Set<TaskEntity>().FirstOrDefault(x => x.Id == task.Id);

            if (taskEntity == null)
            {
                return;
            }

            if (task.Name != taskEntity.Name)
            {
                taskEntity.Name = task.Name;
            }


            if (task.Completed != taskEntity.Completed)
            {
                taskEntity.Completed = task.Completed;
            }

            if (task.Description != taskEntity.Description)
            {
                taskEntity.Name = task.Name;
            }

            Context.SaveChanges();

        }

      
    }
}
