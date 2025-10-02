using FileUploaderDemo.Models;
using System.Windows.Input;

namespace FileUploaderDemo.ViewModels.Commands
{
    internal class UploadCommand : ICommand
    {
        private readonly IFileUploaderModel _model;

        public event EventHandler? CanExecuteChanged;

        public UploadCommand(IFileUploaderModel model)
        {
            _model = model;
            _model.PropertyChanged += ModelPropertyChanged;
        }

        public bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(parameter?.ToString()) && (_model.Progress == FileUploaderConstants.MaxProgress);
        }

        public void Execute(object? parameter)
        {
            _model.UploadFile();
        }

        private void ModelPropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IFileUploaderModel.Progress))
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
