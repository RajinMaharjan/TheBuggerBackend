namespace Excallibur.Application.Common.Models.ResponseModels
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;
    using System.Linq;

    public class ApiError
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string Message { get; set; }

        public string Status { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiError"/> class.
        /// </summary>
        public ApiError() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiError"/> class.
        /// </summary>
        /// <param name="modelState">State of the model.</param>
        public ApiError(ModelStateDictionary modelState)
        {
            var errors = modelState?.Keys.SelectMany(key => modelState[key].Errors.Select(x => x.ErrorMessage));
            Message = string.Join(Environment.NewLine, errors);
        }
    }
}