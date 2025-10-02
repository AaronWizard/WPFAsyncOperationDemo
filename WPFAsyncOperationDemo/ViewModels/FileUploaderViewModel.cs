using FileUploaderDemo.Models;
using FileUploaderDemo.ViewModels.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FileUploaderDemo.ViewModels
{
    internal class FileUploaderViewModel : INotifyPropertyChanged
    {
        private IFileUploaderModel _model;

        public ICommand UploadCommand { get; private set; }

        public int MaxProgress { get => FileUploaderConstants.MaxProgress; }

        public int Progress { get => _model.Progress; }
        public string StatusMessage { get => _model.StatusMessage; }

        private string _filePath = "";
        public string FilePath
        {
            get => _filePath;
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    NotifyPropertyChanged(nameof(FilePath));
                }
            }
        }

        public bool CanUpload
        {
            get
            {
                return _model.Progress == FileUploaderConstants.MaxProgress;
            }
        }

        public FileUploaderViewModel()
        {
            _model = new FileUploaderModel();
            _model.PropertyChanged += ModelPropertyChanged;
            UploadCommand = new UploadCommand(_model);
        }

        private void ModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(Progress):
                    NotifyPropertyChanged(e.PropertyName);
                    if ((_model.Progress == 0) || (_model.Progress == FileUploaderConstants.MaxProgress))
                    {
                        NotifyPropertyChanged(nameof(CanUpload));
                    }
                    break;
                case nameof(StatusMessage):
                    NotifyPropertyChanged(e.PropertyName);
                    break;
            }

            if (!CanUpload && !string.IsNullOrEmpty(FilePath))
            {
                FilePath = "";
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
