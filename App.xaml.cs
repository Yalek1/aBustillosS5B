using aBustillosS5B.Utils;

namespace aBustillosS5B
{
    public partial class App : Application
    {
        public static PersonaRepository personRepo;
        public App(PersonaRepository personarepository)
        {
            InitializeComponent();

            MainPage = new Views.Principal();
            personRepo = personarepository;
        }
    }
}
