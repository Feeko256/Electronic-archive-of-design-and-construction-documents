using System.Collections.ObjectModel;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;
using Electronic_archive_of_design_and_construction_documents.Views.DocsOfProductFolder;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.ProductFolder;

public class DocsOfProductViewModel : BaseViewModel
{
    public ObservableCollection<Docs_of_product> Products { get; set; }
    public Project Project { get; set; }
    private object lastVM;
    private RelayCommand goToProjects;
    private Mediator mediator;
    private ApplicationContext db;
    private DocsOfProductCreationView createProductView { get; set; }
    private RelayCommand addProductCommand;
    public RelayCommand GoToProjects
    {
        get
        {
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return goToProjects ??= new RelayCommand(obj =>
            {
                mediator.OnViewModelChange(lastVM);
            });
        }
    }
    public RelayCommand AddProductCommand
    {
        get
        {
            //следующий комент для компилятора
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return addProductCommand ??= new RelayCommand(obj =>
            {
                createProductView = new DocsOfProductCreationView()
                {
                    DataContext = new DocsOfProductCreationViewModel(mediator)
                };
                if (createProductView.ShowDialog() == true)
                {
                    //так надо что бы главное окно блокировалось
                    //при открытии диалогового окна для создания проекта
                }
            });
        }
    }
    private void OnProductCreation(Docs_of_product product)
    {
        Products.Add(product);
        Project.DocsOfProduct.Add(product);
        db.SaveChanges();
    }
    private void OnSelectedProjectChange(Project project)
    {
        Products = new ObservableCollection<Docs_of_product>(project.DocsOfProduct);
        Project = project;
    }
    public DocsOfProductViewModel(Mediator mediator, object lastVM, ApplicationContext db)
    {
        this.db = db;
        this.lastVM = lastVM;
        this.mediator = mediator;
        this.mediator.SelectedProject += OnSelectedProjectChange;
        this.mediator.ProductCreate += OnProductCreation;
       // Products = new ObservableCollection<Docs_of_product>(Project.docsOfProduct);
        //mediator.SelectedViewModel += OnTempSelectedViewModelChange;
    }
}