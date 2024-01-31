using CommunityToolkit.Maui.Core;
using Font = Microsoft.Maui.Font;
using CommunityToolkit.Maui.Alerts;

namespace Helix.UI.Mobile.Helpers.MessageHelper;

public  class MessageHelper
{
    public ISnackbar GetSnackMessage(string notifyText,string buttonText,string title,string description,Color backgroundColor, Color textColor,Color actionButtonTextColor, double cornerRadius=10,double fontSize=14, double actionButtonSize=14,double characterSpacing=0.5,int snackDuration=3)
    {
        

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = backgroundColor,
            TextColor = textColor,
            ActionButtonTextColor = actionButtonTextColor,
            CornerRadius = new CornerRadius(cornerRadius),
            Font = Font.SystemFontOfSize(fontSize),
            ActionButtonFont = Font.SystemFontOfSize(actionButtonSize),
            CharacterSpacing = characterSpacing
        };

        string text = notifyText;
        string actionButtonText = buttonText;
        //Action action = async () => await shell.DisplayAlert(title, description, "Tamam");
        TimeSpan duration = TimeSpan.FromSeconds(snackDuration);

        return Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

        
    }

}
