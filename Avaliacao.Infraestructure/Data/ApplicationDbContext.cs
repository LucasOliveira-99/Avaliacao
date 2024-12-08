using Avaliacao.Infraestructure.CrossCutting.Common.CQS;
using Avaliacao.Infraestructure.CrossCutting.Common.Entities;
using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;
using Avaliacao.Microservice.Domain.Contexts.Alugueis;
using Avaliacao.Microservice.Domain.Contexts.Veiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

namespace Avaliacao.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediator;
        private IDbContextTransaction _currentTransaction;

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Aluguel> Alugueis { get; set; }
        public bool HasActiveTransaction => _currentTransaction != null;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediatorHandler mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            System.Diagnostics.Debug.WriteLine("ApplicationDbContext::ctor ->" + GetHashCode());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Entity>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.Properties<decimal>()
             .HavePrecision(18, 2);
        }

        public async Task<bool> Commit()
        {
            try
            {
                if (ChangeTracker.Entries().Any(e => e.State != EntityState.Unchanged))
                {
                    foreach (var entry in ChangeTracker.Entries()
                                 .Where(e => e.Entity is Entity && e.State == EntityState.Modified))
                    {
                        var propertyInfo = entry.Entity.GetType().GetProperty("DataUltimaAtualizacao");
                        if (propertyInfo != null)
                        {
                            propertyInfo.SetValue(entry.Entity, DateTime.Now);
                        }
                    }

                    bool sucesso = false;

                    sucesso = await SaveChangesAsync() > 0;

                    if (sucesso)

                        return sucesso;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}