namespace Crip.Samples.Services
{
    using Crip.Samples.Data;

    /// <summary>
    /// Application service base implementation contract.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Gets or sets database context instance.
        /// </summary>
        IDatabaseContext Context { get; set; }
    }
}
