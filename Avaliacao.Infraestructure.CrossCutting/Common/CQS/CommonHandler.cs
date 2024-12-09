using Avaliacao.Infraestructure.CrossCutting.Common.Views;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Infraestructure.CrossCutting.Common.CQS
{
    public abstract class CommonHandler
    {
        protected ValidationResult ValidationResult = new ValidationResult();

        protected virtual bool ErroNoProcessamento => ValidationResult.Errors.Any();

        protected virtual void AdicionarErro(string mensagem)
            => ValidationResult.Errors.Add(new ValidationFailure(propertyName: string.Empty, errorMessage: mensagem));

        protected virtual void AdicionarErro(ValidationResult validationResult)
            => ValidationResult.Errors.AddRange(validationResult.Errors);

        protected virtual void AdicionarErro(string propertyName, string mensagem)
            => ValidationResult.Errors.Add(new ValidationFailure(propertyName: propertyName, errorMessage: mensagem));

        #region 2xxx

        public IActionResult RetornaOk<T>() where T : View
        => new OkObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.OK, $"Operação realizada com sucesso."));

        public IActionResult RetornaOk<T>(T view) where T : View
         => new OkObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.OK, $"Operação realizada com sucesso.", view));

        public IActionResult RetornaOkComLista<T>(List<T> view) where T : View
            => new OkObjectResult(new BaseListResponse<T>(System.Net.HttpStatusCode.OK, "Operação realizada com sucesso.", view));

        public IActionResult RetornaOkComListaVazia<T>() where T : View
           => new OkObjectResult(new BaseListResponse<T>(System.Net.HttpStatusCode.OK, "Operação realizada com sucesso."));

        #endregion 2xxx

        #region 4xx

        public IActionResult ReturnBadRequestComErros<T>(string codigo, string grupoErro) where T : View
            => new BadRequestObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.BadRequest, ValidationResult.Errors.Select(c => new ResponseErroView(codigo, grupoErro, c.ErrorMessage)).ToList()));

        public static IActionResult ReturnNotFound<T>(string message) where T : View
       => new NotFoundObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.NotFound, message));

        public IActionResult ReturnNotFoundComErros<T>(string codigo, string grupoErro) where T : View
            => new NotFoundObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.NotFound, ValidationResult.Errors.Select(c => new ResponseErroView(codigo, grupoErro, c.ErrorMessage)).ToList()));

        public IActionResult ReturnForbiddenComErros<T>(string codigo, string grupoErro) where T : View
            => new ObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.Forbidden, ValidationResult.Errors.Select(c => new ResponseErroView(codigo, grupoErro, c.ErrorMessage)).ToList())) { StatusCode = 403 };

        #endregion 4xx
    }
}