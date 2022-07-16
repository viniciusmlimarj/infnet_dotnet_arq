using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tasks.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Repository.Mapping.UserMapping
{
    public class BoardMapping: IEntityTypeConfiguration<Tasks.Domain.Board.Board>
    {
        public void Configure(EntityTypeBuilder<Tasks.Domain.Board.Board> builder)
        {
            builder.ToTable("Board");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.HasMany(x => x.Tasks).WithOne().OnDelete(DeleteBehavior.Cascade);

        }
    }
}
