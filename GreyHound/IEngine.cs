using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    interface IEngine
    {
        public string getEngine();

        public int getspeed();
    }

    class SpeedEngine : IEngine
    {
        public string getEngine()
        {
            return "get speed engine";
        }

        public int getspeed()
        {
            return 20;
        }
    }

    class LightEngine : IEngine
    {
        public string getEngine()
        {
            return "get light engine ";
        }

        public int getspeed()
        {
            return 5;
        }
    }
}
