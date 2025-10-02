using System.ComponentModel;

namespace FileUploaderDemo.Models
{
    internal interface IFileUploaderModel : INotifyPropertyChanged
    {
        int Progress { get; }
        string StatusMessage { get; }

        Task UploadFile();
    }
}