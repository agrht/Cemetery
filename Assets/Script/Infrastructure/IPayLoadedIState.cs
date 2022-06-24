namespace Script.Infrastructure
{
    public interface IPayLoadedIState<T>
    {
        void Enter<TPayLoad>();
    }
}