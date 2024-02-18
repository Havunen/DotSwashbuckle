using System.Collections.Generic;

namespace DotSwashbuckle.AspNetCore.SwaggerGen.XmlComments
{
    public record XmlCommentDescriptor
    {
        public string Summary { get; set; }
        public string Remarks { get; set; }
        public string Example { get; set; }
        public string InheritcDoc { get; set; }
        public List<XmlParam> Params { get; set; }
        public List<XmlResponse> Responses { get; set; }

    }

    public record XmlParam
    {
        public string Value { get; set; }
        public string Name { get; set; }
        public string Example { get; set; }
    }

    public record XmlResponse
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
