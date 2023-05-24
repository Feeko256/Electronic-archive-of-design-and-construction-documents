using System.Collections.ObjectModel;
using Electronic_archive_of_design_and_construction_documents.Core;

namespace Electronic_archive_of_design_and_construction_documents.Models;

public class Project : BaseViewModel
{
    public int Id { get; set; }
    private string? header;
    private ObservableCollection<Docs_of_product>? docsOfProduct { get; set; }

    public string? Header
    {
        get { return header; }
        set { header = value; OnPropertyChanged(); }
    }
    public ObservableCollection<Docs_of_product>? DocsOfProduct
    {
        get { return docsOfProduct; }
        set { docsOfProduct = value; OnPropertyChanged(); }
    }
}