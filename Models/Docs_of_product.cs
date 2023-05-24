using System.Collections.ObjectModel;
using Electronic_archive_of_design_and_construction_documents.Core;

namespace Electronic_archive_of_design_and_construction_documents.Models;

public class Docs_of_product : BaseViewModel
{
    public int Id { get; set; }
    private string? header;
    private ObservableCollection<Document>? documents { get; set; }

    public string? Header
    {
        get { return header; }
        set { header = value; OnPropertyChanged(); }
    }
    public ObservableCollection<Document>? Documents
    {
        get { return documents; }
        set { documents = value; OnPropertyChanged(); }
    }
}