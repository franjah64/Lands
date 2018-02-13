



namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {

        #region Atributos
        // Propiedades privadas para completar el Biding
        // por convención el atributo privado inicia en minúscula el PÚBLICO con mayúscula
        // aquí se ponen las que se quieren cambiar
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Propiedades
        // aquí debe existir una propiedad por cada campo en XAML que este con Binding
        public string Email { get; set; }

        public string Password { 
            get { return this.password;  }
            set { SetValue(ref this.password, value); }
            }

        public bool IsRunning {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered { get; set; }

        public bool IsEnabled {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Comandos
        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }



        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar un e-mail",
                    "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debe ingresar un password",
                    "Aceptar");
                return;
            }

            // para que aparezca la rueda girando
            this.IsRunning = true;
            // para que se deshabiliten los botones
            this.IsEnabled = false; 

            if (this.Email != "hola@hola.com" || this.Password != "1234")
            {
                // para que des-aparezca la rueda girando
                this.IsRunning = false;
                // para que se habiliten los botones
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   "E-mail o password incorrecto",
                   "Aceptar");
                this.Password = string.Empty;
                return;
            }
            // para que des-aparezca la rueda girando
            this.IsRunning = false;
            // para que se habiliten los botones
            this.IsEnabled = true;
            await Application.Current.MainPage.DisplayAlert(
                   "OK",
                   "todo bien",
                   "Aceptar");
            return;

        }

        #endregion

        #region Constructores
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsRunning = false;  // no es necesario, por default es false
            this.IsEnabled = true;  // botones habilitados cuando inicia
        }
        #endregion
    }
}
