fn main() {
    println!("Hello, world!");
}

#[cfg(test)]
mod tests {
    use aga8::composition::*;
    use aga8::gerg2008::Gerg2008;

    const COMP_FULL: Composition = Composition {
        methane: 0.778_24,
        nitrogen: 0.02,
        carbon_dioxide: 0.06,
        ethane: 0.08,
        propane: 0.03,
        isobutane: 0.001_5,
        n_butane: 0.003,
        isopentane: 0.000_5,
        n_pentane: 0.001_65,
        hexane: 0.002_15,
        heptane: 0.000_88,
        octane: 0.000_24,
        nonane: 0.000_15,
        decane: 0.000_09,
        hydrogen: 0.004,
        oxygen: 0.005,
        carbon_monoxide: 0.002,
        water: 0.000_1,
        hydrogen_sulfide: 0.002_5,
        helium: 0.007,
        argon: 0.001,
    };

    #[test]
    fn gerg_demo_example() {
        let mut gerg_test: Gerg2008 = Gerg2008::new();

        gerg_test.set_composition(&COMP_FULL).unwrap();

        gerg_test.molar_mass();

        gerg_test.t = 400.0;
        gerg_test.p = 50000.0;
        gerg_test.d = 6.36570;
        gerg_test.z = 0.0;

        gerg_test.density(0);
        gerg_test.properties();

        assert!(f64::abs(gerg_test.d - 12.798_286_260_820_62) < 1.0e-10);
        assert!(f64::abs(gerg_test.mm - 20.542_744_501_6) < 1.0e-10);
        assert!(f64::abs(gerg_test.p - 50_000.0) < 1.0e-10);
        assert!(f64::abs(gerg_test.z - 1.174_690_666_383_717) < 1.0e-10);
        assert!(f64::abs(gerg_test.dp_dd - 7_000.694_030_193_327) < 1.0e-10);
        assert!(f64::abs(gerg_test.d2p_dd2 - 1_129.526_655_214_841) < 1.0e-10);
        assert!(f64::abs(gerg_test.dp_dt - 235.983_229_259_309_6) < 1.0e-10);
        assert!(f64::abs(gerg_test.u - -2_746.492_901_212_53) < 1.0e-10);
        assert!(f64::abs(gerg_test.h - 1_160.280_160_510_973) < 1.0e-10);
        assert!(f64::abs(gerg_test.s - -38.575_903_924_090_89) < 1.0e-10);
        assert!(f64::abs(gerg_test.cv - 39.029_482_181_563_72) < 1.0e-10);
        assert!(f64::abs(gerg_test.cp - 58.455_220_510_003_66) < 1.0e-10);
        assert!(f64::abs(gerg_test.w - 714.424_884_059_602_4) < 1.0e-10);
        assert!(f64::abs(gerg_test.g - 16_590.641_730_147_33) < 1.0e-10);
        assert!(f64::abs(gerg_test.jt - 7.155_629_581_480_913E-5) < 1.0e-10);
        assert!(f64::abs(gerg_test.kappa - 2.683_820_255_058_032) < 1.0e-10);
    }
}
