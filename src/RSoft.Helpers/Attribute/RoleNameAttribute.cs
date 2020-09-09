using sys = System;

namespace RSoft.Helpers.Attribute
{

    /// <summary>
    /// Represents a class of function attributes (Roles)
    /// </summary>
    public class RoleNameAttribute : sys.Attribute
    {

        #region Constructors

        /// <summary>
        /// Creates a new attribute instance
        /// </summary>
        /// <param name="name">Role name</param>
        public RoleNameAttribute(string name)
        {
            Name = name;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the role name
        /// </summary>
        public string Name { get; private set; }

        #endregion

    }

}
