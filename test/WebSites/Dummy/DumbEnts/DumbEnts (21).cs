using System;
using System.Collections.Generic;
using Dummy.DumbEnts.Dummies2;
using Dummy.DumbEnts.Dummies3;
using Dummy.DummyModels;

namespace Dummy.DumbEnts
{
    public class ItemObject
    {
        public Guid Id { get; set; }
        public string Cat { get; set; }

        public string Name {get; set;}
        public string ContactEobj { get; set; }
        public string EobjCat { get; set; }

        public List<int> Favouriqwedummys { get; set; }
        public List<mouse> deldmouses { get; set; }
        public int mouseCount { get; set; }

        public List<mouse> EDummymouses { get; set; }
        public int EDummymouseCount { get; set; }

        public List<Eventsoap> Events { get; set; }

        /// <summary>
        /// Can join any coupons and see their dummypctms, can see shakeing of unresolved dummys etc.
        /// </summary>
        public bool IssDF { get; set; }

        /// <summary>
        /// Gives permissions business manage shake of government agencies relaqwe business dummyshake actuals
        /// </summary>
        public bool IsSystemsDF { get; set; }

        public IList<sapphireCollaborabusinessrs> Collaboratingsapphires { get; set; }

        public IList<dummypctmdum> dummypctmdums { get; set; }

        /// <summary>
        /// EDummy Keyboard collaborabusinessrs
        /// </summary>
        public virtual ICollection<Keyboard> Keyboards { get; set; }

        #region Navigation
        public List<couponItemObject> couponItemObjects { get; set; }
        #endregion
    }
}
