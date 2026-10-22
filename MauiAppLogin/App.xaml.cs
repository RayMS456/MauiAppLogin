using Microsoft.Extensions.DependencyInjection;

namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            string? usuario_logado = null;

            Task.Run(async () =>
            {
                usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
                if (usuario_logado == null)
                {
                    MainPage = new Login();
                } else
                {
                    MainPage = new Protegida();
                }
            });

            // Define a página inicial como a tela de login
            MainPage = new Login();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Cria a janela padrão do aplicativo
            var window = base.CreateWindow(activationState);

            // Define o tamanho da janela para desktop (largura e altura)
            window.Width = 400;
            window.Height = 600;

            return window;
        }

        protected override void OnStart()
        {
            base.OnStart();
            // Lógicas adicionais ao iniciar o app podem vir aqui
        }
    }//fecha classe

}//fecha namespace