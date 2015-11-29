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

        private ITaskRepository taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }


        [HttpGet("{id}")]
        public TaskDto GetTask(Guid id)
        {
            return new TaskDto(taskRepository.GetTaskWithChilds(id));
        }


        [HttpGet("my")]
        public TaskDto[] GetMyTasks()
        {
            return taskRepository.GetTasks(Guid.Empty, 10)
                                 .Select(x => new TaskDto(x))
                                 .ToArray();
        }


        [HttpPost]
        public PageDto<TaskDto,ITask> GetTasksByFilter([FromBody]TaskFilterDto filter)
        {
            return new PageDto<TaskDto,ITask>(taskRepository.GetTasksByFilter(filter),x=>new TaskDto(x));
        } 

    }
}
