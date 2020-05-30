namespace RR.Helpers.Models
{

    /// <summary>
    /// Result of age separated by fields years, months and days (not acuu
    /// </summary>
    public struct AgeResult
    {

        /// <summary>
        /// Create a new instance of the object
        /// </summary>
        /// <param name="years">Years of life</param>
        /// <param name="months">Months of life</param>
        /// <param name="days">Days of life</param>
        public AgeResult(int years, int months, int days) : this()
        {
            Years = years;
            Months = months;
            Days = days;
        }

        /// <summary>
        /// Years of life
        /// </summary>
        public int Years { get; internal set; }

        /// <summary>
        /// Months of life
        /// </summary>
        public int Months { get; internal set; }

        /// <summary>
        /// Days of life
        /// </summary>
        public int Days { get; internal set; }

    }

}
