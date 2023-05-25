using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Electronic_archive_of_design_and_construction_documents.Core;

namespace Electronic_archive_of_design_and_construction_documents.Models;

public class Document : BaseViewModel
{
    public int Id { get; set; }
    private doc_content_other? docContentOther { get; set; }
    private doc_content_thech_drawning? docContentThechDrawning { get; set; }
    private string? header;
    private string type;
    public string Type
    {
        get { return type; }
        set
        {
            type = value;
            OnPropertyChanged();
        }
    }
    public string Header
    {
        get { return header; }
        set { header = value; OnPropertyChanged(); }
    }
    public doc_content_other? DocContentOther
    {
        get { return docContentOther; }
        set { docContentOther = value; OnPropertyChanged(); }
    }
    public doc_content_thech_drawning? DocContentThechDrawning
    {
        get { return docContentThechDrawning; }
        set { docContentThechDrawning = value; OnPropertyChanged(); }
    }
}