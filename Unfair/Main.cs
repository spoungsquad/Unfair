using Unfair.Util;
using UnityEngine;

namespace Unfair
{
    public class Main : MonoBehaviour
    {
        private void Start()
        {
            DebugConsole.Write("Hello, world!");
        }

        private void Update()
        {

        }

        private void OnGUI()
        {
            GUI.Label(new Rect(5, 5, 100, 20), "Unfair sucks");
        }
    }
}