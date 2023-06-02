using System;
using System.Collections.ObjectModel;
using System.Windows;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;
using Microsoft.Win32;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.DocumentFolder;

public class DocumentDrawingCreationViewModel : BaseViewModel
{
    private Mediator mediator;
    private RelayCommand createDrawableDocument;
    private string note;
    private string header;
    private string denotation;
    private string material;
    private string letter;
    private float mass;
    private string scale;
    private string company_name;
    private int version_number;
    private ObservableCollection<string>? source;
    private RelayCommand addNewDocFileCommand;
    public User User { get; set; }
    public string Header
    {
        get { return header; }
        set { header = value; OnPropertyChanged(); }
    }
    public string Note
    {
        get { return note; }
        set { note = value; OnPropertyChanged(); }
    }
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

    public RelayCommand CreateDrawableDocument
    {
        get
        {           
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return createDrawableDocument ??= new RelayCommand(obj =>
            {
                var document = new Document()
                {
                    Header = Header, Note = Note,
                    Doc_Content_Tech_Drawning = new ObservableCollection<doc_content_thech_drawning>()
                    {
                        new doc_content_thech_drawning()
                        {
                            Created_at = DateTime.Now,
                            Source = new ObservableCollection<string>(Source),
                            Version_number = Version_number,
                            Denotation = Denotation,
                            Material = Material,
                            Letter = Letter,
                            Mass = Mass,
                            Scale = Scale,
                            Company_name = Company_name,
                            Creator = User,
                            Editor = User
                        }
                    },
                    Doc_type = "Документ-чертеж"
                };
                mediator.OnDocumentCreate(document);
                CloseWindow(obj);
            });
        } 
    }
    public RelayCommand AddNewDocFileCommand
    {
        get
        {
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract

            return addNewDocFileCommand ??= new RelayCommand(obj =>
            {

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    Source.Add(openFileDialog.FileName);
                }
            });
        }
    }
    private void CloseWindow(object window)
    {
        (window as Window)?.Close();
    }

    public DocumentDrawingCreationViewModel(Mediator mediatorб, User user)
    {
        this.mediator = mediator;
        User = user;
        Source = new ObservableCollection<string>();
    }
}