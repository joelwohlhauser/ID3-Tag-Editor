using System.Windows.Controls;

namespace ID3_Tag_Editor.Views.Tabs
{
    public partial class General : Page
    {
        public General()
        {
            InitializeComponent();
            DataContext = MainWindow.myViewModel;
        }
    }
}
