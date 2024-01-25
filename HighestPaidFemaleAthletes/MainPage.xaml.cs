using Syncfusion.Maui.Charts;
using System.Globalization;
using System.Reflection;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Controls.PlatformConfiguration;

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
        float xOffset = Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android ? 85 : Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.WinUI ? 90 : Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.iOS ? 95 : 100;
        float yOffset = Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android ? 8 : Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.WinUI ? 13 : Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.iOS ? 10 : 15;
        float width = Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android ? 15 : Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.WinUI ? 25 : Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.iOS ? 20 : 30;
        float height = Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.Android ? 15 : Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.WinUI ? 25 : Microsoft.Maui.Devices.DeviceInfo.Platform == Microsoft.Maui.Devices.DevicePlatform.iOS ? 20 : 30;

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
                    canvas.DrawImage(image, (float)arrangeRect.Left + xOffset, top - yOffset, width, height);
                }
            }
        }
    }
}
