using ID3_Tag_Editor.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace ID3_Tag_Editor
{
    public partial class MainWindow : Window
    {
        public static Main_ViewModel myViewModel;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = myViewModel = new Main_ViewModel();
        }


        private void DragWindows(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
