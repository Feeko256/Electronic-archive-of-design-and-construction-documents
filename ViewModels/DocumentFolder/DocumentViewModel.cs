using System.Collections.ObjectModel;
using System.Windows;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;
using Electronic_archive_of_design_and_construction_documents.Views.Documents;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.DocumentFolder;

public class DocumentViewModel  : BaseViewModel
{
    public ObservableCollection<Document> Documents { get; set; }
    public Docs_of_product Product { get; set; }
    private object lastVM;
    private RelayCommand goToProducts;
    private RelayCommand addOtherDocument;
    private RelayCommand addDrawableDocument;
    private Mediator mediator;
    private ApplicationContext db;
    private Docs_of_product selectedProduct;
    private object? selectedViewModel;
    private Document selectedDocument;
    private DrawibleDocumentCreationView createDrawableCreationView { get; set; }
    private OtherDocumentCreationView createOtherCreationView { get; set; }

    private RelayCommand addProductCommand;
    
    public RelayCommand GoToProducts
    {
        get
        {
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return goToProducts ??= new RelayCommand(obj =>
            {
                mediator.OnViewModelChange(lastVM);
            });
        }
    }
    public Document? SelectedDocument
    {
        get { return selectedDocument; }
        set 
        {
            selectedDocument = value; 
            OnPropertyChanged();
            if (SelectedDocument?.DocContentThechDrawning != null)
            {
                
                mediator.OnSelectedDocumentTypeViewModelChange(new DocumentDrawableViewModel(mediator));
                mediator.OnSelectedDocumentChange(SelectedDocument); 
            }
    
            else if (SelectedDocument?.DocContentOther != null)
            {

                mediator.OnSelectedDocumentTypeViewModelChange( new DocumentOtherViewModel(mediator));  
                mediator.OnSelectedDocumentChange(SelectedDocument); 
            }
            

 
        }
    }
    public RelayCommand AddOtherDocument
    {
        get
        {
            //следующий комент для компилятора
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return addOtherDocument ??= new RelayCommand(obj =>
            {
                createOtherCreationView = new OtherDocumentCreationView()
                {

                    DataContext = new DocumentOtherCreationViewModel(mediator)
                };
                if (createOtherCreationView.ShowDialog() == true)
                {
                    //так надо что бы главное окно блокировалось
                    //при открытии диалогового окна для создания проекта
                }
            });
        }
    }
    public RelayCommand AddDrawableDocument
    {
        get
        {
            //следующий комент для компилятора
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return addDrawableDocument ??= new RelayCommand(obj =>
            {
                createDrawableCreationView = new DrawibleDocumentCreationView()
                {

                    DataContext = new DocumentDrawableCreationViewModel(mediator)
                };
                if (createDrawableCreationView.ShowDialog() == true)
                {
                    //так надо что бы главное окно блокировалось
                    //при открытии диалогового окна для создания проекта
                }
            });
        }
    }
    
    public object? SelectedViewModel
    {
        get { return selectedViewModel; }
        set { selectedViewModel = value; OnPropertyChanged(); }
    }
    private void OnSelectedProductChange(Docs_of_product product)
    {
        if (product.Documents != null) Documents = new ObservableCollection<Document>(product.Documents);
        Product = product;
    }
    private void OnSelectedDocumentTypeViewModelChange(object obj)
    {
        SelectedViewModel = obj;
    }
    private void OnProjectCreation(Document document)
    {
        Documents.Add(document);
        Product.Documents.Add(document);
        db.SaveChanges();
    }
    public DocumentViewModel(Mediator mediator, object lastVM, ApplicationContext db)
    {
        this.db = db;
        this.lastVM = lastVM;
        this.mediator = mediator;
        this.mediator.SelectedProduct += OnSelectedProductChange;
        this.mediator.SelectedDocumentTypeViewModel += OnSelectedDocumentTypeViewModelChange;
        this.mediator.DocumentCreate += OnProjectCreation;
 
        //SelectedViewModel = new DocumentDrawableViewModel(this.mediator);
        //SelectedViewModel = new DocumentOtherViewModel(this.mediator);
       // mediator.OnSelectedDocumentTypeViewModelChange(null);
    }
}