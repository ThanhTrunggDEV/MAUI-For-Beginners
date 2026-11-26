using MAUI_For_Beginners.ViewModel;

namespace MAUI_For_Beginners
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
        public MainPage()
        {
            InitializeComponent();

        }

    }
}
