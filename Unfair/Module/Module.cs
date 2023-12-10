using UnityEngine;

namespace Unfair.Module
{
    public enum Category
    {
        Player,
        Movement,
        Combat,
        Visuals,
        Building,
        Misc,
        None
    }

    public class Module
    {
        public Category Category;
        public string Description;
        public bool Enabled;
        public KeyCode Key;
        public string Name;
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