using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Electronic_archive_of_design_and_construction_documents.Core;

public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
}