using Microsoft.Maui.Graphics.Platform;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HighestPaidFemaleAthletes
{
    public class TopPaidFemaleAthleteInfo
    {

        public ObservableCollection<FemaleAthletesModel> AthletesData { get; set; }

        public ObservableCollection<Stream> Streams { get; set; }

        public TopPaidFemaleAthleteInfo()
        {
            AthletesData = new ObservableCollection<FemaleAthletesModel>()
            {
#if !ANDROID && !IOS
                new FemaleAthletesModel() {AthleteName = "Leyla Fernandez", OnFieldEarning = 1.8, OffFieldEarning = 7},
                new FemaleAthletesModel() {AthleteName = "Elena Rybakina", OnFieldEarning = 5.5, OffFieldEarning = 4},
                new FemaleAthletesModel() {AthleteName = "Venus Williams", OnFieldEarning = 0.2, OffFieldEarning = 12},
                new FemaleAthletesModel() {AthleteName = "Jessica Pegula", OnFieldEarning = 6, OffFieldEarning = 6.5},
                new FemaleAthletesModel() {AthleteName = "Aryna Sabalenka", OnFieldEarning = 8.2, OffFieldEarning = 6.5},
#endif
                new FemaleAthletesModel() {AthleteName = "Naomi Osaka", OnFieldEarning = 0, OffFieldEarning = 15},
                new FemaleAthletesModel() {AthleteName = "Emma Raducanu", OnFieldEarning = 0.2, OffFieldEarning = 15},
                new FemaleAthletesModel() {AthleteName = "Coco Gauff", OnFieldEarning = 6.7,OffFieldEarning = 15},
                new FemaleAthletesModel() {AthleteName = "Eileen Gu",OffFieldEarning=22,OnFieldEarning=0.1},
                new FemaleAthletesModel() {AthleteName = "Iga Swiatek",OnFieldEarning=9.9,OffFieldEarning=14},
            };

            Streams = new ObservableCollection<Stream>();
        }
    }
}
