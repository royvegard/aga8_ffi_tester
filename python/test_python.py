#!/usr/bin/env python3

import ctypes
from ctypes import c_double, c_uint32, Structure, POINTER

class Gerg2008S(Structure):
    pass

class DetailS(Structure):
    pass

class Composition(Structure):
    _fields_ = [("methane", c_double),
                ("nitrogen", c_double),
                ("carbon_dioxide", c_double),
                ("ethane", c_double),
                ("propane", c_double),
                ("isobutane", c_double),
                ("n_butane", c_double),
                ("isopentane", c_double),
                ("n_pentane", c_double),
                ("hexane", c_double),
                ("heptane", c_double),
                ("octane", c_double),
                ("nonane", c_double),
                ("decane", c_double),
                ("hydrogen", c_double),
                ("oxygen", c_double),
                ("carbon_monoxide", c_double),
                ("water", c_double),
                ("hydrogen_sulfide", c_double),
                ("helium", c_double),
                ("argon", c_double)]

class Properties(Structure):
    _fields_ = [("d", c_double),
                ("mm", c_double),
                ("z", c_double),
                ("dp_dd", c_double),
                ("d2p_dd2", c_double),
                ("dp_dt", c_double),
                ("u", c_double),
                ("h", c_double),
                ("s", c_double),
                ("cv", c_double),
                ("cp", c_double),
                ("w", c_double),
                ("g", c_double),
                ("jt", c_double),
                ("kappa", c_double)]

path = 'aga8/target/debug/'
prefix = 'lib'
extension = '.so'
lib = ctypes.cdll.LoadLibrary(path + prefix + "aga8" + extension)

lib.gerg_new.restype = POINTER(Gerg2008S)
lib.gerg_free.argtypes = (POINTER(Gerg2008S),)
lib.gerg_set_composition.argtypes = (POINTER(Gerg2008S), POINTER(Composition), POINTER(c_uint32))
lib.gerg_set_pressure.argtypes = (POINTER(Gerg2008S), c_double)
lib.gerg_set_temperature.argtypes = (POINTER(Gerg2008S), c_double)
lib.gerg_calculate_density.argtypes = (POINTER(Gerg2008S),)
lib.gerg_calculate_properties.argtypes = (POINTER(Gerg2008S),)
lib.gerg_get_properties.argtypes = (POINTER(Gerg2008S),)
lib.gerg_get_properties.restype = Properties

lib.aga8_new.restype = POINTER(DetailS)
lib.aga8_free.argtypes = (POINTER(DetailS),)
lib.aga8_set_composition.argtypes = (POINTER(DetailS), POINTER(Composition), POINTER(c_uint32))
lib.aga8_set_pressure.argtypes = (POINTER(DetailS), c_double)
lib.aga8_set_temperature.argtypes = (POINTER(DetailS), c_double)
lib.aga8_calculate_density.argtypes = (POINTER(DetailS),)
lib.aga8_calculate_properties.argtypes = (POINTER(DetailS),)
lib.aga8_get_properties.argtypes = (POINTER(DetailS),)
lib.aga8_get_properties.restype = Properties

class Gerg2008:
    def __init__(self):
        self.obj = lib.gerg_new()

    def __enter__(self):
        return self

    def __exit__(self, exc_type, exc_value, traceback):
        lib.gerg_free(self.obj)

    def set_composition(self, comp, err):
        lib.gerg_set_composition(self.obj, comp, err)

    def set_pressure(self, pressure):
        lib.gerg_set_pressure(self.obj, pressure)

    def set_temperature(self, temperature):
        lib.gerg_set_temperature(self.obj, temperature)

    def calculate_density(self):
        lib.gerg_calculate_density(self.obj)

    def calculate_properties(self):
        lib.gerg_calculate_properties(self.obj)

    def get_properties(self):
        return lib.gerg_get_properties(self.obj)

class Detail:
    def __init__(self):
        self.obj = lib.aga8_new()

    def __enter__(self):
        return self

    def __exit__(self, exc_type, exc_value, traceback):
        lib.aga8_free(self.obj)

    def set_composition(self, comp, err):
        lib.aga8_set_composition(self.obj, comp, err)

    def set_pressure(self, pressure):
        lib.aga8_set_pressure(self.obj, pressure)

    def set_temperature(self, temperature):
        lib.aga8_set_temperature(self.obj, temperature)

    def calculate_density(self):
        lib.aga8_calculate_density(self.obj)

    def calculate_properties(self):
        lib.aga8_calculate_properties(self.obj)

    def get_properties(self):
        return lib.aga8_get_properties(self.obj)

