using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts a normal Color to a dictionary representing Material shades.
        /// </summary>
        /// <param name="color">The base color.</param>
        /// <returns>A dictionary representing shades of the color mixed with white.</returns>
        public static Dictionary<int, Color> ToMaterialColor(this Color color)
        {
            var strengths = new List<double> { 0.05 };
            for (var i = 1; i < 10; i++)
            {
                strengths.Add(0.1 * i);
            }

            var swatch = new Dictionary<int, Color>();
            foreach (var strength in strengths)
            {
                var ds = 0.5 - strength;
                swatch[(int)(strength * 1000)] = Color.FromArgb(
                    color.A,
                    color.R + (int)((ds < 0 ? color.R : (255 - color.R)) * ds),
                    color.G + (int)((ds < 0 ? color.G : (255 - color.G)) * ds),
                    color.B + (int)((ds < 0 ? color.B : (255 - color.B)) * ds)
                );
            }
            return swatch;
        }

        /// <summary>
        /// Shades the color based on the given strength.
        /// </summary>
        /// <param name="color">The color to shade.</param>
        /// <param name="shade">The shade strength (0 to 1000).</param>
        /// <returns>The shaded color.</returns>
        public static Color Shade(this Color color, int shade)
        {
            var ds = 0.5 - (shade / 1000.0);
            return Color.FromArgb(
                color.A,
                color.R + (int)((ds < 0 ? color.R : (255 - color.R)) * ds),
                color.G + (int)((ds < 0 ? color.G : (255 - color.G)) * ds),
                color.B + (int)((ds < 0 ? color.B : (255 - color.B)) * ds)
            );
        }

        /// <summary>
        /// Returns the hex string representation of the color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>A hex string.</returns>
        public static string ToHexString(this Color color) =>
            $"#{color.ToArgb():X8}";

        /// <summary>
        /// Returns a boolean indicating if the color is light.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>True if the color is light; otherwise, false.</returns>
        public static bool IsLight(this Color color) =>
            color.GetBrightness() > 0.5;

        /// <summary>
        /// Returns a boolean indicating if the color is dark.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>True if the color is dark; otherwise, false.</returns>
        public static bool IsDark(this Color color) =>
            color.GetBrightness() <= 0.5;

        /// <summary>
        /// Returns a tween function for transitioning to another color.
        /// </summary>
        /// <param name="startColor">Starting color.</param>
        /// <param name="endColor">Ending color.</param>
        /// <param name="progress">Progress from 0 to 1.</param>
        /// <returns>A color between startColor and endColor.</returns>
        public static Color TweenTo(this Color startColor, Color endColor, double progress)
        {
            return Color.FromArgb(
                (int)(startColor.A + (endColor.A - startColor.A) * progress),
                (int)(startColor.R + (endColor.R - startColor.R) * progress),
                (int)(startColor.G + (endColor.G - startColor.G) * progress),
                (int)(startColor.B + (endColor.B - startColor.B) * progress)
            );
        }

        /// <summary>
        /// Returns a tween function for transitioning from another color.
        /// </summary>
        /// <param name="endColor">Ending color.</param>
        /// <param name="startColor">Starting color.</param>
        /// <param name="progress">Progress from 0 to 1.</param>
        /// <returns>A color between startColor and endColor.</returns>
        public static Color TweenFrom(this Color endColor, Color startColor, double progress)
        {
            return startColor.TweenTo(endColor, progress);
        }
    }
}
