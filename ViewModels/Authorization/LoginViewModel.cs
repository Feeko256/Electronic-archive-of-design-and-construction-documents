using System.Collections.ObjectModel;
using System.Windows;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.Authorization;

public class LoginViewModel : BaseViewModel
{
    private Mediator mediator;
    private ApplicationContext db;
    private ObservableCollection<User> users;
    private string login;
    private string password;
    private RelayCommand loginCommand;


    public string Login
    {
        get => login;
        set
        {
            login = value;
            OnPropertyChanged();
        }
    }
    public string Password
    {
        get => password;
        set
        {
            password = value;
            OnPropertyChanged();
        }
    }
    public RelayCommand LoginCommand
    {
        get
        {
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return loginCommand ??= new RelayCommand(obj =>
            {
                foreach (var a in users)
                {
                    if (Login == a.Login && Password == a.Password)
                    {
                        mediator.OnCurrentUserChange(a);
                        CloseWindow(obj);
                        break;
                    }
                    MessageBox.Show("Неверный логин или пароль!");
                }
            });
        }
    }
    private void CloseWindow(object window)
    {
        (window as Window)?.Close();
    }

    public LoginViewModel(Mediator mediator, ApplicationContext db)
    {
        this.mediator = mediator;
        this.db = db;
        users = db.User.Local.ToObservableCollection();

    }
    
}