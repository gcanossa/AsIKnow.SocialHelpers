using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AsIKnow.SocialHelpers
{
    public static class SocialHelpersExtensions
    {
        public static IServiceCollection AddSocialHelpers(this IServiceCollection ext, AuthenticationOptions options)
        {
            //TODO: vedi se rendere configurabili anche gli altri parametri
            ext.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = options.Facebook.AppId;
                facebookOptions.AppSecret = options.Facebook.AppSecret;

                //https://developers.facebook.com/docs/graph-api/reference/user
                facebookOptions.Scope.Add("email");
                facebookOptions.Fields.Add("gender");
                facebookOptions.Fields.Add("verified");
                facebookOptions.Fields.Add("birthday");
                facebookOptions.Fields.Add("devices");
                facebookOptions.Fields.Add("link");
                facebookOptions.SaveTokens = true;
            });
            ext.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = options.Google.ClientId;
                googleOptions.ClientSecret = options.Google.ClientSecret;
                //https://stackoverflow.com/questions/45855503/how-to-retrieve-google-profile-picture-from-logged-in-user-with-asp-net-core-ide
                googleOptions.Scope.Add("profile");
                googleOptions.Scope.Add("email");
                googleOptions.Scope.Add("openid");
                googleOptions.SaveTokens = true;
            });

            return ext;
        }
    }
}
