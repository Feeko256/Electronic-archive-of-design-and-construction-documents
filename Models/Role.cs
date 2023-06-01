using Electronic_archive_of_design_and_construction_documents.Core;

namespace Electronic_archive_of_design_and_construction_documents.Models;

public class Role : BaseViewModel
{
    public int Id { get; set; }
    private string roleName;

    public string RoleName
    {
        get => roleName;
        set
        {
            roleName = value;
            OnPropertyChanged();
        }
    }
}