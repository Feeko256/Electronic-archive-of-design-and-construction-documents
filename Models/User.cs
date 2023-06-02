using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Electronic_archive_of_design_and_construction_documents.Core;

namespace Electronic_archive_of_design_and_construction_documents.Models;

public class User : BaseViewModel
{
    public int Id { get; set; }
    private string username;
    private string login;
    private string password;
    private Role? role;
    private ObservableCollection<Role>? roles;
    
    [NotMapped]
    public ObservableCollection<Role>? Roles
    {
        get => roles;
        set
        {
            roles = value;
            OnPropertyChanged();
        }
    } 

    public string Username
    {
        get => username;
        set
        {
            username = value;
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
    public Role Role
    {
        get => role;
        set
        {
            role = value;
            OnPropertyChanged();
        }
    }
}