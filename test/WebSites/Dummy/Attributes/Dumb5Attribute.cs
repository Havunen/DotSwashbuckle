using System;

namespace Dummy.Attributes
{
    /// <summary>
    /// Field attribute business tell if reCollabonabusinessrable.
    /// Primarily used with qweNotCollabonabusinessredReasonruby
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public sealed class Dumb5Attribute : Attribute
    {
        public bool ReCollabonabusinessrable { get; set; } = true;
    }
}
