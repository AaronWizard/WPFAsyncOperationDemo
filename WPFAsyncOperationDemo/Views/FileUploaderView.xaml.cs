using FileUploaderDemo.ViewModels;
using Microsoft.Win32;
using System.Windows;

namespace FileUploaderDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class FileUploaderView : Window
    {
        public FileUploaderView()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            var fileUploader = DataContext as FileUploaderViewModel;
            if (fileUploader != null)
            {
                var dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == true)
                {
                    fileUploader.FilePath = dialog.FileName;
                }
            }
        }
    }
}