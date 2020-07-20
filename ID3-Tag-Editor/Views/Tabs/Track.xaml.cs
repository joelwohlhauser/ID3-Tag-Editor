using System.Windows.Controls;
using System.Windows.Data;

namespace ID3_Tag_Editor.Views.Tabs
{
    public partial class Track : Page
    {
        public Track()
        {
            InitializeComponent();
            DataContext = MainWindow.myViewModel;
        }
    }
}
