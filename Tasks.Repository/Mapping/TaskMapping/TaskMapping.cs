using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasks.Domain.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasks.Repository.Mapping.UserMapping
{
    public class TaskMapping : IEntityTypeConfiguration<Tasks.Domain.Task.Task>
    {
        public void Configure(EntityTypeBuilder<Tasks.Domain.Task.Task> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Done).HasDefaultValue(false);

        }
    }
}
