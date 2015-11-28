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
                throw new NotImplementedException();
            }
        }

        IPriority ITask.Priority
        {
            get
            {
                return Priority;
            }
        }

        public TaskDto() { }

        public TaskDto(ITask other):base(other)
        {
            CreatedDateTime = other.CreatedDateTime;
            Description = other.Description;
            Author = new UserDto(other.Author);
            ToEmployee = new UserDto(other.ToEmployee);
            Priority = new PriorityDto(other.Priority);
        }

    }
}
