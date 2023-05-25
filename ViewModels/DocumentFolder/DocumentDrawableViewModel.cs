using System.Windows;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.DocumentFolder;

public class DocumentDrawableViewModel : BaseViewModel
{
    private Mediator mediator;
    public  Document Document { get; set; }
    
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