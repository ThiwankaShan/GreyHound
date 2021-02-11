using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHoundLibrary
{
    public interface IEngine
    {
        public string getEngine();

        public int getspeed();
    }

    public class SpeedEngine : IEngine
    {
        public string getEngine()
        {
            return "get speed engine";
        }

        public int getspeed()
        {
            return 1;
        }
    }

    public class LightEngine : IEngine
    {
        public string getEngine()
        {
            return "get light engine ";
        }

        public int getspeed()
        {
            return 1;
        }
    }
}
