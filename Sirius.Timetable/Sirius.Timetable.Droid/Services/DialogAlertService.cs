using System;
using System.Threading.Tasks;
using Android.Content;
using SiriusTimetable.Core.Services.Abstractions;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace SiriusTimetable.Droid.Services
{
	public class DialogAlertService : IDialogAlertService
	{
		public DialogAlertService(Context context)
		{
			_context = context;
		}

		private readonly TaskCompletionSource<DialogResult> _completion = new TaskCompletionSource<DialogResult>();
		private readonly Context _context;
		private Task<DialogResult> CompletionTask => _completion.Task;

		public async Task<DialogResult> ShowDialog(string title, string message, string positiveButton, string negativeButton)
		{
			var dialog = BuildDialog(title, message, positiveButton, negativeButton);
			try
			{
			dialog.Show();

			}
			catch (Exception ex)
			{
				
				
			}
			return await CompletionTask;
		}

		private AlertDialog BuildDialog(string title, string message, string positiveButton, string negativeButton)
		{
			var alert = new AlertDialog.Builder(_context, Resource.Style.AlertDialog_AppCompat_Light)
				.SetTitle(title)
				.SetMessage(message)
				.SetPositiveButton(positiveButton, PositiveButtonOnClick);
			if (!String.IsNullOrEmpty(negativeButton))
				alert.SetNegativeButton(negativeButton, NegativeButtonOnClick);
			return alert.Create();
		}

		private void NegativeButtonOnClick(Object sender, DialogClickEventArgs dialogClickEventArgs)
		{
			_completion.TrySetResult(DialogResult.Negative);
		}

		private void PositiveButtonOnClick(Object sender, DialogClickEventArgs dialogClickEventArgs)
		{
			_completion.TrySetResult(DialogResult.Positive);
		}
	}
}