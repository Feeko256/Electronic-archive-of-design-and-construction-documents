using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Electronic_archive_of_design_and_construction_documents.Core;

namespace Electronic_archive_of_design_and_construction_documents.Models;

public class Document : BaseViewModel
{
    public int Id { get; set; }
    private ObservableCollection<doc_content_other> ? docContentOther { get; set; }
    private ObservableCollection<doc_content_thech_drawning> ? docContentThechDrawning { get; set; }
    private string header;
    private string doc_type;
    private string note;
    
    public string Doc_type
    {
        get { return doc_type; }
        set
        {
            doc_type = value;
            OnPropertyChanged();
        }
    }
    public string Note
    {
        get { return note; }
        set
        {
            note = value;
            OnPropertyChanged();
        }
    }
    public string Header
    {
        get { return header; }
        set { header = value; OnPropertyChanged(); }
    }
    public ObservableCollection<doc_content_other>? Doc_Content_Other
    {
        get { return docContentOther; }
        set { docContentOther = value; OnPropertyChanged(); }
    }
    public ObservableCollection<doc_content_thech_drawning>? Doc_Content_Tech_Drawning
    {
        get { return docContentThechDrawning; }
        set { docContentThechDrawning = value; OnPropertyChanged(); }
    }
}