using Clean.Architecture.Domain.Entities.InvoiceItemEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.Architecture.Infra.Mapping
{
    public class InvoiceItemMapping: IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.ToTable("NotaFiscalItem");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Description).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Amount).IsRequired();
            builder.Property(c => c.InvoiceId).IsRequired();

            builder.HasOne(c => c.Invoice).WithMany(c => c.InvoiceItems).HasForeignKey(c => c.InvoiceId);
        }
    }
}
