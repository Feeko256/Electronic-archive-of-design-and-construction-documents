using System.Diagnostics;
using System.IO;
using System.Windows;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.DocumentFolder;

public class DocumentDrawableViewModel : BaseViewModel
{
    private Mediator mediator;
    public  Document Document { get; set; }
    private string selectedFocFile;
    private RelayCommand openFileCommand;

    public string SelectedDocFile
    {
        get => selectedFocFile;
        set
        {
            selectedFocFile = value; OnPropertyChanged();
        }
    }
    public RelayCommand OpenFileCommand
    {
        get
        {
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return openFileCommand ??= new RelayCommand(obj =>
            {      
                string modifiedPath = SelectedDocFile.Replace('/', '\\');
             
                if (!string.IsNullOrEmpty(modifiedPath) && File.Exists(modifiedPath))
                {
                    string directoryPath = Path.GetDirectoryName(modifiedPath);

                    Process.Start("explorer.exe", $"/select,\"{modifiedPath}\"");
                }
            });
        }
    }
    
    private void OnSelectedDocumentChange(Document document)
    {
        Document = document;
    }
    public DocumentDrawableViewModel(Mediator mediator)
    {
        this.mediator = mediator;
        this.mediator.SelectedDocument += OnSelectedDocumentChange;
    }
}