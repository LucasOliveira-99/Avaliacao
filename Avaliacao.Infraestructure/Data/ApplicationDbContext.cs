using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Avaliacao.Infraestructure.CrossCutting.Common.CQS;
using Avaliacao.Infraestructure.CrossCutting.Common.Entities;
using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;
using Avaliacao.Microservice.Domain.Contexts.Veiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Avaliacao.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediator;
        private IDbContextTransaction _currentTransaction;

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public DbSet<Veiculo> Veiculos { get; set; }
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
                        await _mediator.PublicarEventosAsync(this);

                    return sucesso;
                }

                await _mediator.PublicarEventosAsync(this);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
