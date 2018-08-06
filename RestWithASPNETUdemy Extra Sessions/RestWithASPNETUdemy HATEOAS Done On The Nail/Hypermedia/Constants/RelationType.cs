namespace Hypermedia.Constants
{
    /// <summary>
    /// Valid RFC 5988 relation types
    /// </summary>
    public sealed class RelationType
    {
        /// <summary>
        /// Relation to itself
        /// </summary>
        public const string self = "self";

        /// <summary>
        /// Relation to future POST
        /// </summary>
        public const string post = "post";

        /// <summary>
        /// Relation to future PUT
        /// </summary>
        public const string put = "put";

        /// <summary>
        /// Relation to future PATCH
        /// </summary>
        public const string patch = "patch";

        /// <summary>
        /// Relation to future DELETE
        /// </summary>
        public const string delete = "delete";

        /// <summary>
        /// Navigation to the next page
        /// </summary>
        public const string next = "next";

        /// <summary>
        /// Navigation to the previous page
        /// </summary>
        public const string previous = "previous";

        /// <summary>
        /// Navigation to the first page
        /// </summary>
        public const string first = "first";

        /// <summary>
        /// Navigation to the last page
        /// </summary>
        public const string last = "last";
    }
}
