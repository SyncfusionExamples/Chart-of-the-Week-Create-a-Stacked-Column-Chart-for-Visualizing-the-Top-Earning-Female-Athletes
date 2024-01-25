using Syncfusion.Maui.Charts;
using System.Globalization;
using System.Reflection;
using Microsoft.Maui.Graphics.Platform;

namespace HighestPaidFemaleAthletes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class CategoryAxisExt : CategoryAxis
    {
        Stream? stream = null;
        protected override void DrawAxis(ICanvas canvas, Rect arrangeRect)
        {
            base.DrawAxis(canvas, arrangeRect);

            Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;

            if (assembly != null)
            {
                if(this.BindingContext is TopPaidFemaleAthleteInfo viewModel)
                {
                    for (int i = 0; i < VisibleLabels.Count; i++)
                    {
                        if (viewModel.Streams.Count <= VisibleLabels.Count)
                        {
                            string imageName = $"flag{i}.png";
                            stream = assembly.GetManifestResourceStream($"HighestPaidFemaleAthletes.Resources.Images.{imageName}");
                            if (stream != null)
                            {
                                viewModel.Streams.Add(stream);
                            }
                        }
                        else
                        {
                            stream = viewModel.Streams[i];
                        }

                        if (stream != null)
                        {
                            var image = PlatformImage.FromStream(stream);
                            var top = ValueToPoint(VisibleLabels[i].Position); // Assuming positions start from 0
#if ANDROID || IOS
                            canvas.DrawImage(image, (float)arrangeRect.Left + 85, top - 8, 15, 15);
#elif WINDOWS || MACCATALYST
                            canvas.DrawImage(image, (float)arrangeRect.Left + 90, top -13, 25, 25);
#endif
                        }

                    }
                }
            }
        }
    }
}
