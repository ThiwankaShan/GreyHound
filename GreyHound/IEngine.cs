using System;
using System.Collections.Generic;
using System.Text;

namespace GreyHound
{
    interface IEngine
    {
        public string getEngine();
        public string startEngine();
    }

    class SpeedEngine : IEngine
    {
        public string getEngine()
        {
            return "get speed engine";
        }

        public string startEngine()
        {
            return "speed 100";
        }
    }

    class LightEngine : IEngine
    {
        public string getEngine()
        {
            return "get light engine ";
        }

        public string startEngine()
        {
            return "speed 50";
        }
    }
}
