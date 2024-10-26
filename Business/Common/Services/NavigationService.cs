using System;
using MAUITest.Common.Abstractions;

namespace MAUITest.Common.Services
{
    /// <summary>
    /// Framework implementation of the <see cref="INavigationService"/>.
    /// </summary>
    public class NavigationService : INavigationService
    {
        #region Members
        /// <summary>
        /// Gets the <see cref="INavigation"/> implementation for the application.
        /// </summary>
        protected INavigation _navigation => _shellHelper.CurrentPage?.Navigation;

        private readonly IShellHelper _shellHelper;

        #endregion

        #region Constructors
        /// <summary>
        /// Initializes 
        /// </summary>
        public NavigationService(IShellHelper shellHelper)
        {
            _shellHelper = shellHelper;
        }
        #endregion

        /// <summary>
        /// Navigating back to root page
        /// Navigation stack need to have more than one page in navigation
        /// </summary>
        /// <returns></returns>
        public Task PopToRootAsync()
        {
            return _navigation.PopToRootAsync();
        }

        /// <summary>
        /// To dismisses Asynchronously the most recent modally presented Page,
        /// Animation is Optional
        /// </summary>
        /// <returns></returns>
        public Task PopModalAsync()
        {
            return _navigation.PopModalAsync();
        }

        /// <summary>
        /// Backward navigation
        /// Navigating one step back in Navigation stack
        /// This is only applicable when there is morethan one page in the navigation stack
        /// </summary>
        /// <param name="animation"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Task NavigateBack(bool animation = false)
        {
            return _shellHelper.GoToAsync("..", animation);
        }

        /// <summary>
        /// Backward navigation with optional animation
        /// Navigating one step back in Navigation stack
        /// Passing the object 
        /// </summary>
        /// <param name="animation"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task NavigateBack(bool animation, IDictionary<string, object> parameters)
        {
            return _shellHelper.GoToAsync("..", animation, parameters);
        }

        /// <summary>
        /// Forward navigation
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Task NavigateTo(string page)
        {
            return _shellHelper.GoToAsync(page);
        }

        /// <summary>
        /// Forward navigation
        /// </summary>
        /// <param name="page"></param>
        /// <param name="animation"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public Task NavigateTo(string page, bool animation)
        {
            return _shellHelper.GoToAsync(page, animation);
        }

        /// <summary>
        /// Navigates to a specified page within the application, optionally with animation and parameters.
        /// Any existing instances of the page in the navigation stack are removed before adding it again,
        /// because in iOS it gives error: Pushing the same view controller instance is not supported.
        /// </summary>
        /// <param name="page">The name of the page to navigate to.</param>
        /// <param name="animation">Flag indicating whether to use navigation animation.</param>
        /// <param name="parameters">Parameters to pass to the target page during navigation.</param>
        /// <returns>A task representing the asynchronous operation of navigation.</returns>
        public Task NavigateTo(string page, bool animation, IDictionary<string, object> parameters)
        {
            if (_navigation != null)
            {
                var existingInstances = _navigation.NavigationStack.Where(item => item?.GetType().Name == page).ToList();

                foreach (var item in existingInstances)
                {
                    _navigation.RemovePage(item);
                }
            }

            return _shellHelper.GoToAsync(page, animation, parameters);
        }

        /// <summary>
        /// Navigates to a specified page within the application, optionally with animation and parameters.
        /// Any existing instances of the page in the navigation stack are removed before adding it again,
        /// because in iOS it gives error: Pushing the same view controller instance is not supported.
        /// </summary>
        /// <param name="page">The name of the page to navigate to.</param>
        /// <param name="animation">Flag indicating whether to use navigation animation.</param>
        /// <param name="parameters">Parameters to pass to the target page during navigation.</param>
        /// <returns>A task representing the asynchronous operation of navigation.</returns>
        public async Task NavigateBackToPage(string page, bool animation, IDictionary<string, object> parameters = null)
        {
            if (_navigation != null)
            {
                var pages = _navigation.NavigationStack.ToList();

                var count = pages.Count - 1;

                var pageToNavigate = pages.FirstOrDefault(p => p?.GetType().Name == page);

                if (pageToNavigate != null)
                {
                    var index = pages.IndexOf(pageToNavigate);
                    while (count > index)
                    {
                        _navigation.RemovePage(pages[count]);
                        count--;
                    }
                }
            }

            if (parameters != null)
            {
                await NavigateTo(page, animation, parameters);
            }
            else
            {
                await NavigateTo(page, animation);
            }

            if (_navigation != null)
            {
                if (_navigation.NavigationStack.Where(x => x?.GetType().Name == page).Count() > 1)
                {
                    var pageToRemove = _navigation.NavigationStack.Where(x => x?.GetType().Name == page).First();
                    _navigation.RemovePage(pageToRemove);
                }
            }

        }
    }
}

