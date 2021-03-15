using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModSettings;

namespace WeaponCrosshair
{
    internal class WeaponCrosshairSettings : JsonModSettings
    {
        [Name("Stone crosshair")]
        [Description("Default value is false")]
        public bool stoneCrosshair = false;

        [Name("Rifle crosshair")]
        [Description("Default value is false")]
        public bool rifleCrosshair = false;

        [Name("Bow crosshair")]
        [Description("Default value is false")]
        public bool bowCrosshair = false;
    }
    internal class Settings
    {
        internal static WeaponCrosshairSettings options;
        internal static void OnLoad()
        {
            options = new WeaponCrosshairSettings();
            options.AddToModSettings("Weapon Crosshair");
        }
    }
}
