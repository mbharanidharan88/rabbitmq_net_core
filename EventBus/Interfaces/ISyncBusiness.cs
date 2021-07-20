using EventBus.Models;

namespace EventBus
{
    public interface ISyncBusiness
    {
        void SyncBusiness(BusinessEventModel business);
    }
}