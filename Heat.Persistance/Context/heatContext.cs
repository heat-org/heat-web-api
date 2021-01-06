using Heat.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Heat.Persistance.Context
{
    public partial class HeatContext : DbContext, IHeatContext
    {
        public HeatContext() { }

        public HeatContext(DbContextOptions<HeatContext> options) : base(options) { }
        public virtual DbSet<AtributosVehiculo> AtributosVehiculo { get; set; }
        public virtual DbSet<BitacoraUbicacion> BitacoraUbicacion { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Conductor> Conductor { get; set; }
        public virtual DbSet<Estacion> Estacion { get; set; }
        public virtual DbSet<EstacionRuta> EstacionRuta { get; set; }
        public virtual DbSet<Estatus> Estatus { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Parada> Parada { get; set; }
        public virtual DbSet<Reporte> Reporte { get; set; }
        public virtual DbSet<Ruta> Ruta { get; set; }
        public virtual DbSet<TipoReporte> TipoReporte { get; set; }
        public virtual DbSet<TipoVehiculo> TipoVehiculo { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }
        public virtual DbSet<VehiculoDetalle> VehiculoDetalle { get; set; }
        public virtual DbSet<SP_Buscar_RutasInfo> SP_Buscar_RutasInfo { get; set; }
        //TODO:IMPLEMENTAR AQUI EL LLENADO DE LOS CAMPOS DE AUDITORIA
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AtributosVehiculo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.AtributosVehiculo)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__Atributos__Estat__7B5B524B");
            });

            modelBuilder.Entity<BitacoraUbicacion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FechaHora).HasColumnType("datetime");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");

                entity.HasOne(d => d.Vehiculo)
                    .WithMany(p => p.BitacoraUbicacion)
                    .HasForeignKey(d => d.VehiculoId)
                    .HasConstraintName("FK__BitacoraU__Vehic__114A936A");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");

                entity.Property(e => e.Texto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__Comentari__Estat__06CD04F7");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Comentari__Usuar__05D8E0BE");
            });

            modelBuilder.Entity<Conductor>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoEmpleado)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");

                entity.Property(e => e.Foto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.HorarioId).HasColumnName("HorarioID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.Conductor)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__Conductor__Estat__72C60C4A");

                entity.HasOne(d => d.Horario)
                    .WithMany(p => p.Conductor)
                    .HasForeignKey(d => d.HorarioId)
                    .HasConstraintName("FK__Conductor__Horar__71D1E811");
            });

            modelBuilder.Entity<Estacion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.Estacion)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__Estacion__Estatu__619B8048");
            });

            modelBuilder.Entity<EstacionRuta>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.EstacionId).HasColumnName("EstacionID");

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");

                entity.Property(e => e.RutaId).HasColumnName("RutaID");

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.EstacionRuta)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__EstacionR__Estat__68487DD7");

                entity.HasOne(d => d.Ruta)
                    .WithMany(p => p.EstacionRuta)
                    .HasForeignKey(d => d.RutaId)
                    .HasConstraintName("FK__EstacionR__RutaI__6754599E");
            });

            modelBuilder.Entity<Estatus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Entidad)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");

                entity.Property(e => e.From).HasColumnType("datetime");

                entity.Property(e => e.To).HasColumnType("datetime");

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.Horario)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__Horario__Estatus__6EF57B66");
            });

            modelBuilder.Entity<Parada>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");

                entity.Property(e => e.RutaId).HasColumnName("RutaID");

                entity.Property(e => e.Tramo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.Parada)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__Parada__EstatusI__6C190EBB");

                entity.HasOne(d => d.Ruta)
                    .WithMany(p => p.Parada)
                    .HasForeignKey(d => d.RutaId)
                    .HasConstraintName("FK__Parada__RutaID__6B24EA82");
            });

            modelBuilder.Entity<Reporte>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ComentarioId).HasColumnName("ComentarioID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");

                entity.Property(e => e.Texto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoReporteId).HasColumnName("TipoReporteID");

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Comentario)
                    .WithMany(p => p.Reporte)
                    .HasForeignKey(d => d.ComentarioId)
                    .HasConstraintName("FK__Reporte__Comenta__0D7A0286");

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.Reporte)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__Reporte__Estatus__0E6E26BF");

                entity.HasOne(d => d.TipoReporte)
                    .WithMany(p => p.Reporte)
                    .HasForeignKey(d => d.TipoReporteId)
                    .HasConstraintName("FK__Reporte__TipoRep__0C85DE4D");
            });

            modelBuilder.Entity<Ruta>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.Ruta)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__Ruta__EstatusID__6477ECF3");
            });

            modelBuilder.Entity<TipoReporte>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.TipoReporte)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__TipoRepor__Estat__09A971A2");
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.TipoVehiculo)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__TipoVehic__Estat__5EBF139D");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__Usuario__Estatus__02FC7413");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ConductorActualId).HasColumnName("ConductorActualID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Estatus)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");
                entity.Property(e => e.TiempoEstimadoSegundos).HasColumnName("TiempoEstimadoSegundos");

                entity.Property(e => e.Placa)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RutaId).HasColumnName("RutaID");

                entity.Property(e => e.TipoVehiculoId).HasColumnName("TipoVehiculoID");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.ConductorActual)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.ConductorActualId)
                    .HasConstraintName("FK__Vehiculo__Conduc__76969D2E");

                entity.HasOne(d => d.EstatusNavigation)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__Vehiculo__Estatu__787EE5A0");

                entity.HasOne(d => d.Ruta)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.RutaId)
                    .HasConstraintName("FK__Vehiculo__RutaID__778AC167");

                entity.HasOne(d => d.TipoVehiculo)
                    .WithMany(p => p.Vehiculo)
                    .HasForeignKey(d => d.TipoVehiculoId)
                    .HasConstraintName("FK__Vehiculo__TipoVe__75A278F5");
            });

            modelBuilder.Entity<VehiculoDetalle>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AtributoId).HasColumnName("AtributoID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModify).HasColumnType("datetime");

                entity.Property(e => e.EstatusId).HasColumnName("EstatusID");

                entity.Property(e => e.UserCreated)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserModify)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VehiculoId).HasColumnName("VehiculoID");

                entity.HasOne(d => d.Atributo)
                    .WithMany(p => p.VehiculoDetalle)
                    .HasForeignKey(d => d.AtributoId)
                    .HasConstraintName("FK__VehiculoD__Atrib__7F2BE32F");

                entity.HasOne(d => d.Estatus)
                    .WithMany(p => p.VehiculoDetalle)
                    .HasForeignKey(d => d.EstatusId)
                    .HasConstraintName("FK__VehiculoD__Estat__00200768");

                entity.HasOne(d => d.Vehiculo)
                    .WithMany(p => p.VehiculoDetalle)
                    .HasForeignKey(d => d.VehiculoId)
                    .HasConstraintName("FK__VehiculoD__Vehic__7E37BEF6");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}