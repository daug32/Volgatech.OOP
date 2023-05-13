using System.Numerics;

namespace RendererApplication.Models.Shapes;

public class CRectangle : ICRectangle
{
    private float _rawHeight;
    private float _rawWidth;

    public CRectangle(
        int width,
        int height,
        Vector2 start )
    {
        _rawWidth = width;
        _rawHeight = height;
        
        Move = start;
        Scale = Vector2.One;
    }

    public CRectangle(
        int width,
        int height,
        int bottomLeftPointXCoordinate,
        int bottomLeftPointYCoordinate )
        : this(
            width,
            height,
            new Vector2( bottomLeftPointXCoordinate, bottomLeftPointYCoordinate ) )
    {
    }

    public Vector2 Scale { get; set; }
    public Vector2 Move { get; set; }

    public int Left
    {
        get => ( int )Move.X;
        set => Move = Move with { X = value };
    }

    public int Bottom
    {
        get => ( int )Move.Y;
        set => Move = Move with { Y = value };
    }

    public int Top
    {
        get => ( int )Move.Y + Height;
        set => Height = ( int )( value - Move.Y );
    }

    public int Right
    {
        get => ( int )Move.X + Width;
        set => Width = ( int )( value - Move.X );
    }

    public int Width
    {
        get => ( int )( _rawWidth * Scale.X );
        set
        {
            if ( value < 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( Width ), "Width can't be less than 0" );
            }

            _rawWidth = value / Scale.X;
        }
    }

    public int Height
    {
        get => ( int )( _rawHeight * Scale.Y );
        set
        {
            if ( value < 0 )
            {
                throw new ArgumentOutOfRangeException( nameof( Height ), "Height can't be less than 0" );
            }

            _rawHeight = value / Scale.Y;
        }
    }

    public float Area => Width * Height;
    public float Perimeter => 2 * ( Width + Height );

    public ICRectangle GetIntersection( ICRectangle rect )
    {
        if ( !DoesIntersect( rect ) )
        {
            return new CRectangle( 0, 0, Vector2.Zero );
        }
        
        int top = Math.Min( Top, rect.Top );
        int left = Math.Max( Left, rect.Left );
        int right = Math.Min( Right, rect.Right );
        int bottom = Math.Max( Bottom, rect.Bottom );

        int width = right - left;
        int height = top - bottom;
        
        return new CRectangle(
            width,
            height,
            left,
            bottom );
    }

    public bool DoesIntersect( ICRectangle rect )
    {
        return
            Left <= rect.Right
            && rect.Left <= Right
            && Top >= rect.Bottom
            && rect.Top >= Bottom;
    }
}