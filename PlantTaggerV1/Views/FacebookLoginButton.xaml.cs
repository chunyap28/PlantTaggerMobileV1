using System;
using System.Collections.Generic;
using Xamarin.Forms;

using Xamarin.Auth;
using PlantTaggerV1.Libraries;
using PlantTaggerV1.Configs;

namespace PlantTaggerV1.Views
{
    public partial class FacebookLoginButton : ContentView
    {
        public event EventHandler Authenticated;
        OAuth2Authenticator auth;

        public FacebookLoginButton()
        {
            InitializeComponent();

            //xFacebookLabel.Text = FontAwesome.FAFacebookOfficial;

            auth = new OAuth2Authenticator(
                        clientId: Constants.FBClientId,
                        scope: "",
                        authorizeUrl: new Uri("https://www.facebook.com/v2.12/dialog/oauth"),
                        redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html")
                    );
            auth.AllowCancel = true;
            auth.Completed += OnAuthCompleted;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("onButtonClicked() triggered");

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(auth);
        }

        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("OnAuthCompleted() triggered");
            if( e.IsAuthenticated == true ){                
                System.Diagnostics.Debug.WriteLine(e.Account.ToString());    
            }
        }
    }
}
