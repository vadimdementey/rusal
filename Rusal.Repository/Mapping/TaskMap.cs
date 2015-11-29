using Rusal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Threading.Tasks;

namespace Rusal.Repository.Mapping
{
    public class TaskMap : EntityTypeConfiguration<TaskEntity>
    {
        public TaskMap()
        {
            ToTable("Tasks");
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName("TaskId");
            Property(x => x.ParentTaskId).HasColumnName("ParentTaskId");
            Property(x => x.Name).HasMaxLength(100).HasColumnName("TaskName");
            Property(x => x.CreatedDateTime).HasColumnName("TaskCreatedDateTime");
            Property(x => x.AuthorId).HasColumnName("AuthorId");
            Property(x => x.EmployeeId).HasColumnName("EmployeeId");

            Property(x => x.Completed).HasColumnName("TaskCompleted");
            Property(x => x.Description).HasMaxLength(100).HasColumnName("TaskDescription");

            HasRequired(x => x.Author    ).WithMany().HasForeignKey(x => x.AuthorId);
            HasRequired(x => x.ToEmployee).WithMany().HasForeignKey(x => x.EmployeeId);

            Ignore(x => x.ChildTasks)
           .Ignore(x=>x.ParentTask);



        }
    }
}
