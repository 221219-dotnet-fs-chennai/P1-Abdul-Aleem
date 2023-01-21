using System;
using System.Xml.Linq;
using Serilog;
namespace datahandle
{
    public class Logging
    {
        public Logging()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(@"/Users/abdulaleem/Documents/logg.txt").CreateLogger();
            //Log.Information("Program sta");
        }

        public void InformationWriter(string q)
        {
            Log.Information(q);
        }

        public void ErrorWriter(Exception q)
        {
            Log.Information("*****************************************ERROR***********************************************************");
            Log.Information("");
            Log.Error(Convert.ToString(q));
            Log.Information("");
            Log.Information("*********************************************************************************************************");

        }
    }
}

