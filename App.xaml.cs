namespace jcorreaS5A
{
    public partial class App : Application
    {
        public static Repositories.PersonRepository personRepo {  get; set; }
        public App(Repositories.PersonRepository personrepository)
        {
            InitializeComponent();
            personRepo = personrepository;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new Views.vHome());
        }
    }
}