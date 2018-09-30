using UnityEngine;
using System;
using System.Collections;

namespace ExtensionMethods
{
    public static class MonoBehaviourExtensions
    {
        /// <summary>
        /// Executes a method after a given seconds
        /// </summary>
        /// <param name="script">The MonoBehaviour which executes the Coroutine</param>
        /// <param name="callback">The method, anonymous function or lambda that will be executed</param>
        /// <param name="seconds">The seconds that will be waited to execute the callback</param>
        public static void WaitAndExecute(this MonoBehaviour script, Action callback, float seconds)
        {
            script.StartCoroutine(Execute(callback, seconds));
        }

        private static IEnumerator Execute(Action callback, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            callback();
        }

        /// <summary>
        /// Executes the callback when the condition returns true
        /// </summary>
        /// <param name="script">The MonoBehaviour which executes the Coroutine</param>
        /// <param name="callback">The method, anonymous function or lambda that will be executed</param>
        /// <param name="condition">The function that checks the condition</param>
        public static void WaitUntilAndExecute(this MonoBehaviour script, Action callback, Func<bool> condition)
        {
            script.StartCoroutine(Execute(callback, condition));
        }

        private static IEnumerator Execute(Action callback, Func<bool> condition)
        {
            yield return new WaitUntil(condition);
            callback();
        }

        /// <summary>
        /// Executes the callback the next frame this function is called
        /// </summary>
        /// <param name="script">The MonoBehaviour which executes the Coroutine</param>
        /// <param name="callback">The method, anonymous function or lambda that will be executed</param>
        public static void ExecuteNextFrame(this MonoBehaviour script, Action callback)
        {
            script.StartCoroutine(Execute(callback));
        }

        private static IEnumerator Execute(Action callback)
        {
            yield return null;
            callback();
        }
    }
}
