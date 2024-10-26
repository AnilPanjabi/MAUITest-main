using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MAUITest.Common.Abstractions
{
    /// <summary>
    /// Common Navigation service using Shell
    /// NavigateBack, NavigateTo
    /// PopToRootAsync
    /// </summary>
    public interface INavigationService
    {

        #region Methods
        /// <summary>
        /// Navigting to previous page
        /// Checking the Navigation stack
        /// </summary>
        /// <param name="animation"></param>
        /// <returns></returns>
        Task NavigateBack(bool animation = false);

        /// <summary>
        /// Navigates back to the previous page in the navigation stack.
        /// </summary>
        /// <param name="animation">A boolean value indicating whether to use animation during the navigation.</param>
        /// <param name="parameters">A dictionary of parameters to pass to the previous page.</param>
        Task NavigateBack(bool animation, IDictionary<string, object> parameters);

        /// <summary>
        /// Forward navigation
        /// Need to pass name of the page as a param
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        Task NavigateTo(string page);

        /// <summary>
        /// Forward navigation
        /// Need to pass name of the page as a param
        /// Animation is optional
        /// </summary>
        /// <param name="page"></param>
        /// <param name="animation"></param>
        /// <returns></returns>
        Task NavigateTo(string page, bool animation);


        /// <summary>
        /// Navigates to the specified page with optional animation and parameters.
        /// </summary>
        /// <param name="page">The page to navigate to.</param>
        /// <param name="animate">Whether or not to animate the navigation.</param>
        /// <param name="parameters">parameters to pass to the page being navigated to.</param>
        /// <returns>A task that represents the asynchronous navigation operation.</returns>
        Task NavigateTo(string page, bool animate, IDictionary<string, object> parameters);

        /// <summary>
        /// Navigates back to a specific page while removing other pages from the navigation stack.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="animation"></param>
        /// <param name="parameters"></param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task NavigateBackToPage(string page, bool animation, IDictionary<string, object> parameters = null);

        /// <summary>
        /// Navigating back to root page 
        /// </summary>
        /// <returns></returns>
        Task PopToRootAsync();

        /// <summary>
        /// To close the most recent page Asynchronously
        /// </summary>
        /// <returns></returns>
        Task PopModalAsync();
        #endregion
    }
}

