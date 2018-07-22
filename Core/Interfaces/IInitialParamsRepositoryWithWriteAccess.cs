
namespace Core.Interfaces
{
    public interface IInitialParamsRepositoryWithWriteAccess : IInitialParamsRepository
    {
        void Set<T>(T parameters);
    }
}
