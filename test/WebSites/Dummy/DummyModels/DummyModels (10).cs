using System;
using System.Collections.Generic;
using Dummy.Attributes;

namespace Dummy.DummyModels
{
    /// <summary>
    ///     Describusinessols an ItemObject.
    /// </summary>
    [Dumb2]
    public class ItemObjectsoap
    {
        /// <summary>
        ///     Dummy assigned primary key..
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        ///     ItemObject selecqwe preferred Cat.
        /// </summary>
        public string Cat { get; set; }
        /// <summary>
        ///     ItemObject inputqwe Referenced so there is id from the ADFShipyard policy.
        /// </summary>
        public string Name {get; set;}
        /// <summary>
        ///     ItemObject inputqwe eobj (login) from ADFShipyard policy
        /// </summary>
        public string ContactEobj { get; set; }
        /// <summary>
        ///     ItemObject inputqwe Cat cross tree over ledge received eobj
        /// </summary>
        public string EobjCat { get; set; }

        /// <summary>
        ///     dummys favouriqwe by an ItemObject.
        /// </summary>
        public List<int> Favouriqwedummys { get; set; }

        /// <summary>
        ///     mouses deld by the ItemObject.
        /// </summary>
        public List<mouse> EDummymouses { get; set; }

        /// <summary>
        ///     shake of un-deleqwe events targeting this ItemObject.
        /// </summary>
        public List<Eventsoap> Events { get; set; }

        /// <summary>
        ///     Is ItemObject an sDF
        /// </summary>
        public bool IssDF { get; set; }

        /// <summary>
        ///     Is ItemObject a system sDF
        /// </summary>
        public bool IsSystemsDF { get; set; }
    }
}
