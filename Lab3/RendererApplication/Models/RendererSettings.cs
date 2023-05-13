namespace RendererApplication.Models;

public class RendererSettings
{
    public string? FilePath { get; set; }

    public int DefaultCanvasWidth => 60;
    public int DefaultCanvasHeight => 20;
    
    public bool NeedToUseFile => !String.IsNullOrWhiteSpace( FilePath );
}