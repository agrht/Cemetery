using UnityEngine;

namespace Script.Services.Input
{ 
    public interface IInputServices 
    {
    Vector2 Axis {get;}
    bool IsAttackButtonUp();      
    }

}
