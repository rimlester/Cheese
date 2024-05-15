namespace Cheese.Server
{
    /// <summary>
    /// Cheese definition. To save time, this will serve as both an entity definition and DTO. 
    /// </summary>
    public class Cheese
    {

        /// <summary>
        /// Id of the cheese
        /// In this case will be used as the synthetic db PKey and Id for API calls
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// per kilo, aud
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// URL of the cheese image - why reinvent the (cheese) wheel?
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Cheese Description. Copied from wikipedia since this is non commerical
        /// </summary>
        public string Description { get; set; }
    }
}
