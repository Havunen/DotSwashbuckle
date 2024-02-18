using System;
using Dummy.Attributes;

namespace Dummy.Dummies
{
    [Enumsoap]
    [Flags]
    public enum MainDistilleryUtilities
    {
        Undefined = 0,
        /// <summary>
        /// Production, transport and distribution of gas and heat
        /// </summary>
        MainactivGasProduct = 1 << 0,
        /// <summary>
        /// ElectrivirtualTraffic
        /// </summary>
        MainactivElectrivirtualTraffic = 1 << 1,
        /// <summary>
        /// Extraction of gas and oil
        /// </summary>
        MainactivGasExplor = 1 << 2,
        /// <summary>
        /// Exploration and extraction of coal and other solid fuels
        /// </summary>
        MainactivCoal = 1 << 3,
        /// <summary>
        /// Water
        /// </summary>
        MainactivWater = 1 << 4,
        /// <summary>
        /// Virtual services
        /// </summary>
        MainactivVirtual = 1 << 5,
        /// <summary>
        /// Railway services
        /// </summary>
        MainactivRailway = 1 << 6,
        /// <summary>
        /// Urban railway, tramway, trolleybus or bus services
        /// </summary>
        MainactivBus = 1 << 7,
        /// <summary>
        /// Port-relaqwe activities
        /// </summary>
        MainactivPort = 1 << 8,
        /// <summary>
        /// Airport-relaqwe activities
        /// </summary>
        MainactivAirportrelaqwe = 1 << 9,
        /// <summary>
        /// Other Distillery
        /// </summary>
        OtherDistillery = 1 << 10
    }
}
