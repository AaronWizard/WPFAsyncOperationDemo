using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FileUploaderDemo.Models
{
    internal class FileUploaderModel : IFileUploaderModel
    {
        private const int DelayMilliseconds = 500;

        private int _progress = FileUploaderConstants.MaxProgress;
        public int Progress
        {
            get => _progress;
            private set
            {
                var oldStatusMessage = StatusMessage;
                if (_progress != value)
                {
                    _progress = value;
                    NotifyPropertyChanged(nameof(Progress));

                    var newStatusMessage = StatusMessage;
                    if (oldStatusMessage != newStatusMessage)
                    {
                        NotifyPropertyChanged(nameof(StatusMessage));
                    }
                }
            }
        }

        public string StatusMessage
        {
            get
            {
                var result = FileUploaderConstants.StatusMessages.Complete;
                if (Progress < FileUploaderConstants.MaxProgress)
                {
                    result = FileUploaderConstants.StatusMessages.InProgress;
                }
                return result;
            }
        }

        public async Task UploadFile()
        {
            Progress = 0;
            while (Progress < FileUploaderConstants.MaxProgress)
            {
                await Task.Delay(DelayMilliseconds);
                ++Progress;
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}
