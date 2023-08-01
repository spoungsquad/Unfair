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

        private unsafe void OnGUI()
        {
            GUI.Label(new Rect(5, 5, 1000, 20), "Hello, world!");
            GUI.Label(new Rect(5, 25, 1000, 20), "123abc");
            GUI.Label(new Rect(5, 85, 1000, 20), "sillied");
			
            MethodInfo method = typeof(PlayerHealth).GetMethod("Die", BindingFlags.Public | BindingFlags.Instance);
			if (method == null) return;
			
			IntPtr ptr = method.MethodHandle.Value;
			Memory.WriteByte(ptr, 0xc3);
			Memory.WriteByte(ptr + 1, 0x90);
			Memory.WriteByte(ptr + 2, 0x90);
			Memory.WriteByte(ptr + 3, 0x90);
			GUI.Label(new Rect(5, 45, 1000, 20), ptr.ToString("X"));
        }
    }
}