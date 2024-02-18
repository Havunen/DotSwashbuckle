﻿using System;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [Route("/shapes")]
    public class PolymorphicTypesController
    {
        [HttpPost]
        public int PolishShape([FromBody] Shape shape)
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Shape
    {
        public string Name {get; set;}
    }

    public class Rectangle : Shape
    {
        public int Height { get; set; }

        public int Width { get; set; }
    }

    public class Circle : Shape
    {
        public int RDFius { get; set; }
    }
}