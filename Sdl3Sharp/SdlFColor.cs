using System.Drawing;
using System.Runtime.InteropServices;

namespace Sdl3Sharp;

[StructLayout(LayoutKind.Sequential)]
public struct SdlFColor
{
	public float R, G, B, A;

	public static SdlFColor FromColor(Color color) => new()
		{ R = color.R / (float)byte.MaxValue, G = color.G / (float)byte.MaxValue, B = color.B / (float)byte.MaxValue, A = color.A / (float)byte.MaxValue };
}
