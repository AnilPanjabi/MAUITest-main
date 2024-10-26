using System;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace MAUITest.Business.Common.Services
{
	public static class ActivityService
	{
		public static async Task CopyToClipBoard(string value)
		{
			await Clipboard.SetTextAsync(value);

            var toast = Toast.Make("Copy to clipboard..!", ToastDuration.Short);
            await toast.Show();
        }
	}
}

