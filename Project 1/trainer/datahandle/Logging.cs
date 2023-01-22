using System;
using System.Xml.Linq;
using Serilog;
namespace datahandle
{
    /// <summary>
    /// Used for Logging information and errors.
    /// </summary>
    public class Logging
    {
        public Logging()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(@"/Users/abdulaleem/Documents/logg.txt").CreateLogger();
            //Log.Information("Program sta");
        }


        /// <summary>
        /// Method used to Log essential information to a file.
        /// Takes string as an parameter.
        /// </summary>
        /// <param name="q"></param>
        public void InformationWriter(string q)
        {
            Log.Information(q);
        }

        /// <summary>
        /// Method used to log errors to a file.
        /// Takes an Exception as an argument.
        /// </summary>
        /// <param name="q"></param>
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

