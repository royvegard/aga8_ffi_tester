using System.Runtime.InteropServices;

namespace Aga8Tester
{
    internal class NativeMethods
    {
        // Detail
        [DllImport("aga8", EntryPoint = "aga8_new")]
        internal static extern DetailHandle Aga8New();

        [DllImport("aga8", EntryPoint = "aga8_free")]
        internal static extern void Aga8Free(IntPtr aga8);

        [DllImport("aga8", EntryPoint = "aga8_set_composition")]
        internal static extern void Aga8SetComposition(DetailHandle aga8, ref Composition composition, ref CompositionError err);

        [DllImport("aga8", EntryPoint = "aga8_set_pressure")]
        internal static extern void Aga8SetPressure(DetailHandle aga8, double pressure);

        [DllImport("aga8", EntryPoint = "aga8_get_pressure")]
        internal static extern double Aga8GetPressure(DetailHandle aga8);

        [DllImport("aga8", EntryPoint = "aga8_set_temperature")]
        internal static extern void Aga8SetTemperature(DetailHandle aga8, double temperature);

        [DllImport("aga8", EntryPoint = "aga8_get_temperature")]
        internal static extern double Aga8GetTemperature(DetailHandle aga8);

        [DllImport("aga8", EntryPoint = "aga8_set_density")]
        internal static extern void Aga8SetDensity(DetailHandle aga8, double density);

        [DllImport("aga8", EntryPoint = "aga8_get_density")]
        internal static extern double Aga8GetDensity(DetailHandle aga8);

        [DllImport("aga8", EntryPoint = "aga8_get_properties")]
        internal static extern Properties Aga8GetProperties(DetailHandle aga8);

        [DllImport("aga8", EntryPoint = "aga8_calculate_pressure")]
        internal static extern void Aga8CalculatePressure(DetailHandle aga8);

        [DllImport("aga8", EntryPoint = "aga8_calculate_density")]
        internal static extern void Aga8CalculateDensity(DetailHandle aga8);

        [DllImport("aga8", EntryPoint = "aga8_calculate_properties")]
        internal static extern void Aga8CalculateProperties(DetailHandle aga8);

        // Gerg 2008
        [DllImport("aga8", EntryPoint = "gerg_new")]
        internal static extern GergHandle GergNew();

        [DllImport("aga8", EntryPoint = "gerg_free")]
        internal static extern void GergFree(IntPtr gerg);

        [DllImport("aga8", EntryPoint = "gerg_set_composition")]
        internal static extern void GergSetComposition(GergHandle gerg, ref Composition composition, ref CompositionError err);

        [DllImport("aga8", EntryPoint = "gerg_set_pressure")]
        internal static extern void GergSetPressure(GergHandle gerg, double pressure);

        [DllImport("aga8", EntryPoint = "gerg_get_pressure")]
        internal static extern double GergGetPressure(GergHandle gerg);

        [DllImport("aga8", EntryPoint = "gerg_set_temperature")]
        internal static extern void GergSetTemperature(GergHandle gerg, double temperature);

        [DllImport("aga8", EntryPoint = "gerg_get_temperature")]
        internal static extern double GergGetTemperature(GergHandle gerg);

        [DllImport("aga8", EntryPoint = "gerg_set_density")]
        internal static extern void GergSetDensity(GergHandle gerg, double density);

        [DllImport("aga8", EntryPoint = "gerg_get_density")]
        internal static extern double GergGetDensity(GergHandle gerg);

        [DllImport("aga8", EntryPoint = "gerg_get_properties")]
        internal static extern Properties GergGetProperties(GergHandle gerg);

        [DllImport("aga8", EntryPoint = "gerg_calculate_pressure")]
        internal static extern void GergCalculatePressure(GergHandle gerg);

        [DllImport("aga8", EntryPoint = "gerg_calculate_density")]
        internal static extern void GergCalculateDensity(GergHandle gerg);

        [DllImport("aga8", EntryPoint = "gerg_calculate_properties")]
        internal static extern void GergCalculateProperties(GergHandle gerg);
    }
}
