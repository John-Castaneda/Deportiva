//esta es la clase principal
using Microsoft.EntityFrameworkCore;
using Dominio;



namespace Persistencia
{
    // extiende de dbcontext
    public class AppContext:DbContext
    {
        //Atributos
        //propiedad publica Dbset por cada clase del dominio
        //se recomienda que se llame como el plural del tipo de clase
        public DbSet<Deportista> Deportistas{get;set;}
        public DbSet<Entrenador> Entrenadores{get;set;}
        public DbSet<Equipo> Equipos{get;set;}
        public DbSet<Municipio> Municipios{get;set;}
        public DbSet<Patrocinador> Patrocinadores{get;set;}
        public DbSet<Torneo> Torneos{get;set;}
        public DbSet<TorneoEquipo> TorneoEquipos{get;set;}

        //metodos
        //metodo que recibe como argumento DbContext option builder que es el que genera conexiones
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //generar la base de datos automaticamente con el dbset de todas las entidades de dominio
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog=Deportiva");
            }

        }

        //este metodo es usado para geneara la llave primaria de una tabla intermedia
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //se crea la llave primaria para la tabla intermedia torneo equipo
            //haskey tiene notacion landa con un objeto anonimo 
            //esta 
            modelBuilder.Entity<TorneoEquipo>().HasKey(x=> new{x.EquipoId,x.TorneoId});
        }

    }
}