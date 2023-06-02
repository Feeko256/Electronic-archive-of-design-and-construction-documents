using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.Authorization;

public class RegistrationViewModel : BaseViewModel
{
    private Mediator mediator;
    private ApplicationContext db;
    private RelayCommand createUser;
    public ObservableCollection<Role> Roles { get; set; }
    public ObservableCollection<User> Users { get; set; }
    private Role selectedRole;
    private string password;

    private string userName;
    private string login;

    public string UserName
    {
        get => userName;
        set
        {
            userName = value;
            OnPropertyChanged();
        }
    }

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

    public Role SelectedRole
    {
        get => selectedRole;
        set
        {
            selectedRole = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand CreateUser
    {
        get
        {
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return createUser ??= new RelayCommand(obj =>
            {
                if (!Users.Any(f => f.Login == Login))
                {
                    Users.Add(new User() { Username = UserName, Login = Login, Password = Password, Role = SelectedRole });
                    db.SaveChanges();
                    CloseWindow(obj);
                }

                MessageBox.Show("Логин уже занят!");
            });
        }
    }

    private void CloseWindow(object window)
    {
        (window as Window)?.Close();
    }

    public RegistrationViewModel(Mediator mediator, ApplicationContext db)
    {
        this.mediator = mediator;
        this.db = db;
        Roles = db.Role.Local.ToObservableCollection();
        Users = db.User.Local.ToObservableCollection();
    }
}