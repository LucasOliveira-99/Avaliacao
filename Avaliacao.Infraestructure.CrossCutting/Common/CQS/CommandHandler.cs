using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;
using Avaliacao.Infraestructure.CrossCutting.Common.Views;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Infraestructure.CrossCutting.Common.CQS
{
    public abstract class CommandHandler : CommonHandler
    {
        #region return 2xx

        public IActionResult ReturnCreated<T>(string location, T view) where T : View
            => new CreatedResult(location, new BaseResponse<T>(System.Net.HttpStatusCode.Created, $"Entity created.", view));

        public IActionResult ReturnAccepted<T>(string location, string status, DateTime estimate, DateTime rejectedAfter) where T : View
           => new AcceptedResult(location, new BaseAcceptedResponse(status, estimate, rejectedAfter, location));

        public IActionResult ReturnNoContent()
           => new NoContentResult();

        public IActionResult ReturnOk<T>(T view) where T : View
            => new OkObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.OK, $"Processado com sucesso.", view));

        #endregion return 2xx

        #region return 4xx

        public IActionResult ReturnNotFound<T>(string message) where T : View
            => new NotFoundObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.NotFound, message));

        public IActionResult ReturnUnauthorized<T>(string message) where T : View
            => new UnauthorizedObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.Unauthorized, message));

        public IActionResult ReturnForbidden<T>(string message) where T : View
            => new ObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.Forbidden, message))
            {
                StatusCode = (int)System.Net.HttpStatusCode.Forbidden
            };

        #endregion return 4xx

        #region return 5xxx

        public IActionResult ReturnInternalServerError<T>(string message) where T : View
            => new ObjectResult(new BaseResponse<T>(System.Net.HttpStatusCode.InternalServerError, message))
            {
                StatusCode = (int)System.Net.HttpStatusCode.InternalServerError
            };

        #endregion return 5xxx

        protected async Task PersistirDados(IUnitOfWork uow)
        {
            await uow.Commit();
        }
    }
}