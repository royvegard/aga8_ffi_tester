#!/usr/bin/env python3

import ctypes
from ctypes import c_double, c_uint32, Structure, POINTER

class Gerg2008S(Structure):
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
lib.gerg_set_composition.argtypes = (POINTER(Gerg2008S), Composition, c_uint32)
lib.gerg_set_pressure.argtypes = (POINTER(Gerg2008S), c_double)
lib.gerg_set_temperature.argtypes = (POINTER(Gerg2008S), c_double)
lib.gerg_calculate_density.argtypes = (POINTER(Gerg2008S),)
lib.gerg_calculate_properties.argtypes = (POINTER(Gerg2008S),)
lib.gerg_get_properties.argtypes = (POINTER(Gerg2008S),)
lib.gerg_get_properties.restype = Properties

class Gerg2008:
    def __init__(self):
        self.obj = lib.gerg_new()

    def __enter__(self):
        return self

    def __exit__(self, exc_type, exc_value, traceback):
        lib.gerg_free(self.obj)

    def set_composition(self, comp):
        err = 0
        lib.gerg_set_composition(self.obj, comp, err)

    def set_pressure(self, pressure):
        lib.gerg_set_pressure(self.obj, pressure)

    def set_temperature(self, temperature):
        lib.gerg_set_temperature(self.obj, temperature)

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

    print(comp.argon)

    gerg_test.set_composition(comp)
    gerg_test.set_pressure(50000.0)
    gerg_test.set_temperature(400.0)
