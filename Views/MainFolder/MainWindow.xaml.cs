using Electronic_archive_of_design_and_construction_documents.ViewModels.MainFolder;
using SourceChord.FluentWPF;

namespace Electronic_archive_of_design_and_construction_documents.Views.MainFolder
{
    public partial class MainWindow : AcrylicWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}