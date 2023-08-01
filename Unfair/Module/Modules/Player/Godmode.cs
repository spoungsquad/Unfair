using System;
using System.Reflection;
using Rewired.Utils;
using Unfair.Util;
using UnityEngine;

namespace Unfair.Module.Modules.Player
{
    public class Godmode : Module
    {
        private byte[] _originalBytes = new byte[4];
        private readonly byte[] _newBytes = {0xc3, 0x90, 0x90, 0x90};
        public MethodInfo Method = typeof(PlayerHealth).GetMethod("Die", BindingFlags.Public | BindingFlags.Instance);
        
        public Godmode() : base("Godmode", "Makes you invincible", Category.Player, KeyCode.F8)
        {
        }
        
        public override void OnEnable()
        {
            Method = typeof(PlayerHealth).GetMethod("Die", BindingFlags.Public | BindingFlags.Instance);
            IntPtr ptr = Method.MethodHandle.Value;
            _originalBytes = Memory.ReadBytes(ptr, 4);
            Memory.WriteBytes(ptr, _newBytes);
        }
        
        public override void OnDisable()
        {
            Method = typeof(PlayerHealth).GetMethod("Die", BindingFlags.Public | BindingFlags.Instance);
            PlayerController.LHFJFKJJKCG.GetProp<PlayerHealth>("_health").SetProp("KHNLDDFGFGK", 100);
            IntPtr ptr = Method.MethodHandle.Value;
            Memory.WriteBytes(ptr, _originalBytes);
        }
    }
}