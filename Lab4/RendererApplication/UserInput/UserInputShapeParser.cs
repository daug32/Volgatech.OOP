using System.Globalization;
using System.Numerics;
using Renderer.Colors;
using Renderer.Shapes;
using Renderer.Shapes.SolidShapes;

namespace RendererApplication.UserInput;

public static class UserInputShapeParser
{
    private static readonly NumberStyles _style = NumberStyles.Float | NumberStyles.AllowThousands;
    private static readonly IFormatProvider _formatProvider = CultureInfo.InvariantCulture;

    public static IShape Parse( string line )
    {
        string[] data = line.Trim().Split( ' ' );
        if ( data.Length < 2 )
        {
            throw new ArgumentException( $"Can't parse {line}. Not enough information provided " );
        }

        ShapeType shapeType = ParseShapeType( data.First() );

        return ParseShape( shapeType, data );
    }

    private static IShape ParseShape( ShapeType shapeType, string[] data )
    {
        return shapeType switch
        {
            ShapeType.Rectangle => ParseRectangle( data ),
            ShapeType.Triangle => ParseTriangle( data ),
            ShapeType.Circle => ParseCircle( data ),
            ShapeType.Line => ParseLine( data ),
            _ => throw new ArgumentOutOfRangeException( nameof( shapeType ) )
        };
    }

    private static ShapeType ParseShapeType( string str )
    {
        if ( !Enum.TryParse( str, true, out ShapeType result ) )
        {
            throw new ArgumentException( "Shape is not in correct format" );
        }

        if ( result == ShapeType.Undefined )
        {
            throw new ArgumentOutOfRangeException( nameof( result ), "Shape type is not supported" );
        }

        return result;
    }

    private static IShape ParseRectangle( string[] data )
    {
        return new Rectangle(
            ParseVector( data[1], data[2] ),
            ParseVector( data[3], data[4] ),
            ParseColor( data[5] ),
            ParseColor( data[6] ) );
    }

    private static IShape ParseTriangle( string[] data )
    {
        return new Triangle(
            ParseVector( data[1], data[2] ),
            ParseVector( data[3], data[4] ),
            ParseVector( data[5], data[6] ),
            ParseColor( data[7] ),
            ParseColor( data[8] ) );
    }

    private static IShape ParseCircle( string[] data )
    {
        return new Circle(
            ParseVector( data[1], data[2] ),
            ParseFloat( data[3] ),
            ParseColor( data[4] ),
            ParseColor( data[5] ) );
    }

    private static ILine ParseLine( string[] data )
    {
        return new Line(
            ParseVector( data[1], data[2] ),
            ParseVector( data[3], data[4] ),
            ParseColor( data[5] ) );
    }

    private static Vector2 ParseVector( string strX, string strY )
    {
        return new Vector2(
            ParseFloat( strX ),
            ParseFloat( strY ) );
    }

    private static Color ParseColor( string strColor )
    {
        return Color.FromHex( strColor );
    }

    private static float ParseFloat( string str )
    {
        return Single.Parse( str, _style, _formatProvider );
    }
}