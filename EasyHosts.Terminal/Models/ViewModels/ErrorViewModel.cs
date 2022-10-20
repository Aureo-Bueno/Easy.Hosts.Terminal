using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyHosts.Terminal.Models.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Message { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}