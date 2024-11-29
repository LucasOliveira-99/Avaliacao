using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avaliacao.Infraestructure.CrossCutting.Common.CQS;

namespace Avaliacao.Infraestructure.CrossCutting.Common.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
        }

        public Guid Id { get; protected set; }
        public virtual DateTime DataCadastro { get; private set; } = DateTime.Now;
        public virtual DateTime? DataUltimaAtualizacao { get; set; }

        private List<Event> _eventos = new List<Event>();
#pragma warning disable CS8603 // Possível retorno de referência nula.
        public IReadOnlyCollection<Event> Eventos => _eventos;
#pragma warning restore CS8603 // Possível retorno de referência nula.

        public void AdicionarEvento(Event evento)
            => _eventos.Add(evento);

        public void RemoverEvento(Event evento)
            => _eventos?.Remove(evento);

        public void LimparEventos()
            => _eventos?.Clear();

        #region Comparações

        public override bool Equals(object? obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (ReferenceEquals(null, compareTo))
                return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 907 + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }

        #endregion Comparações
    }
}
