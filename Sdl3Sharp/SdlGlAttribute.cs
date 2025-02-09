namespace Sdl3Sharp;

public enum SdlGlAttribute
{

	RedSize, // the minimum number of bits for the red channel of the color buffer; defaults to 3.
	GreenSize, // the minimum number of bits for the green channel of the color buffer; defaults to 3.
	BlueSize, // the minimum number of bits for the blue channel of the color buffer; defaults to 2.
	AlphaSize, // the minimum number of bits for the alpha channel of the color buffer; defaults to 0.
	BufferSize, // the minimum number of bits for frame buffer size; defaults to 0.
	Doublebuffer, // whether the output is single or double buffered; defaults to double buffering on.
	DepthSize, // the minimum number of bits in the depth buffer; defaults to 16.
	StencilSize, // the minimum number of bits in the stencil buffer; defaults to 0.
	AccumRedSize, // the minimum number of bits for the red channel of the accumulation buffer; defaults to 0.
	AccumGreenSize, // the minimum number of bits for the green channel of the accumulation buffer; defaults to 0.
	AccumBlueSize, // the minimum number of bits for the blue channel of the accumulation buffer; defaults to 0.
	AccumAlphaSize, // the minimum number of bits for the alpha channel of the accumulation buffer; defaults to 0.
	Stereo, // whether the output is stereo 3D; defaults to off.
	Multisamplebuffers, // the number of buffers used for multisample anti-aliasing; defaults to 0.
	Multisamplesamples, // the number of samples used around the current pixel used for multisample anti-aliasing.
	AcceleratedVisual, // set to 1 to require hardware acceleration, set to 0 to force software rendering; defaults to allow either.
	RetainedBacking, // not used (deprecated).
	ContextMajorVersion, // OpenGL context major version.
	ContextMinorVersion, // OpenGL context minor version.
	ContextFlags, // some combination of 0 or more of elements of the SDL_GLContextFlag enumeration; defaults to 0.
	ContextProfileMask, // type of GL context (Core, Compatibility, ES). See SDL_GLProfile; default value depends on platform.
	ShareWithCurrentContext, // OpenGL context sharing; defaults to 0.
	FramebufferSrgbCapable, // requests sRGB capable visual; defaults to 0.
	ContextReleaseBehavior, // sets context the release behavior. See SDL_GLContextReleaseFlag; defaults to FLUSH.
	ContextResetNotification, // set context reset notification. See SDL_GLContextResetNotification; defaults to NO_NOTIFICATION.
	ContextNoError,
	Floatbuffers,
	EglPlatform
}
