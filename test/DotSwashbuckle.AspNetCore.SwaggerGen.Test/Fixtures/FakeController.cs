﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DotSwashbuckle.AspNetCore.TestSupport;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.Test
{
    public class CustomRequiredAttribute : RequiredAttribute
    {
    }

    public class FakeController
    {
        public void ActionWithNoParameters()
        { }

        public void ActionWithParameter(string param)
        { }

        public IntEnum ActionWithEnumParameter(IntEnum param)
        {
            return param;
        }

        public void ActionWithMultipleParameters(string param1, int param2)
        { }

        [HttpGet(Name = "SomeRouteName")]
        public void ActionWithRouteNameMetadata()
        { }

        [Obsolete]
        public void ActionWithObsoleteAttribute()
        { }

        public void ActionWithParameterWithBindNeverAttribute([BindNever]string param)
        { }

        public void ActionWithParameterWithRequiredAttribute([Required]string param)
        { }

        public void ActionWithParameterWithCustomRequiredAttribute([CustomRequiredAttribute] string param)
        { }

        public void ActionWithParameterWithBindRequiredAttribute([BindRequired]string param)
        { }

        public void ActionWithAcceptFromHeaderParameter([FromHeader] string accept, string param)
        { }

        public void ActionWithContentTypeFromHeaderParameter([FromHeader(Name = "Content-Type")] string contentType, string param)
        { }

        public void ActionWithAuthorizationFromHeaderParameter([FromHeader] string authorization, string param)
        { }

        public void ActionWithIntParameter(int param)
        { }

        public void ActionWithIntParameterWithRangeAttribute([Range(1, 12)]int param)
        { }

        public void ActionWithIntParameterWithDefaultValue(int param = 1)
        { }

        public void ActionWithIntParameterWithDefaultValueAttribute([DefaultValue(3)]int param)
        { }

        public void ActionWithIntParameterWithRequiredAttribute([Required]int param)
        { }

        public void ActionWithObjectParameter(XmlAnnotatedType param)
        { }

        [Consumes("application/someMediaType")]
        public void ActionWithConsumesAttribute(string param)
        { }

        public int ActionWithReturnValue()
        {
            throw new NotImplementedException();
        }

        [Produces("application/someMediaType")]
        public int ActionWithProducesAttribute()
        {
            throw new NotImplementedException();
        }

        [Produces("application/someMediaType")]
        public void VoidActionWithProducesAttribute()
        {
            throw new NotImplementedException();
        }

        [Consumes("multipart/form-data")]
        public void ActionWithIFormFile(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}