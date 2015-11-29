using Rusal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Dto
{
    public class TaskDto : NamedEntityDto, ITask
    {

        public DateTime CreatedDateTime { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }
        public UserDto Author { get; set; }
        public UserDto ToEmployee { get; set; }
        public PriorityDto Priority { get; set; }
        public TaskDto ParentTask   { get; set; }
        public TaskDto[] ChildTasks { get; set; } 

        IUser ITask.Author
        {
            get
            {
                return Author;
            }
        }

        IUser ITask.ToEmployee
        {
            get
            {
                return ToEmployee;
            }
        }

        IPriority ITask.Priority
        {
            get
            {
                return Priority;
            }
        }

        ITask ITask.ParentTask
        {
            get
            {
                return ParentTask;
            }
        }

        ITask[] ITask.ChildTasks
        {
            get
            {
                return ChildTasks;
            }
        }

        public TaskDto() { }

        public TaskDto(ITask other):base(other)
        {
            CreatedDateTime = other.CreatedDateTime;
            Description     = other.Description;
            Author          = new UserDto(other.Author);
            ToEmployee      = new UserDto(other.ToEmployee);
            Priority        = new PriorityDto(other.Priority);

            if(other.ParentTask!=null)
            {
                ParentTask = new TaskDto(other.ParentTask);
            }

            if (other.ChildTasks != null)
            {
                ChildTasks = other.ChildTasks.Select(x => new TaskDto(x)).ToArray();
            }
        }





    }
}
