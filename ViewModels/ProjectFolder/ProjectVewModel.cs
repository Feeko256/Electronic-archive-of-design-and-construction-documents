using System.Collections.ObjectModel;
using System.Windows;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;
using Electronic_archive_of_design_and_construction_documents.ViewModels.Authorization;
using Electronic_archive_of_design_and_construction_documents.ViewModels.ProductFolder;
using Electronic_archive_of_design_and_construction_documents.Views;
using Electronic_archive_of_design_and_construction_documents.Views.Authorization;
using Electronic_archive_of_design_and_construction_documents.Views.ProjectFolder;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.ProjectFolder;

public class ProjectVewModel : BaseViewModel
{
    public ObservableCollection<Project> Projects { get; set; }
    private ProjectCreatinView createProjectView { get; set; }
    private RelayCommand addProjectCommand;
    private ApplicationContext db;
    private RelayCommand goToProducts;
    private RelayCommand registerNewUser;
    private Mediator mediator { get; set; }
    private Project selectedProject;
    public User User { get; set; }
    private Registration Registration { get; set; }
    private bool projectsAcces;

    public bool ProjectsAcces
    {
        get => projectsAcces;
        set
        {
            projectsAcces = value;
            OnPropertyChanged();
        }
    }

    public Project? SelectedProject
    {
        get { return selectedProject; }
        set 
        {
            selectedProject = value; 
            OnPropertyChanged();
            if (SelectedProject?.DocsOfProduct == null)
                    SelectedProject.DocsOfProduct = new ObservableCollection<Docs_of_product>();
        }
    }

    public RelayCommand AddProjectCommand
    {
        get
        {
            //следующий комент для компилятора
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return addProjectCommand ??= new RelayCommand(obj =>
            {
                createProjectView = new ProjectCreatinView()
                {

                    DataContext = new ProjectCreationViewModel(mediator)
                };
                if (createProjectView.ShowDialog() == true)
                {
                    //так надо что бы главное окно блокировалось
                    //при открытии диалогового окна для создания проекта
                }
            }, obj=> User != null && User.Id == 1);
        }
    }

    public RelayCommand GoToProducts
    {
        get
        {
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return goToProducts ??= new RelayCommand(obj =>
            {
                mediator.OnViewModelChange(new DocsOfProductViewModel(mediator, this, db, User));
                if (SelectedProject != null) 
                    mediator.OnSelectedProjectChange(SelectedProject);
            }, obj => SelectedProject != null);
        }
    }
    public RelayCommand RegisterNewUser
    {
        get
        {
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return registerNewUser ??= new RelayCommand(obj =>
            {
                Registration = new Registration()
                {

                    DataContext = new RegistrationViewModel(mediator, db)
                };
                if (Registration.ShowDialog() == true)
                {
                    //так надо что бы главное окно блокировалось
                    //при открытии диалогового окна для создания проекта
                }  
            }, obj => User!=null && User.Role.Id == 1);
        }
    }
    private void OnProjectCreation(Project project)
    {
        Projects.Add(project);
        db.SaveChanges();
    }
    private void OnUserChange(User user)
    {
        User = user;
        if (user != null)
        {
            MessageBox.Show("добро пожаловать " + user.Username);
            ProjectsAcces = true;
        }
            
    }
    public ProjectVewModel(ObservableCollection<Project>? projects, ApplicationContext db, Mediator mediator)
    {
        this.db = db;
        Projects = projects;
        this.mediator = mediator;
        this.mediator.ProjectCreate += OnProjectCreation;
        this.mediator.CurrentUser += OnUserChange;
    }
}