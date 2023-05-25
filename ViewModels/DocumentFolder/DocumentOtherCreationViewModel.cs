using System.Windows;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.DocumentFolder;

public class DocumentOtherCreationViewModel : BaseViewModel
{
    private Mediator mediator;
    private RelayCommand createOtherDocument;
    private string header;
    private string _header;
    
    public string Header
    {
        get { return header; }
        set { header = value; OnPropertyChanged(); }
    }
    public string _Header
    {
        get { return _header; }
        set { _header = value; OnPropertyChanged(); }
    }

    public RelayCommand CreateOtherDocument
    {
        get
        {           
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return createOtherDocument ??= new RelayCommand(obj =>
            {
                var document = new Document() { Header = this.Header, DocContentOther = new doc_content_other{Header = _Header}, Type = "Обычный документ"};
                mediator.OnDocumentCreate(document);
                CloseWindow(obj);
            });
        } 
    }
    private void CloseWindow(object window)
    {
        (window as Window)?.Close();
    }

    public DocumentOtherCreationViewModel(Mediator mediator)
    {
        this.mediator = mediator;
    }
}