using Microsoft.Maui.Graphics.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighestPaidFemaleAthletes
{
    public class FemaleAthletesModel
    {
        public string AthleteName { get; set; } = string.Empty;

        public double OnFieldEarning { get; set; }

        public double OffFieldEarning { get; set; }

        public string Country { get; set; } = string.Empty;
    }
}
