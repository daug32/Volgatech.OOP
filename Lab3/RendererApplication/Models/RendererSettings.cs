namespace RendererApplication.Models;

public class RendererSettings
{
    public string? FilePath { get; set; }

    public static int DefaultCanvasWidth => 60;
    public static int DefaultCanvasHeight => 20;
    
    public bool NeedToUseFile => !String.IsNullOrWhiteSpace( FilePath );
}