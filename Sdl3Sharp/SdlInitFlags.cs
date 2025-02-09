namespace Sdl3Sharp;

public enum SdlInitFlags : uint
{
	Audio = 0x00000010,
	Video = 0x00000020,
	Joystick = 0x00000200,
	Haptic = 0x00001000,
	Gamepad = 0x00002000,
	Events = 0x00004000,
	Sensor = 0x00008000,
	Camera = 0x00010000
}
