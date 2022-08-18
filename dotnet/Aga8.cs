using System.Runtime.InteropServices;

namespace Aga8Tester
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Properties
    {
        public double d;
        public double mm;
        public double z;
        public double dp_dd;
        public double d2p_dd2;
        public double dp_dt;
        public double u;
        public double h;
        public double s;
        public double cv;
        public double cp;
        public double w;
        public double g;
        public double jt;
        public double kappa;
    }
 
    [StructLayout(LayoutKind.Sequential)]
    public struct Composition
    {
        public double methane;
        public double nitrogen;
        public double carbon_dioxide;
        public double ethane;
        public double propane;
        public double isobutane;
        public double n_butane;
        public double isopentane;
        public double n_pentane;
        public double hexane;
        public double heptane;
        public double octane;
        public double nonane;
        public double decane;
        public double hydrogen;
        public double oxygen;
        public double carbon_monoxide;
        public double water;
        public double hydrogen_sulfide;
        public double helium;
        public double argon;
    }

    public enum CompositionError : int
    {
        Ok = 0,
        Empty = 1,
        BadSum = 2
    }
    internal class DetailHandle : SafeHandle
    {
        public DetailHandle() : base(IntPtr.Zero, true) { }

        public override bool IsInvalid
        {
            get { return false; }
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.Aga8Free(handle);
            return true;
        }
    }

    public class Detail : IDisposable
    {
        private readonly DetailHandle detail;
        private bool disposed = false;

        public Detail()
        {
            detail = NativeMethods.Aga8New();
        }

        ~Detail()
        {
            Dispose(false);
        }

        public void SetComposition(ref Composition composition)
        {
            NativeMethods.Aga8SetComposition(detail, ref composition);
        }

        public void SetPressure(double pressure)
        {
            NativeMethods.Aga8SetPressure(detail, pressure);
        }

        public double GetPressure()
        {
            return NativeMethods.Aga8GetPressure(detail);
        }

        public void SetTemperature(double temperature)
        {
            NativeMethods.Aga8SetTemperature(detail, temperature);
        }

        public double GetTemperature()
        {
            return NativeMethods.Aga8GetTemperature(detail);
        }

        public void SetDensity(double density)
        {
            NativeMethods.Aga8SetDensity(detail, density);
        }

        public double GetDensity()
        {
            return NativeMethods.Aga8GetDensity(detail);
        }

        public void CalculatePressure()
        {
            NativeMethods.Aga8CalculatePressure(detail);
        }

        public void CalculateDensity()
        {
            NativeMethods.Aga8CalculateDensity(detail);
        }

        public void CalculateProperties()
        {
            NativeMethods.Aga8CalculateProperties(detail);
        }

        public Properties GetProperties()
        {
            return NativeMethods.Aga8GetProperties(detail);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            
            if (disposing)
            {
                // free managed objects
            }

            detail.Close();
            disposed = true;
        }
    }

    internal class GergHandle : SafeHandle
    {
        public GergHandle() : base(IntPtr.Zero, true) { }

        public override bool IsInvalid
        {
            get { return false; }
        }

        protected override bool ReleaseHandle()
        {
            NativeMethods.GergFree(handle);
            return true;
        }
    }

    public class Gerg : IDisposable
    {
        private readonly GergHandle gerg;
        private bool disposed = false;

        public Gerg()
        {
            gerg = NativeMethods.GergNew();
        }

        ~Gerg()
        {
            Dispose(false);
        }

        public void SetComposition(ref Composition composition, ref CompositionError err)
        {
            NativeMethods.GergSetComposition(gerg, ref composition, ref err);
        }

        public void SetPressure(double pressure)
        {
            NativeMethods.GergSetPressure(gerg, pressure);
        }

        public double GetPressure()
        {
            return NativeMethods.GergGetPressure(gerg);
        }

        public void SetTemperature(double temperature)
        {
            NativeMethods.GergSetTemperature(gerg, temperature);
        }

        public double GetTemperature()
        {
            return NativeMethods.GergGetTemperature(gerg);
        }

        public void SetDensity(double density)
        {
            NativeMethods.GergSetDensity(gerg, density);
        }

        public double GetDensity()
        {
            return NativeMethods.GergGetDensity(gerg);
        }

        public void CalculatePressure()
        {
            NativeMethods.GergCalculatePressure(gerg);
        }

        public void CalculateDensity()
        {
            NativeMethods.GergCalculateDensity(gerg);
        }

        public void CalculateProperties()
        {
            NativeMethods.GergCalculateProperties(gerg);
        }

        public Properties GetProperties()
        {
            return NativeMethods.GergGetProperties(gerg);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            
            if (disposing)
            {
                // free managed objects
            }

            gerg.Close();
            disposed = true;
        }
    }
}