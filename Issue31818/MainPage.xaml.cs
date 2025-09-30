namespace Issue31818
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            if(FileSystem.Current.AppPackageFileExistsAsync("MainPage.xaml").Result)
            {
                Shell.Current.CurrentPage.DisplayAlert("Did you find the file?", "Yes", "OK");
            }
            else
            {
                Shell.Current.CurrentPage.DisplayAlert("Did you find the file?", "No", "OK");
            }
        }
    }
}
