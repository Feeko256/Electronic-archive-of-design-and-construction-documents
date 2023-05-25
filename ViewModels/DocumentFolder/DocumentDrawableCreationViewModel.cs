using System.Windows;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.DocumentFolder;

public class DocumentDrawableCreationViewModel : BaseViewModel
{
    private Mediator mediator;
    private RelayCommand createDrawableDocument;
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

    public RelayCommand CreateDrawableDocument
    {
        get
        {           
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return createDrawableDocument ??= new RelayCommand(obj =>
            {
                var document = new Document() { Header = this.Header, DocContentThechDrawning = new doc_content_thech_drawning{Header = _Header}, Type = "Документ-чертеж" };
                mediator.OnDocumentCreate(document);
                CloseWindow(obj);
            });
        } 
    }
    private void CloseWindow(object window)
    {
        (window as Window)?.Close();
    }

    public DocumentDrawableCreationViewModel(Mediator mediator)
    {
        this.mediator = mediator;
    }
}