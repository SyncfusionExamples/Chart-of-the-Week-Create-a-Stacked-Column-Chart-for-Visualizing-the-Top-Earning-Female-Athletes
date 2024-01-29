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
        public float XOffset { get; private set; }
        public float YOffset { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }

        public CategoryAxisExt()
        {
            SetPlatformValues();
        }

        private void SetPlatformValues()
        {
            if (Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android)
            {
                XOffset = 85;
                YOffset = 8;
                Width = 15;
                Height = 15;
            }
            else if (Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.WinUI)
            {
                XOffset = 90;
                YOffset = 13;
                Width = 25;
                Height = 25;
            }
            else if (Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.iOS)
            {
                XOffset = 95;
                YOffset = 10;
                Width = 20;
                Height = 20;
            }
            else
            {
                XOffset = 100;
                YOffset = 15;
                Width = 30;
                Height = 30;
            }
        }

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
                    canvas.DrawImage(image, (float)arrangeRect.Left + XOffset, top - YOffset, Width, Height);
                }
            }
        }
    }
}
