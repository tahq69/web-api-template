namespace Crip.Samples.Data.Types
{
    using System;

    /// <summary>
    /// User role definitions.
    /// </summary>
    [Flags]
    public enum RoleType
    {
        /// <summary>
        /// None of the roles.
        /// </summary>
        None = 0,

        /// <summary>
        /// The super administrator role.
        /// </summary>
        SuperAdmin = 1,

        /// <summary>
        /// The administrator role.
        /// </summary>
        Administrator = 2,

        /// <summary>
        /// The user role.
        /// </summary>
        User = 4,
    }
}
