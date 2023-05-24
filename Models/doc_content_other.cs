using Electronic_archive_of_design_and_construction_documents.Core;

namespace Electronic_archive_of_design_and_construction_documents.Models;

public class doc_content_other : BaseViewModel
{
    public int Id { get; set; }
    private string? header;
    public string Header
    {
        get { return header; }
        set { header = value; OnPropertyChanged(); }
    }
}