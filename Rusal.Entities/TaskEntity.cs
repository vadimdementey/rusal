using Rusal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Entities
{
    public class TaskEntity : NamedEntity, ITask
    {
        public DateTime CreatedDateTime { get; set; }
        public Guid? ParentTaskId { get; set; }
        public Guid     AuthorId        { get; set; }
        public Guid     EmployeeId      { get; set; } 
        public int PriorityCode { get; set; }
        public bool Completed { get; set; }
        public string Description { get; set; }
        public UserEntity Author { get; set; }
        public UserEntity ToEmployee { get; set; }
        public PriorityEntity Priority { get; set; }
        public TaskEntity   ParentTask { get; set; }
        public TaskEntity[] ChildTasks { get; set; } 


        IUser ITask.Author
        {
            get
            {
                return Author;
            }
        }

        IPriority ITask.Priority
        {
            get
            {
                return Priority;
            }
        }

        IUser ITask.ToEmployee
        {
            get
            {
                return ToEmployee;
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
    }
}
