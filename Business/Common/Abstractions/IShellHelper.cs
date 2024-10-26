using System;
namespace MAUITest.Common.Abstractions
{
    /// <summary>
    /// Represents a helper interface for shell operations and navigation.
    /// </summary>
    public interface IShellHelper
    {
        /// <summary>
        /// Current Shell Implementation
        /// </summary>
        public Shell Current { get; set; }

        /// <summary>
        /// Current Page for navigation
        /// </summary>
        public Page CurrentPage { get; set; }

        /// <summary>
        /// Navigation to the designated state
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public Task GoToAsync(ShellNavigationState state);

        /// <summary>
        /// Navigation to the designated state with animation
        /// </summary>
        /// <param name="state"></param>
        /// <param name="animate"></param>
        /// <returns></returns>
        public Task GoToAsync(ShellNavigationState state, bool animate);

        /// <summary>
        /// Navigation to the designated state with parameters
        /// </summary>
        /// <param name="state"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters);

        /// <summary>
        /// Navigation to the designated state with animation and parameters
        /// </summary>
        /// <param name="state"></param>
        /// <param name="animate"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task GoToAsync(ShellNavigationState state, bool animate, IDictionary<string, object> parameters);
    }
}

