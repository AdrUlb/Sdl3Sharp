using static Sdl3Sharp.Imports;

namespace Sdl3Sharp;

public class SdlGlContext(SdlWindow window) : IDisposable
{
	private readonly SdlGlContextHandle _handle = SDL_GL_CreateContext(window.Ptr);

	public void MakeCurrent() => SDL_GL_MakeCurrent(window.Ptr, _handle);
	
	private void ReleaseUnmanagedResources()
	{
		SDL_GL_DestroyContext(_handle);
	}

	private void Dispose(bool disposing)
	{
		ReleaseUnmanagedResources();
		if (disposing)
		{
			window.Dispose();
		}
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	~SdlGlContext()
	{
		Dispose(false);
	}
}
