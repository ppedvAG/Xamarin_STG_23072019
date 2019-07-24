using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HalloImages
{
    class EmbeddedImage : IMarkupExtension
    {
        public string Id { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(Id))
                return null;

            return ImageSource.FromResource(Id);
        }
    }
}
