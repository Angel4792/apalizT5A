namespace apalizT5A
{
    public partial class App : Application
    {
        public static PersonRepository PersonRepo { get; set; }
        public App(PersonRepository personRepository)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Personas());
            PersonRepo = personRepository;
        }
    }
}
