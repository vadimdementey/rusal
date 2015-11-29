using Microsoft.AspNet.Mvc;
using Rusal.Dto;
using Rusal.Dto.Filtration;
using Rusal.Interfaces;
using Rusal.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("tasks")]
    public class TaskController : Controller
    {
        private IUserContext userContext;
        private ITaskRepository repositoryContext;

        public TaskController(IUserContext userContext, ITaskRepository repositoryContext)
        {
            this.userContext = userContext;
            this.repositoryContext = repositoryContext;
        }


        [HttpGet("{id}")]
        public TaskDto GetTask(Guid id)
        {
            return new TaskDto(repositoryContext.GetTaskWithChilds(id));
        }


        [HttpGet("my")]
        public TaskDto[] GetMyTasks()
        {
            return repositoryContext.GetTasks(userContext.Sid, 10)
                                 .Select(x => new TaskDto(x))
                                 .ToArray();
        }


        [HttpPost]
        public PageDto<TaskDto, ITask> GetTasksByFilter([FromBody]TaskFilterDto filter)
        {
            return new PageDto<TaskDto, ITask>(repositoryContext.GetTasksByFilter(filter), x => new TaskDto(x));
        }


        [HttpPut("new")]
        public TaskDto AddNewTask([FromBody]NewTaskDto task)
        {
            return new TaskDto(repositoryContext.AddNewTask(task.Task, userContext.Sid, task.Employee, task.Name));
        }

        [HttpPut]
        public void UpdateTask([FromBody]TaskDto task)
        {
            repositoryContext.UpdateTask(task);
        }

        [HttpDelete("{id}")]
        public void RemoveTask(Guid id)
        {
            repositoryContext.RemoveTask(id);
        }

    }
}
