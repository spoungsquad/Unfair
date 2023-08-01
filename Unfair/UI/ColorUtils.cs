using System;
using UnityEngine;

namespace Unfair.UI
{
    
public static class ColorUtils
{
    
    public static Color GetRainbow(int speed, int offset)
    {
        float hue = (DateTimeOffset.Now.ToUnixTimeMilliseconds() + (int)(offset)) % speed;
        return Color.HSVToRGB(hue / speed, 1, 1);
    }
    
    public static Color DefaultRainbow(int yOffset, int yTotal, int delayOffset, float sped, float saturation, float value)
    {
        sped *= 1000;
        int speed = (int)sped + delayOffset;
        float hue = (float)(TimeUtils.CurrentMs % speed) + (yTotal - yOffset) * 9;
        while (hue > speed) hue -= speed;
        hue /= speed;
        return Color.HSVToRGB(hue, saturation, value);
    }

    public static Color DefaultRainbow(Vector2 currentPos, Vector2 maxPos, int delayOffset, float sped, float saturation, float value)
    {
        // This method is the same as the one above, but it takes two Vector2s instead of two ints
        // This is used to offset the hue on the X axis AND the Y axis, instead of just the X axis
        // This lets you render a rainbow on a 2D plane all at once and gives you a gradient effect that goes to the bottom right of the screen
        sped = sped * 1000;
        int speed = (int)sped + delayOffset;
        // Offset the hue based on the current X and Y
        float hue = (float)(TimeUtils.CurrentMs % (int)speed) + ((maxPos.y - currentPos.y) * 30) +
                    ((maxPos.x - currentPos.x) * 9);
        while (hue > speed) hue -= speed;
        hue /= speed;
        return Color.HSVToRGB(hue, saturation, value);
    }

    public static Color AlternateRainbow(int yOffset, int yTotal, int delayOffset, float sped, float saturation, float value)
    {
        sped *= 1000;
        int speed = (int)sped + delayOffset;
        float hue = (float)(TimeUtils.CurrentMs % (int)speed) + ((yTotal - yOffset) * 9);
        while (hue > speed) hue -= speed;
        hue /= speed;
        if (hue > 0.5) hue = 0.5F - (hue - 0.5f);
        hue += 0.5f;
        return Color.HSVToRGB(hue, saturation, value);
    }

    public static Color AlternateRainbow(Vector2 currentPos, Vector2 maxPos, int delayOffset, float sped, float saturation, float value)
    {
        sped *= 1000;
        int speed = (int)sped + delayOffset;
        float hue = TimeUtils.CurrentMs % speed + (maxPos.y - currentPos.y) * 30 +
                    (maxPos.x - currentPos.x) * 9;
        while (hue > speed) hue -= speed;
        hue /= speed;
        if (hue > 0.5) hue = 0.5F - (hue - 0.5f);
        hue += 0.5f;
        return Color.HSVToRGB(hue, saturation, value);
    }

    /// <summary>
    /// Converts HSV to RGB.
    /// </summary>
    /// <param name="hsv">The HSV color.</param>
    /// <returns>The RGB color.</returns>
    public static Color HsVtoRgb(Vector3 hsv) => HsVtoRgb(hsv.x, hsv.y, hsv.z);
    /// <summary>
    /// Converts HSV to RGB.
    /// </summary>
    /// <param name="h">The hue.</param>
    /// <param name="s">The saturation.</param>
    /// <param name="v">The value.</param>
    /// <returns>The RGB color.</returns>
    public static Color HsVtoRgb(float h, float s, float v)
    { // Thank you GitHub Copilot, very cool!
        float r = 0.0f;
        float g = 0.0f;
        float b = 0.0f;
        if (s == 0.0f)
        {
            r = v;
            g = v;
            b = v;
        }
        else
        {
            float varH = h * 6.0f;
            if (varH == 6.0f)
            {
                varH = 0.0f;
            }
            int varI = (int)varH;
            float var1 = v * (1.0f - s);
            float var2 = v * (1.0f - s * (varH - varI));
            float var3 = v * (1.0f - s * (1.0f - (varH - varI)));
            if (varI == 0)
            {
                r = v;
                g = var3;
                b = var1;
            }
            else if (varI == 1)
            {
                r = var2;
                g = v;
                b = var1;
            }
            else if (varI == 2)
            {
                r = var1;
                g = v;
                b = var3;
            }
            else if (varI == 3)
            {
                r = var1;
                g = var2;
                b = v;
            }
            else if (varI == 4)
            {
                r = var3;
                g = var1;
                b = v;
            }
            else
            {
                r = v;
                g = var1;
                b = var2;
            }
        }
        return new Color(r, g, b);
    }
    public static Color RgbToHsv(Color rgb) => RgbToHsv(rgb.r, rgb.g, rgb.b);
    /// <summary>
    /// Converts RGB to HSV.
    /// </summary>
    /// <param name="r">The red amount.</param>
    /// <param name="g">The green amount.</param>
    /// <param name="b">The blue amount.</param>
    /// <returns>The HSV color.</returns>
    public static Color RgbToHsv(float r, float g, float b)
    {
        float h = 0.0f;
        float s = 0.0f;
        float v = 0.0f;
        float min = Math.Min(Math.Min(r, g), b);
        float max = Math.Max(Math.Max(r, g), b);
        float delta = max - min;
        v = max;
        if (max != 0.0f)
        {
            s = delta / max;
        }
        else
        {
            s = 0.0f;
            h = -1.0f;
            return new Color(h, s, v);
        }
        if (r == max)
        {
            h = (g - b) / delta;
        }
        else if (g == max)
        {
            h = 2.0f + (b - r) / delta;
        }
        else
        {
            h = 4.0f + (r - g) / delta;
        }
        h *= 60.0f;
        if (h < 0.0f)
        {
            h += 360.0f;
        }
        return new Color(h, s, v);
    }
}

public static class TimeUtils
{
    private static readonly DateTime Jan1St1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    /// <summary>
    /// Gets the current time in milliseconds.
    /// </summary>
    public static long CurrentMs => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
}
}