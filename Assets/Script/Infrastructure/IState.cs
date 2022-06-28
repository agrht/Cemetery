namespace Script.Infrastructure
{
    public interface IState:IExcitableState
    {
        void Enter();
    }
    public interface IPayLoadedIState<TPayLoad>:IExcitableState
    {
        void Enter(TPayLoad payLoad);
    }
    public interface IExcitableState
    {
        void Exit();
    }
    
}