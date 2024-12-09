namespace Avaliacao.Infraestructure.CrossCutting.Common.Entities
{
    public class AggregateRoot : Entity
    {
        private static int LastId = 0;

        public int Id { get; private set; }

        public AggregateRoot()
        {
            Id = ++LastId;
        }
    }
}