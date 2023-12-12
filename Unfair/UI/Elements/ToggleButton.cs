namespace Unfair.UI.Elements
{
    public class ToggleButton : Button
    {
        public bool IsToggled;
        
        public override void Draw()
        {
            if (IsPressed)
                IsToggled = !IsToggled;
            
            base.Draw();
        }
    }
}