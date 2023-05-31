using System;
using System.Collections.ObjectModel;
using Electronic_archive_of_design_and_construction_documents.Core;

namespace Electronic_archive_of_design_and_construction_documents.Models;

public class doc_content_thech_drawning : BaseViewModel
{
    public int Id { get; set; }
    private string denotation;
    private string material;
    private string letter;
    private float mass;
    private string scale;
    private string company_name;
    private int version_number;
    private DateTime created_at;
    private ObservableCollection<string>? source;
    
    public string Denotation
    {
        get { return denotation; }
        set { denotation = value; OnPropertyChanged(); }
    }
    public string Material
    {
        get { return material; }
        set { material = value; OnPropertyChanged(); }
    }
    public string Letter
    {
        get { return letter; }
        set { letter = value; OnPropertyChanged(); }
    }
    public float Mass
    {
        get { return mass; }
        set { mass = value; OnPropertyChanged(); }
    } 
    public string Scale
    {
        get { return scale; }
        set { scale = value; OnPropertyChanged(); }
    }
    public string Company_name
    {
        get { return company_name; }
        set { company_name = value; OnPropertyChanged(); }
    } 
    public DateTime Created_at
    {
        get { return created_at; }
        set { created_at = value; OnPropertyChanged(); }
    } 
    public ObservableCollection<string>? Source
    {
        get { return source; }
        set { source = value; OnPropertyChanged(); }
    } 
    public int Version_number
    {
        get { return version_number; }
        set { version_number = value; OnPropertyChanged(); }
    }
}