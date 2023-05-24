using System.Collections.ObjectModel;
using System.Windows;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.ProjectFolder;

public class ProjectCreationViewModel : BaseViewModel
{
    private Mediator mediator;
    private RelayCommand createProject;
    private string header;

    public string Header
    {
        get { return header; }
        set { header = value; OnPropertyChanged(); }
    }

    public RelayCommand CreateProject
    {
        get
        {           
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return createProject ??= new RelayCommand(obj =>
            {
                var project = new Project { Header = this.Header, DocsOfProduct = new ObservableCollection<Docs_of_product>()};
                mediator.OnProjectCreation(project);
                CloseWindow(obj);
            });
        } 
    }
    private void CloseWindow(object window)
    {
        (window as Window)?.Close();
    }
    public ProjectCreationViewModel(Mediator mediator)
    {
        this.mediator = mediator;
 
    }
}