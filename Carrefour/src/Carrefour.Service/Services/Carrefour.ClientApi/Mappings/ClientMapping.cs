using Carrefour.ClientApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Carrefour.ClientApi.Mappings;

public class ClientMapping : IEntityTypeConfiguration<ClientModel>
{
    public void Configure(EntityTypeBuilder<ClientModel> builder)
    {
        builder.HasKey(p => p.Id);

        // 1 : 1 => Fornecedor : Endereco
        builder.HasOne(f => f.Address)
            .WithOne(e => e.Client);

        // 1 : 1 => Fornecedor : Endereco
        builder.HasOne(f => f.Contact)
            .WithOne(e => e.Client);

        builder.ToTable("Clientes");
    }
}
