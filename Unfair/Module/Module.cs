using JustPlay.Localization;
using UnityEngine;
using UnityEngine.Localization;

namespace Unfair.Module
{
    public enum Category
    {
        Player,
        Movement,
        Combat,
        Visuals,
        Misc
    }
    
    public class Module
    {
        public string Name;
        public string Description;
        public bool Enabled;
        public Category Category;
        public KeyCode Key;
        
        
        // Constructor
        public Module(string name, string description, Category category, KeyCode key)
        {
            Name = name;
            Description = description;
            Category = category;
            Key = key;
        }
        
        public virtual void OnStart() {}
        
        public virtual void OnEnable() {}
        
        public virtual void OnDisable() {}
        
        public virtual void OnUpdate() {}
        
        public virtual void OnGUI() {}

        public void Toggle()
        {
            try
            {
                
                Enabled = !Enabled;
                if (Enabled)
                    OnEnable();
                else
                    OnDisable();
            }
            catch (System.Exception e)
            {
                Debug.Log(e);
            }
            
        }
    }
}