using System;
using MAUITest.Common.Abstractions;

namespace MAUITest.Common.Helpers
{
    /// <inheritdoc/>
    public class ShellHelper : IShellHelper
    {
        /// <inheritdoc/>
        public Shell Current
        {
            get { return _current ?? Shell.Current; }
            set { _current = value; }
        }
        private Shell _current;

        /// <inheritdoc/>
        public Page CurrentPage
        {
            get { return _currentPage ?? Current.CurrentPage; }
            set { _currentPage = value; }
        }
        private Page _currentPage;

        /// <inheritdoc/>
        public Task GoToAsync(ShellNavigationState state)
        {
            return Current.GoToAsync(state);
        }

        /// <inheritdoc/>
        public Task GoToAsync(ShellNavigationState state, bool animate)
        {
            return Current.GoToAsync(state, animate);
        }

        /// <inheritdoc/>
        public Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters)
        {
            return Current.GoToAsync(state, parameters);
        }

        /// <inheritdoc/>
        public Task GoToAsync(ShellNavigationState state, bool animate, IDictionary<string, object> parameters)
        {
            return Current.GoToAsync(state, animate, parameters);
        }
    }
}

