using HarmonyLib;
using Unfair.Util;
using UnityEngine;

namespace Unfair
{
    public class Main : MonoBehaviour
    {
	    private Harmony _harmony;
	    
        private void Start()
        {
            DebugConsole.Write("Hello, world!");

            // patches
            _harmony = new Harmony("Unfair");
            _harmony.PatchAll();
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