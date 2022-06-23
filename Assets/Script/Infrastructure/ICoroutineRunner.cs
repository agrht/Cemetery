using UnityEngine;
using System.Collections;

namespace Script.Infrastructure
{
    public interface ICoroutineRunner
    {

        Coroutine startCoroutine(IEnumerator coroutine);
    }
}