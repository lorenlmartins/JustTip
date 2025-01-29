using JustTip.Models;

namespace JustTip.Strategies
{
    // Interface for tip distribution strategies
    public interface ITipDistributionStrategy
    {
        // Method to distribute tips among employees based on a specific strategy
        void DistributeTips(Business business, decimal totalTips);
    }
}
