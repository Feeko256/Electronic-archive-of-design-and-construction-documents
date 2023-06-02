using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using Electronic_archive_of_design_and_construction_documents.Core;

namespace Electronic_archive_of_design_and_construction_documents.Models;

public class doc_content_other : BaseViewModel
{
    public int Id { get; set; }
    private int version_number;
    private DateTime created_at;
    private User? creator;
    private User? editor;
    private ObservableCollection<string>? source;
    
    public int Version_number
    {
        get { return version_number; }
        set { version_number = value; OnPropertyChanged(); }
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
    public User? Creator
    {
        get { return creator; }
        set { creator = value; OnPropertyChanged(); }
    }
    public User? Editor
    {
        get { return editor; }
        set { editor = value; OnPropertyChanged(); }
    }
}