using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.config
{
    public class NotesConfiguration : IEntityTypeConfiguration<Notes>
    {
        public void Configure(EntityTypeBuilder<Notes> builder)
        {
            builder.HasOne(n => n.NoteStatus).WithMany()
                .HasForeignKey(n => n.NoteStatusId);
        }
    }
}