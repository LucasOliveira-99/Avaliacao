using Avaliacao.Infraestructure.CrossCutting.Common.Messages;
using MediatR;

namespace Avaliacao.Infraestructure.CrossCutting.Common.CQS
{
    public abstract class Event : Message, INotification
    {
        public string JobId { get; private set; }
        public int? RetryCount { get; private set; }

        public void SetJobId(string jobId)
            => JobId = jobId;

        public void SetRetryCount(int? retryCount)
            => RetryCount = retryCount;

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return GetType().Name;
        }
    }
}