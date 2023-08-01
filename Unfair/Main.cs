using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Invector.CharacterController;
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
            GUI.Label(new Rect(5, 5, 1000, 20), "Hello, world!");
            GUI.Label(new Rect(5, 25, 1000, 20), "123abc");
            GUI.Label(new Rect(5, 85, 1000, 20), "sillied");
			
            var method = typeof(PlayerHealth).GetMethod("Die", BindingFlags.Public | BindingFlags.Instance);
			if (method == null) return;
			
			var ptr = method.MethodHandle.Value;
			GUI.Label(new Rect(5, 45, 1000, 20), ptr.ToString("X"));
        }
    }
}