#region Copyright (C) 2014-2016 Sascha Simon

//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see http://www.gnu.org/licenses/.
//
//  Visit the official homepage at http://www.sascha-simon.com

#endregion

#if !NET_CORE

using System;
using System.Threading;
using Strava.Authentication;
using Strava.Clients;

namespace Strava.Upload
{
    /// <summary>
    /// This class is used to check the status of an upload. You can subscribe to the UploadChecked event which is raised 
    /// whenever the status was checked. You can then read the current status of the upload.
    /// </summary>
    public class UploadStatusCheck
    {
        private readonly Timer _timer;
        private CheckStatus _currentStatus;
        private readonly string _token;
        private readonly string _uploadId;

        /// <summary>
        /// Indicates whether the activity is processed.
        /// </summary>
        public bool IsFinished
        {
            get
            {
                return _currentStatus == CheckStatus.Finished;
            }
        }

        /// <summary>
        /// This attribute contains details about the error.
        /// </summary>
        public string ErrorMessage { get; set; }

        #region Events

        /// <summary>
        /// UploadChecked is raised whenever the status of an upload was checked and a response was received.
        /// </summary>
        public event EventHandler<UploadStatusCheckedEventArgs> UploadChecked;

        /// <summary>
        /// ActivityReady is raised whenever the activity was successfully uploaded to and processed by Strava.
        /// </summary>
        public event EventHandler ActivityReady;

        /// <summary>
        /// ActivityProcessing is raised whenever the activity is being processed by Strava.
        /// </summary>
        public event EventHandler ActivityProcessing;

        /// <summary>
        /// Error is raised whenever an error has occured.
        /// </summary>
        public event EventHandler Error;

        #endregion

        /// <summary>
        /// Initializes a new instance of the UploadStatusCheck class.
        /// </summary>
        public UploadStatusCheck(string accessToken, string uploadId)
        {
            TimerCallback timerTick = new TimerCallback(TimerTick);
            _timer = new Timer(timerTick, this, TimeSpan.Zero, TimeSpan.FromSeconds(1));

            _token = accessToken;
            _uploadId = uploadId;
        }

        private void TimerTick(object state)
        {
            UploadStatusCheck self = state as UploadStatusCheck;
            if (self == null)
                return;

            StaticAuthentication auth = new StaticAuthentication(self._token);
            StravaClient client = new StravaClient(auth);

            UploadStatus status = client.Uploads.CheckUploadStatus(self._uploadId);

            switch (status.Status)
            {
                case "Your activity is still being processed.":
                    self.UploadChecked?.Invoke(this, new UploadStatusCheckedEventArgs(CurrentUploadStatus.Processing));
                    self.ActivityProcessing?.Invoke(this, EventArgs.Empty);
                    break;

                case "The created activity has been deleted.":
                    self.UploadChecked?.Invoke(this, new UploadStatusCheckedEventArgs(CurrentUploadStatus.Deleted));
                    self.Finish();
                    break;

                case "There was an error processing your activity.":
                    self.UploadChecked?.Invoke(this, new UploadStatusCheckedEventArgs(CurrentUploadStatus.Error));
                    self.ErrorMessage = status.Error;
                    self.Error?.Invoke(this, EventArgs.Empty);
                    self.Finish();
                    break;

                case "Your activity is ready.":
                    self.UploadChecked?.Invoke(this, new UploadStatusCheckedEventArgs(CurrentUploadStatus.Ready));
                    self.ActivityReady?.Invoke(this, EventArgs.Empty);
                    self.Finish();
                    break;
            }
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void Start()
        {
            if (!IsFinished)
            {                
                _timer.Start();
                _currentStatus = CheckStatus.Busy;
            }
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
            _currentStatus = CheckStatus.Idle;
        }

        private void Finish()
        {
            _currentStatus = CheckStatus.Finished;
            _timer.Stop();
        }
    }
}
#endif