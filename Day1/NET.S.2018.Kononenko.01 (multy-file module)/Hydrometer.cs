namespace MetrologyEntitties
{
    /// <summary>
    /// Class describing hydrometer
    /// </summary>
    public class Hydrometer
    {
        /// <summary>
        /// Gets or sets model
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets accuracy class
        /// </summary>
        public int ClassAccuracy { get; set; }

        public Hydrometer Get()
        {
            return new Hydrometer { Model = "RG - 10", ClassAccuracy = 1 };
        }
    }
}