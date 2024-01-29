using Syncfusion.Maui.Charts;
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
        protected override void DrawAxis(ICanvas canvas, Rect arrangeRect)
        {
            base.DrawAxis(canvas, arrangeRect);

            foreach (ChartAxisLabel label in VisibleLabels)
            {
                string? labelText = label.Content.ToString();

                if (this.BindingContext is TopPaidFemaleAthleteInfo viewModel && labelText != null && viewModel.Streams.ContainsKey(labelText))
                {
                    Stream stream = viewModel.Streams[labelText];
                    var image = PlatformImage.FromStream(stream);
                    var top = ValueToPoint(label.Position); // Assuming positions start from 0
                    canvas.DrawImage(image, (float)arrangeRect.Left + viewModel.XOffset, top - viewModel.YOffset, viewModel.Width, viewModel.Height);
                }
            }
        }
    }
}
