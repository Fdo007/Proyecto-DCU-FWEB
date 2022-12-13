using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proyecto_DCU_FWEB.Areas.Identity.Data;

namespace Proyecto_DCU_FWEB.Areas.Identity.Data;

public class AplicacionDBContext : IdentityDbContext<AplicacionUsuario>
{
    public AplicacionDBContext(DbContextOptions<AplicacionDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new AplicacionUsuarioConfiguracionEntidad());
    }
}
public class AplicacionUsuarioConfiguracionEntidad : IEntityTypeConfiguration<AplicacionUsuario>
{
    public void Configure(EntityTypeBuilder<AplicacionUsuario> builder)
    {
        builder.Property(u => u.Nombre).HasMaxLength(255);
        builder.Property(u => u.SegundoNombre).HasMaxLength(255);
        builder.Property(u => u.Apellido).HasMaxLength(255);

    }
}