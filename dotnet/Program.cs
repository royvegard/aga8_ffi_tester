using System.Diagnostics;

Aga8Tester.Composition COMP_FULL = new Aga8Tester.Composition();
COMP_FULL.methane = 0.778_24;
COMP_FULL.nitrogen = 0.02;
COMP_FULL.carbon_dioxide = 0.06;
COMP_FULL.ethane = 0.08;
COMP_FULL.propane = 0.03;
COMP_FULL.isobutane = 0.001_5;
COMP_FULL.n_butane = 0.003;
COMP_FULL.isopentane = 0.000_5;
COMP_FULL.n_pentane = 0.001_65;
COMP_FULL.hexane = 0.002_15;
COMP_FULL.heptane = 0.000_88;
COMP_FULL.octane = 0.000_24;
COMP_FULL.nonane = 0.000_15;
COMP_FULL.decane = 0.000_09;
COMP_FULL.hydrogen = 0.004;
COMP_FULL.oxygen = 0.005;
COMP_FULL.carbon_monoxide = 0.002;
COMP_FULL.water = 0.000_1;
COMP_FULL.hydrogen_sulfide = 0.002_5;
COMP_FULL.helium = 0.007;
COMP_FULL.argon = 0.001;


using (var aga = new Aga8Tester.Detail())
{
    var comp_err = Aga8Tester.CompositionError.Ok;
    var dens_err = Aga8Tester.DensityError.Ok;
    aga.SetComposition(ref COMP_FULL, ref comp_err);
    Debug.Assert(comp_err == Aga8Tester.CompositionError.Ok);
    aga.SetPressure(50_000.0);
    aga.SetTemperature(400.0);
    aga.CalculateDensity(ref dens_err);
    Debug.Assert(dens_err == Aga8Tester.DensityError.Ok);
    aga.CalculateProperties();

    Aga8Tester.Properties props = aga.GetProperties();

    Debug.Assert(Math.Abs(props.d - 12.807_924_036_488_01) < 1.0e-10);
    Debug.Assert(Math.Abs(props.mm - 20.543_330_51) < 1.0e-10);
    Debug.Assert(Math.Abs(props.z - 1.173_801_364_147_326) < 1.0e-10);
    Debug.Assert(Math.Abs(props.dp_dd - 6_971.387_690_924_09) < 1.0e-10);
    Debug.Assert(Math.Abs(props.d2p_dd2 - 1_118.803_636_639_52) < 1.0e-10);
    Debug.Assert(Math.Abs(props.dp_dt - 235.664_149_306_821_2) < 1.0e-10);
    Debug.Assert(Math.Abs(props.u - -2_739.134_175_817_231) < 1.0e-10);
    Debug.Assert(Math.Abs(props.h - 1_164.699_096_269_404) < 1.0e-10);
    Debug.Assert(Math.Abs(props.s - -38.548_826_846_771_11) < 1.0e-10);
    Debug.Assert(Math.Abs(props.cv - 39.120_761_544_303_32) < 1.0e-10);
    Debug.Assert(Math.Abs(props.cp - 58.546_176_723_806_67) < 1.0e-10);
    Debug.Assert(Math.Abs(props.w - 712.639_368_405_790_3) < 1.0e-10);
    Debug.Assert(Math.Abs(props.g - 16_584.229_834_977_85) < 1.0e-10);
    Debug.Assert(Math.Abs(props.jt - 7.432_969_304_794_577E-5) < 1.0e-10);
    Debug.Assert(Math.Abs(props.kappa - 2.672_509_225_184_606) < 1.0e-10);

}

using (var gerg = new Aga8Tester.Gerg())
{
    var comp_err = Aga8Tester.CompositionError.Ok;
    var dens_err = Aga8Tester.DensityError.Ok;
    gerg.SetComposition(ref COMP_FULL, ref comp_err);
    gerg.SetPressure(50_000.0);
    gerg.SetTemperature(400.0);
    gerg.CalculateDensity(0, ref dens_err);
    gerg.CalculateProperties();

    Aga8Tester.Properties props = gerg.GetProperties();

    Debug.Assert(Math.Abs(props.d - 12.798_286_260_820_62) < 1.0e-10);
    Debug.Assert(Math.Abs(props.mm - 20.542_744_501_6) < 1.0e-10);
    Debug.Assert(Math.Abs(props.z - 1.174_690_666_383_717) < 1.0e-10);
    Debug.Assert(Math.Abs(props.dp_dd - 7_000.694_030_193_327) < 1.0e-10);
    Debug.Assert(Math.Abs(props.d2p_dd2 - 1_129.526_655_214_841) < 1.0e-10);
    Debug.Assert(Math.Abs(props.dp_dt - 235.983_229_259_309_6) < 1.0e-10);
    Debug.Assert(Math.Abs(props.u - -2_746.492_901_212_53) < 1.0e-10);
    Debug.Assert(Math.Abs(props.h - 1_160.280_160_510_973) < 1.0e-10);
    Debug.Assert(Math.Abs(props.s - -38.575_903_924_090_89) < 1.0e-10);
    Debug.Assert(Math.Abs(props.cv - 39.029_482_181_563_72) < 1.0e-10);
    Debug.Assert(Math.Abs(props.cp - 58.455_220_510_003_66) < 1.0e-10);
    Debug.Assert(Math.Abs(props.w - 714.424_884_059_602_4) < 1.0e-10);
    Debug.Assert(Math.Abs(props.g - 16_590.641_730_147_33) < 1.0e-10);
    Debug.Assert(Math.Abs(props.jt - 7.155_629_581_480_913E-5) < 1.0e-10);
    Debug.Assert(Math.Abs(props.kappa - 2.683_820_255_058_032) < 1.0e-10);
}

Console.WriteLine("\x1b[32mSuccess!\x1b[0m");

