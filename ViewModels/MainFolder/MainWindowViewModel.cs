using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;
using Electronic_archive_of_design_and_construction_documents.ViewModels.Authorization;
using Electronic_archive_of_design_and_construction_documents.ViewModels.ProjectFolder;
using Electronic_archive_of_design_and_construction_documents.Views;
using Electronic_archive_of_design_and_construction_documents.Views.Authorization;
using Electronic_archive_of_design_and_construction_documents.Views.ProjectFolder;
using Microsoft.EntityFrameworkCore;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.MainFolder;

public class MainWindowViewModel : BaseViewModel
{
    private ApplicationContext db;
    private object selectedViewModel;
    private object tempSelectedViewModel;
    private Registration Registration { get; set; }

    private ObservableCollection<Project> Project { get; set; }
   // public UserControl Page { get; set; }
    private Mediator mediator;//необходим для передачи данных между ViewModels
    public object SelectedViewModel
    {
        get { return selectedViewModel; }
        set { selectedViewModel = value; OnPropertyChanged(); }
    }

    private void OnSelectedViewModelChange(object obj)
    {
        SelectedViewModel = obj;
    }
    private void OnTempSelectedViewModelChange(object obj)
    {
        SelectedViewModel = obj;
    }

    public MainWindowViewModel()
    {
            db = new ApplicationContext();//инициализация контекста бд
            mediator = new Mediator();
            DbLoad();

            Registration = new Registration()
            {

                DataContext = new UserCreationViewModel(mediator, db)
            };
            if (Registration.ShowDialog() == true)
            {
                //так надо что бы главное окно блокировалось
                //при открытии диалогового окна для создания проекта
            }
            var a = new ProjectVewModel(Project, db, mediator);
            mediator.SelectedViewModel += OnSelectedViewModelChange;
            mediator.OnViewModelChange(a);
    }

    private void DbLoad()
    {
        //db.Database.EnsureDeleted(); //вызвать при изменении структуры бд
        db.Database.EnsureCreated(); //загрузка бд
        //загрузка таблиц
        db.Project.Load();
        db.Docs_of_product.Load();
        db.Document.Load();
        db.Doc_content_other.Load();
        db.Doc_content_tech_drawning.Load();
        db.User.Load();
        db.Role.Load();
        //отправка таблицы проектов в колекцию проектов внутри программы для дальнейшей работы с ними
        //другие таблицы так подгружать не надо вроде
        Project = db.Project.Local.ToObservableCollection();
    }
}