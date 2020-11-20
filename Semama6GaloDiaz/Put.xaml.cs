using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using System.Net.Http;
using System.Web;

namespace Semama6GaloDiaz
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Put : ContentPage
    {
        public Put()
        {
            InitializeComponent();
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MainPage());


        }


        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {


            string Url = "http://192.168.1.61/Rest/post.php";
            HttpClient httpClient = new HttpClient();
            var builder = new UriBuilder(Url);
            var query = HttpUtility.ParseQueryString(builder.Query);

            query["codigo"] = codigo.Text;
            query["nombre"] = txtActualizar_nombre.Text;
            query["apellido"] = txtActualizar_apellido.Text;
            query["edad"] = txtActualizar_edad.Text;

            builder.Query = query.ToString();
            string url = builder.ToString();


            var consultaSerializada = await httpClient.PutAsync(url, null);
            await App.Current.MainPage.DisplayAlert("Alerta", "Dato Ingresado correctamente", "ok");




        }
    }
}