#include <assert.h>
#include <math.h>
#include <stdio.h>
#include "aga8.h"

int main() {
    Gerg2008 *gerg_test = gerg_new();

    Composition comp;
    comp.methane = 0.77824;
    comp.nitrogen = 0.02;
    comp.carbon_dioxide = 0.06;
    comp.ethane = 0.08;
    comp.propane = 0.03;
    comp.isobutane = 0.0015;
    comp.n_butane = 0.003;
    comp.isopentane = 0.0005;
    comp.n_pentane = 0.00165;
    comp.hexane = 0.00215;
    comp.heptane = 0.00088;
    comp.octane = 0.00024;
    comp.nonane = 0.00015;
    comp.decane = 0.00009;
    comp.hydrogen = 0.004;
    comp.oxygen = 0.005;
    comp.carbon_monoxide = 0.002;
    comp.water = 0.0001;
    comp.hydrogen_sulfide = 0.0025;
    comp.helium = 0.007;
    comp.argon = 0.001;

    CompositionError comp_err = Ok;

    gerg_set_composition(gerg_test, &comp, &comp_err);
    assert(comp_err == Ok);
    gerg_set_pressure(gerg_test, 50000.0);
    gerg_set_temperature(gerg_test, 400.0);

    gerg_calculate_density(gerg_test);
    gerg_calculate_properties(gerg_test);
    Properties results = gerg_get_properties(gerg_test);

    gerg_free(gerg_test);

    assert(fabs(results.d - 12.79828626082062) < 1.0e-10);
    assert(fabs(results.mm - 20.5427445016) < 1.0e-10);
    assert(fabs(results.z - 1.174690666383717) < 1.0e-10);
    assert(fabs(results.dp_dd - 7000.694030193327) < 1.0e-10);
    assert(fabs(results.d2p_dd2 - 1129.526655214841) < 1.0e-10);
    assert(fabs(results.dp_dt - 235.9832292593096) < 1.0e-10);
    assert(fabs(results.u - -2746.49290121253) < 1.0e-10);
    assert(fabs(results.h - 1160.280160510973) < 1.0e-10);
    assert(fabs(results.s - -38.57590392409089) < 1.0e-10);
    assert(fabs(results.cv - 39.02948218156372) < 1.0e-10);
    assert(fabs(results.cp - 58.45522051000366) < 1.0e-10);
    assert(fabs(results.w - 714.4248840596024) < 1.0e-10);
    assert(fabs(results.g - 16590.64173014733) < 1.0e-10);
    assert(fabs(results.jt - 7.155629581480913E-5) < 1.0e-10);
    assert(fabs(results.kappa - 2.683820255058032) < 1.0e-10);

    // Green text for passed tests
    printf("\033[0;32m");
    printf("Success!\n");
    printf("\033[0m");

    return EXIT_SUCCESS;
}