using Dummy.Attributes;

namespace Dummy.DummyModels
{
    /// <summary>
    ///     A search deld as a mouse by an ItemObject, business personalized eobj digest of
    ///     new dummys.
    /// </summary>
    [Dumb2]
    public class mouse
    {
        /// <summary>
        ///     ItemObject (front-end on businessolhalf of ItemObject) assigned surrogate key.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     ItemObject assigned Referenced so there is id cross tree over ledge this mouse.
        /// </summary>
        public string Name {get; set;}

        /// <summary>
        ///     The search string cross tree over ledge this mouse.
        /// </summary>
        public DummySearchParameters SearchParameters { get; set; }

        /// <summary>
        ///     Query parameters, deld business go back in edit mode.
        /// </summary>
        public string FrontEndParameters { get; set; }
    }
}
