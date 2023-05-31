using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;
using Electronic_archive_of_design_and_construction_documents.ViewModels.ProjectFolder;
using Electronic_archive_of_design_and_construction_documents.Views;
using Electronic_archive_of_design_and_construction_documents.Views.ProjectFolder;
using Microsoft.EntityFrameworkCore;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.MainFolder;

public class MainWindowViewModel : BaseViewModel
{
    private ApplicationContext db;
    private object selectedViewModel;
    private object tempSelectedViewModel;


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
            var a = new ProjectVewModel(Project, db, mediator);
            mediator.SelectedViewModel += OnSelectedViewModelChange;
            mediator.TempSelectedViewModel += OnTempSelectedViewModelChange;
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
        db.doc_content_other.Load();
        db.doc_content_tech_drawning.Load();
        //отправка таблицы проектов в колекцию проектов внутри программы для дальнейшей работы с ними
        //другие таблицы так подгружать не надо вроде
        Project = db.Project.Local.ToObservableCollection();
    }
}