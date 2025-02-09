namespace Sdl3Sharp;

using static Imports;

public sealed class SdlWindow : IDisposable
{
	internal SdlWindowPtr Ptr;

	public SdlRenderer? Renderer { get; internal set; }

	private SdlWindow(SdlWindowPtr ptr)
	{
		SdlErrorException.ThrowIf(ptr == SdlWindowPtr.Null);

		Ptr = ptr;
	}

	public SdlWindow(SdlWindow parent, int offsetX, int offsetY, int width, int height, SdlWindowFlags flags) :
		this(SDL_CreatePopupWindow(parent.Ptr, offsetX, offsetY, width, height, flags)) { }

	public SdlWindow(SdlProperties props) :
		this(SDL_CreateWindowWithProperties(props.Id)) { }

	public SdlWindow(string title, int width, int height, SdlWindowFlags flags = 0, bool withRenderer = false)
	{
		if (withRenderer)
		{
			SdlErrorException.ThrowIf(!SDL_CreateWindowAndRenderer(title, width, height, flags, out var window, out var renderer));

			Ptr = window;
			Renderer = new(renderer, this);
		}
		else
		{
			Ptr = SDL_CreateWindow(title, width, height, flags);
			if (Ptr == SdlWindowPtr.Null)
				throw new();
		}
	}

	public SdlRenderer CreateRenderer(string? name = null)
	{
		var handle = name != null ? SDL_CreateRenderer(Ptr, name) : SDL_CreateRenderer(Ptr, 0);
		SdlErrorException.ThrowIf(handle == SdlRendererPtr.Null);

		Renderer = new(handle, this);
		return Renderer;
	}

	public SdlWindowId GetId() => SDL_GetWindowID(Ptr);

	public SdlProperties GetProperties() => new(SDL_GetWindowProperties(Ptr));

	public void Show() => SdlErrorException.ThrowIf(!SDL_ShowWindow(Ptr));

	public void Hide() => SdlErrorException.ThrowIf(!SDL_ShowWindow(Ptr));

	public float GetOpacity() => SDL_GetWindowOpacity(Ptr);

	public bool SetOpacity(float opacity) => SDL_SetWindowOpacity(Ptr, opacity);

	public void SetTitle(string title) => SDL_SetWindowTitle(Ptr, title);

	public void SetSize(int width, int height)
	{
		SdlErrorException.ThrowIf(!SDL_SetWindowSize(Ptr, width, height));
	}

	private void ReleaseUnmanagedResources()
	{
		if (Ptr == SdlWindowPtr.Null)
			return;

		Renderer?.Dispose();
		SDL_DestroyWindow(Ptr);
		Ptr = SdlWindowPtr.Null;
	}

	public void Dispose()
	{
		ReleaseUnmanagedResources();
		GC.SuppressFinalize(this);
	}

	~SdlWindow()
	{
		ReleaseUnmanagedResources();
	}
}
