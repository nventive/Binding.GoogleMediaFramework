using System;
using System.Collections.Generic;
using System.Text;
using Foundation;

namespace GoogleMediaFramework
{
	public class GMFContentPlayhead : IMAContentPlayhead
	{
		#region IMAContentPlayhead implementation
		private double _currentTime;

		[Export("currentTime")]
		public new double CurrentTime { get { return _currentTime; } }
		#endregion

		private GMFPlayerViewController _playerViewController;

		public GMFContentPlayhead(GMFPlayerViewController playerVc) : base()
		{
			_playerViewController = playerVc;
			NSNotificationCenter.DefaultCenter.AddObserver(Constants.kGMFPlayerCurrentMediaTimeDidChangeNotification, CurrentMediaTimeDidChange, _playerViewController);
		}

		public void CurrentMediaTimeDidChange(NSNotification notification)
		{
			WillChangeValue("currentTime");
			_currentTime = _playerViewController.CurrentMediaTime;
			DidChangeValue("currentTime");
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				NSNotificationCenter.DefaultCenter.RemoveObserver(this, Constants.kGMFPlayerCurrentMediaTimeDidChangeNotification,
					null);
			}
			base.Dispose(disposing);

		}

	}
}

