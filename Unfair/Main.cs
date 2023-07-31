using System;
using System.Reflection;
using System.Runtime.InteropServices;
using HarmonyLib;
using Invector.CharacterController;
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
            _harmony = new Harmony("unfair");
            _harmony.PatchAll();
        }

        private void Update()
        {

        }

        private void OnGUI()
        {
            GUI.Label(new Rect(5, 5, 1000, 20), "Hello, world!");
            GUI.Label(new Rect(5, 25, 1000, 20), "123abc");
            GUI.Label(new Rect(5, 85, 1000, 20), "sillied");
            IntPtr p = Marshal.GetFunctionPointerForDelegate(typeof(PlayerHealth).GetMethod("Die",
                BindingFlags.Instance | BindingFlags.Public));
            GUI.Label(new Rect(5, 105, 1000, 20), p.ToString("X"));

        }
    }
}