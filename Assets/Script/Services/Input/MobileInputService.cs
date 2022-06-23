using UnityEngine;

namespace Script.Services.Input
{
    public class MobileInputService : InputServices
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}