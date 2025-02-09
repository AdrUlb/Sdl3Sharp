using System.Drawing;
using static Sdl3Sharp.Imports;

namespace Sdl3Sharp;

public sealed class SdlTexture : IDisposable
{
	private readonly SdlRenderer _renderer;

	internal SdlTexturePtr Handle { get; private set; }

	public readonly float Width;
	public readonly float Height;

	private SdlTexture(SdlRenderer renderer, SdlTexturePtr handle)
	{
		_renderer = renderer;
		SdlErrorException.ThrowIf(handle == SdlTexturePtr.Null);
		Handle = handle;
		SDL_GetTextureSize(handle, out Width, out Height);
	}

	public SdlTexture(SdlRenderer renderer, SdlProperties props) :
		this(renderer, SDL_CreateTextureWithProperties(renderer.Ptr, props.Id)) { }

	public unsafe void Render(RectangleF? sourceRect, RectangleF? destRect)
	{
		var srcrect = new SdlFRect();
		var dstrect = new SdlFRect();

		if (sourceRect.HasValue)
			srcrect = SdlFRect.FromRectangleF(sourceRect.Value);

		if (destRect.HasValue)
			dstrect = SdlFRect.FromRectangleF(destRect.Value);

		var srcrectPtr = sourceRect.HasValue ? &srcrect : null;
		var dstrectPtr = destRect.HasValue ? &dstrect : null;

		SdlErrorException.ThrowIf(!SDL_RenderTexture(_renderer.Ptr, Handle, srcrectPtr, dstrectPtr));
	}

	public unsafe SdlSurface LockToSurface()
	{
		SdlErrorException.ThrowIf(!SDL_LockTextureToSurface(Handle, null, out var surfacePtr));
		return new(surfacePtr);
	}

	public void Unlock() => SDL_UnlockTexture(Handle);

	public void SetScaleMode(SdlScaleMode scaleMode) => SdlErrorException.ThrowIf(!SDL_SetTextureScaleMode(Handle, scaleMode));

	private void ReleaseUnmanagedResources()
	{
		if (Handle == SdlTexturePtr.Null)
			return;

		SDL_DestroyTexture(Handle);
		Handle = SdlTexturePtr.Null;
	}

	private void Dispose(bool disposing)
	{
		ReleaseUnmanagedResources();
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	~SdlTexture()
	{
		Dispose(false);
	}
}
