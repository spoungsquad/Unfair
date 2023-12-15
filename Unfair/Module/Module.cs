using System.Collections.Generic;
using Unfair.Config;
using UnityEngine;

namespace Unfair.Module
{
    public enum Category
    {
        Building,
        Combat,
        Movement,
        Player,
        Visuals,
        Misc
    }

    public class Module
    {
        public string Name;
        public string Description;
        public Category Category;
        
        public bool Enabled;
        public KeyCode Key;
        public List<SettingBase> Settings = new List<SettingBase>();
        
        private const string _randomString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        // Constructor
        public Module(string name, string description, Category category, KeyCode key)
        {
            Name = name;
            Description = description;
            Category = category;
            Key = key;
        }

        public virtual void OnDisable()
        { }

        public virtual void OnEnable()
        { }

        public virtual void OnGUI()
        { }

        public virtual void OnStart()
        { }

        public virtual void OnUpdate()
        { }

        public string RandomString(int length, bool onlyDigits = false)
        {
            if (onlyDigits)
            {
                return Random.Range(0, length).ToString();
            }

            string str = "";
            for (int i = 0; i < length; i++)
            {
                str += _randomString[Random.Range(0, _randomString.Length)];
            }
            return str;
        }

        public void Toggle()
        {
            Enabled = !Enabled;
            if (Enabled)
                OnEnable();
            else
                OnDisable();
        }
    }
}