with Gerg2008() as gerg_test:
    comp = Composition(methane = 0.77824,
                       nitrogen = 0.02,
                       carbon_dioxide = 0.06,
                       ethane = 0.08,
                       propane = 0.03,
                       isobutane = 0.0015,
                       n_butane = 0.003,
                       isopentane = 0.0005,
                       n_pentane = 0.00165,
                       hexane = 0.00215,
                       heptane = 0.00088,
                       octane = 0.00024,
                       nonane = 0.00015,
                       decane = 0.00009,
                       hydrogen = 0.004,
                       oxygen = 0.005,
                       carbon_monoxide = 0.002,
                       water = 0.0001,
                       hydrogen_sulfide = 0.0025,
                       helium = 0.007,
                       argon = 0.001)

    err = c_uint32(0)
    gerg_test.set_composition(comp, err)
    assert err.value == 0
    gerg_test.set_pressure(50000.0)
    gerg_test.set_temperature(400.0)
    gerg_test.calculate_density()
    gerg_test.calculate_properties()
    r = gerg_test.get_properties()

    assert abs(r.d - 12.79828626082062) < 1.0e-10
    assert abs(r.mm - 20.5427445016) < 1.0e-10
    assert abs(r.z - 1.174690666383717) < 1.0e-10
    assert abs(r.dp_dd - 7000.694030193327) < 1.0e-10
    assert abs(r.d2p_dd2 - 1129.526655214841) < 1.0e-10
    assert abs(r.dp_dt - 235.9832292593096) < 1.0e-10
    assert abs(r.u - -2746.49290121253) < 1.0e-10
    assert abs(r.h - 1160.280160510973) < 1.0e-10
    assert abs(r.s - -38.57590392409089) < 1.0e-10
    assert abs(r.cv - 39.02948218156372) < 1.0e-10
    assert abs(r.cp - 58.45522051000366) < 1.0e-10
    assert abs(r.w - 714.4248840596024) < 1.0e-10
    assert abs(r.g - 16590.64173014733) < 1.0e-10
    assert abs(r.jt - 7.155629581480913E-5) < 1.0e-10
    assert abs(r.kappa - 2.683820255058032) < 1.0e-10

with Detail() as aga8_test:
    comp = Composition(methane = 0.77824,
                       nitrogen = 0.02,
                       carbon_dioxide = 0.06,
                       ethane = 0.08,
                       propane = 0.03,
                       isobutane = 0.0015,
                       n_butane = 0.003,
                       isopentane = 0.0005,
                       n_pentane = 0.00165,
                       hexane = 0.00215,
                       heptane = 0.00088,
                       octane = 0.00024,
                       nonane = 0.00015,
                       decane = 0.00009,
                       hydrogen = 0.004,
                       oxygen = 0.005,
                       carbon_monoxide = 0.002,
                       water = 0.0001,
                       hydrogen_sulfide = 0.0025,
                       helium = 0.007,
                       argon = 0.001)

    err = c_uint32(0)
    aga8_test.set_composition(comp, err)
    assert err.value == 0
    aga8_test.set_pressure(50000.0)
    aga8_test.set_temperature(400.0)
    aga8_test.calculate_density()
    aga8_test.calculate_properties()
    r = aga8_test.get_properties()

    assert abs(r.d - 12.807_924_036_488_01) < 1.0e-10
    assert abs(r.mm - 20.543_330_51) < 1.0e-10
    assert abs(r.z - 1.173_801_364_147_326) < 1.0e-10
    assert abs(r.dp_dd - 6_971.387_690_924_09) < 1.0e-10
    assert abs(r.d2p_dd2 - 1_118.803_636_639_52) < 1.0e-10
    assert abs(r.dp_dt - 235.664_149_306_821_2) < 1.0e-10
    assert abs(r.u - -2_739.134_175_817_231) < 1.0e-10
    assert abs(r.h - 1_164.699_096_269_404) < 1.0e-10
    assert abs(r.s - -38.548_826_846_771_11) < 1.0e-10
    assert abs(r.cv - 39.120_761_544_303_32) < 1.0e-10
    assert abs(r.cp - 58.546_176_723_806_67) < 1.0e-10
    assert abs(r.w - 712.639_368_405_790_3) < 1.0e-10
    assert abs(r.g - 16_584.229_834_977_85) < 1.0e-10
    assert abs(r.jt - 7.432_969_304_794_577E-5) < 1.0e-10
    assert abs(r.kappa - 2.672_509_225_184_606) < 1.0e-10

print("\033[0;32mSuccess!\033[0m")
