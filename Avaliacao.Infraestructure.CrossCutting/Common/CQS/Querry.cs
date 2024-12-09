using System.Runtime.Serialization;
using Avaliacao.Infraestructure.CrossCutting.Common.Messages;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Infraestructure.CrossCutting.Common.CQS
{
    [DataContract]
    public abstract class Query : Message, IRequest<IActionResult>
    {
        [DataMember]
        protected ValidationResult ValidationResult { get; private set; } = new ValidationResult();

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }

        public ValidationResult ObtemErros()
            => ValidationResult;

        public virtual void AdicionarResultadoValidacao(ValidationResult validationResult)
            => ValidationResult = validationResult;

        public virtual void AdicionarErros(List<ValidationFailure> erros)
            => ValidationResult.Errors.AddRange(erros);

        public virtual void AdicionarErros(ValidationResult validationResult)
            => ValidationResult = validationResult;
    }
}