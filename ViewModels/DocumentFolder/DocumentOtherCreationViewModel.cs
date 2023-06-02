using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Electronic_archive_of_design_and_construction_documents.Core;
using Electronic_archive_of_design_and_construction_documents.Core.Mediator;
using Electronic_archive_of_design_and_construction_documents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace Electronic_archive_of_design_and_construction_documents.ViewModels.DocumentFolder;

public class DocumentOtherCreationViewModel : BaseViewModel
{
    private Mediator mediator;
    private RelayCommand createOtherDocument;
    private string header;
    private string note;
    private int versionNumber;
    private ObservableCollection<string> files;
    private RelayCommand addNewDocFileCommand;
    public User User { get; set; }
    public ObservableCollection<string> Files
    {
        get => files;
        set
        {
            files = value;
            OnPropertyChanged();
        }
    }

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
    public int VersionNumber
    {
        get { return versionNumber; }
        set { versionNumber = value; OnPropertyChanged(); }
    }

    public RelayCommand CreateOtherDocument
    {
        get
        {
            // ReSharper disable once NullCoalescingConditionIsAlwaysNotNullAccordingToAPIContract
            return createOtherDocument ??= new RelayCommand(obj =>
            {
                var document = new Document()
                {
                    Header = Header, Note = Note,
                    Doc_Content_Other = new ObservableCollection<doc_content_other>()
                    {
                        new doc_content_other
                        {
                            Created_at = DateTime.Now,
                            Source = new ObservableCollection<string>(Files),
                            Version_number = VersionNumber,
                            Creator = User,
                            Editor = User
                        }
                    },
                    Doc_type = "Обычный документ"
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
                    Files.Add(openFileDialog.FileName);
                }
            });
        }
    }

    private void CloseWindow(object window)
    {
        (window as Window)?.Close();
    }

    public DocumentOtherCreationViewModel(Mediator mediator, User user)
    {
        this.mediator = mediator;
        User = user;
        Files = new ObservableCollection<string>();
    }
}