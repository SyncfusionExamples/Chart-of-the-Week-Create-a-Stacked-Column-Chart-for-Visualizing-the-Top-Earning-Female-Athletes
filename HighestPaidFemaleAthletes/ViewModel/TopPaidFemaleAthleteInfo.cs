using System.Collections.ObjectModel;
using System.Reflection;


namespace HighestPaidFemaleAthletes
{
    public class TopPaidFemaleAthleteInfo
    {
        public float XOffset { get; private set; }
        public float YOffset { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }
        public ObservableCollection<FemaleAthletesModel> AthletesData { get; set; }

        public Dictionary<string, Stream> Streams { get; } = new Dictionary<string, Stream>();

        Stream? stream;
        public TopPaidFemaleAthleteInfo()
        {
            AthletesData = new ObservableCollection<FemaleAthletesModel>()
            {
                new FemaleAthletesModel() {AthleteName = "Leyla Fernandez", OnFieldEarning = 1.8, OffFieldEarning = 7,Country="canada"},
                new FemaleAthletesModel() {AthleteName = "Elena Rybakina", OnFieldEarning = 5.5, OffFieldEarning = 4,Country="kazakhstan"},
                new FemaleAthletesModel() {AthleteName = "Venus Williams", OnFieldEarning = 0.2, OffFieldEarning = 12,Country="united_states"},
                new FemaleAthletesModel() {AthleteName = "Jessica Pegula", OnFieldEarning = 6, OffFieldEarning = 6.5,Country="united_states"},
                new FemaleAthletesModel() {AthleteName = "Aryna Sabalenka", OnFieldEarning = 8.2, OffFieldEarning = 6.5,Country="belarus"},
                new FemaleAthletesModel() {AthleteName = "Naomi Osaka", OnFieldEarning = 0, OffFieldEarning = 15,Country="japan"},
                new FemaleAthletesModel() {AthleteName = "Emma Raducanu", OnFieldEarning = 0.2, OffFieldEarning = 15,Country="united_kingdom"},
                new FemaleAthletesModel() {AthleteName = "Coco Gauff", OnFieldEarning = 6.7,OffFieldEarning = 15,Country="united_states"},
                new FemaleAthletesModel() {AthleteName = "Eileen Gu",OffFieldEarning=22,OnFieldEarning=0.1,Country="china"},
                new FemaleAthletesModel() {AthleteName = "Iga Swiatek",OnFieldEarning=9.9,OffFieldEarning=14,Country="poland"},
            };

            Streams = GetImageSources();
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
        private Dictionary<string, Stream> GetImageSources()
        {
            Dictionary<string, Stream> keyValues = new Dictionary<string, Stream>();

            Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;

            for (int i = 0; i < AthletesData.Count; i++)
            {
                string imageName = $"{AthletesData[i].Country}.png";
                stream = assembly.GetManifestResourceStream($"HighestPaidFemaleAthletes.Resources.Images.{imageName}");

                if (stream != null && AthletesData[i].AthleteName != null)
                {
                    keyValues.Add(AthletesData[i].AthleteName.ToString(), stream);
                }
            }
            return keyValues;
        }
    }
}
