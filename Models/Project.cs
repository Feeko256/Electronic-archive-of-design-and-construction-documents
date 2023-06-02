using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Electronic_archive_of_design_and_construction_documents.Core;

namespace Electronic_archive_of_design_and_construction_documents.Models;

public class Project : BaseViewModel
{
    public int Id { get; set; }
    private string header;
    private string annotation;
    private ObservableCollection<Docs_of_product> docsOfProduct;

    [Column(TypeName = "varchar(100)")]
    public string Header
    {
        get => header;
        set { header = value; OnPropertyChanged(); }
    }
    [Column(TypeName = "varchar(255)")]
    public string Annotation
    {
        get => annotation;
        set { annotation = value; OnPropertyChanged(); }
    }
    public ObservableCollection<Docs_of_product> DocsOfProduct
    {
        get => docsOfProduct;
        set { docsOfProduct = value; OnPropertyChanged(); }
    }
}