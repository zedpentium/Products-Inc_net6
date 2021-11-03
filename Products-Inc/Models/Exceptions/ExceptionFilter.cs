using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Products_Inc.Models.Exceptions
{
    public class HttpResponseExceptionFilter : IExceptionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;

        private readonly int NOT_FOUND_STATUS = 404;
        private readonly int CONFLICT_STATUS = 409;
        
        public HttpResponseExceptionFilter()
        {
        }

        public HttpResponseExceptionFilter(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        public void OnException(ExceptionContext context)
        {
            var res = new ObjectResult(context.Exception.Message) { Value = context.Exception.Message };
            
            if(context.Exception is EntityNotFoundException)
            {
                res.StatusCode = NOT_FOUND_STATUS;

            }
            else if(context.Exception is UserUpdateException)
            {
                res.StatusCode = CONFLICT_STATUS;
            }
            else if(context.Exception is DataException)
            {
                res.StatusCode = 403;
            }
            else if(context.Exception is JsonException)
            {
                res.StatusCode = 500;
                res.Value = "Converting with JSON-failed.";
            }

            context.ExceptionHandled = true;
            context.Result = res;
           
        }
    }
}