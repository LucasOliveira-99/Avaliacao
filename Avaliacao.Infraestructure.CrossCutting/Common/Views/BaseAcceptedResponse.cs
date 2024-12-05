using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avaliacao.Infraestructure.CrossCutting.Common.Views
{
    public class BaseAcceptedResponse
    {
        public BaseAcceptedResponse(string status, DateTime estimate, DateTime rejectedAfter, string trackignUrl)
        {
            Status = status;
            Completion = new BaseAcceptedResponseCompletion
            {
                Estimate = estimate,
                RejectedAfter = rejectedAfter
            };
            Tracking = new BaseAcceptedResponseTracking
            {
                Url = trackignUrl
            };
        }

        public string Status { get; set; }
        public BaseAcceptedResponseCompletion Completion { get; set; }
        public BaseAcceptedResponseTracking Tracking { get; set; }
    }

    public class BaseAcceptedResponseCompletion
    {
        public DateTime Estimate { get; set; }
        public DateTime RejectedAfter { get; set; }
    }

    public class BaseAcceptedResponseTracking
    {
        public string Url { get; set; }
    }
}
