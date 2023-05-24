using System.Collections.ObjectModel;
using System.Windows;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.ProductFolder;

public class DocsOfProductCreationViewModel : BaseViewModel
{
    private Mediator mediator;
    private RelayCommand createProduct;
    private string header;

    public string Header
    {
        get { return header; }
        set
        {
            header = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand CreateProduct
    {
        get
        {
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return createProduct ??= new RelayCommand(obj =>
            {
                var product = new Docs_of_product()
                    { Header = this.Header, Documents = new ObservableCollection<Document>() };
                mediator.OnProductCreate(product);
                    CloseWindow(obj);
            });
        }
    }

    private void CloseWindow(object window)
    {
        (window as Window)?.Close();
    }

    public DocsOfProductCreationViewModel(Mediator mediator)
    {
        this.mediator = mediator;

    }
}