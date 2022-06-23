using System.Runtime.CompilerServices;

namespace Script.Infrastructure
{
    public interface IState:IExitableState
    {
        void Enter();
    }

    public interface IExitableState
    {
        void Exit(object _curtain);
    }
    public interface TPayloadedIState<TPayLoad>:IExitableState
    {
        void Enter(TPayLoad payLoad);
    }
}