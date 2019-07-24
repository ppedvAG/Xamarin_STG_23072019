using System;
using Xamarin.Forms;

namespace HalloStyle
{
    class EmailValidationTriggerAction : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender)
        {
            if (string.IsNullOrWhiteSpace(sender.Text) || !sender.Text.Contains("@"))
                sender.BackgroundColor = Color.DeepPink;
            else
                sender.BackgroundColor = Color.Default;
        }
    }
}
