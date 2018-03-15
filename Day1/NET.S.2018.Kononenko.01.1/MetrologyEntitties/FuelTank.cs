using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MetrologyEntitties
{
    /// <summary>
    /// Class describing fueltank
    /// </summary>
    public class FuelTank
    {
        /// <summary>
        /// Gets or sets type of tank
        /// </summary>
        public string TypeTank { get; set; }

        /// <summary>
        /// Gets or sets volume of the tank
        /// </summary>
        public int AllScopeTank { get; set; }

        public FuelTank Get()
        {
            return new FuelTank { TypeTank = "RGDP - 50", AllScopeTank = 50 };
        }
    }
}
