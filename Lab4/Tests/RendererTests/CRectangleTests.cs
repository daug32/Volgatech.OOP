using System.Numerics;
using NUnit.Framework;
using Renderer.Models.Shapes.SolidShapes;

namespace RendererTests;

public class CRectangleTests
{
    [Test]
    public void Area_RectangleWithWidth4AndHeight5_ExpectAreaToBe20()
    {
        // Arrange
        float expected = 20;
        IRectangle rect = new Rectangle( 4, 5, Vector2.Zero );

        // Act
        float area = rect.Area;

        // Assert
        Assert.That( area, Is.EqualTo( expected ) );
    }

    [Test]
    public void Perimeter_RectangleWithWidth4AndHeight5_ExpectPerimeterToBe18()
    {
        // Arrange
        float expected = 18;
        IRectangle rect = new Rectangle( 4, 5, Vector2.One );

        // Act
        float perimeter = rect.Perimeter;

        // Assert
        Assert.That( perimeter, Is.EqualTo( expected ) );
    }

    [Test]
    public void Move_RectangleIsMovedBy30AtHorizontalAxes_RectanglesLeftPointIsMovedToo()
    {
        // Arrange
        float expectedLeftCoordinate = 30;
        IRectangle rect = new Rectangle( 10, 10, Vector2.Zero );
        var moveAt = new Vector2( 30, 0 );

        // Act
        rect.Move = moveAt;
        float actualLeftCoordinate = rect.Left;

        // Assert
        Assert.That( actualLeftCoordinate, Is.EqualTo( expectedLeftCoordinate ) );
    }

    [Test]
    public void SetScale_RectangleWithWidth4AndHeight5ScaledByTwoAtEachDirection_NewWidthIs8AndHeightIs10()
    {
        // Arrange
        var width = 4;
        var height = 5;
        var scaleMultipier = 2;

        var rect = new Rectangle( width, height, Vector2.Zero );

        // Act
        rect.Scale = new Vector2( scaleMultipier );

        // Assert
        AssertPropertyChanges(
            rect,
            width * scaleMultipier,
            height * scaleMultipier );
    }

    [Test]
    public void SetLeft_IncreaseLeft_OnlyLeftPropertyChanges()
    {
        // Arrange
        var startYCoordinate = 1;
        var startXCoordinate = 2;
        var width = 3;
        var height = 4;

        var rect = new Rectangle(
            width,
            height,
            startXCoordinate,
            startYCoordinate );

        // Act
        startXCoordinate += 5;
        rect.Left += 5;

        // Assert
        AssertPropertyChanges(
            rect,
            width,
            height,
            startXCoordinate,
            startYCoordinate );
    }

    [Test]
    public void SetBottom_IncreaseBottom_OnlyBottomPropertyChanges()
    {
        // Arrange
        var startYCoordinate = 1;
        var startXCoordinate = 2;
        var width = 3;
        var height = 4;

        var rect = new Rectangle(
            width,
            height,
            startXCoordinate,
            startYCoordinate );

        // Act
        startYCoordinate += 5;
        rect.Bottom += 5;

        // Assert
        AssertPropertyChanges(
            rect,
            width,
            height,
            startXCoordinate,
            startYCoordinate );
    }

    [Test]
    public void SetTop_IncreaseTop_HeightAndTopPropertiesChange()
    {
        // Arrange
        var startYCoordinate = 1;
        var startXCoordinate = 2;
        var width = 3;
        var height = 4;

        var rect = new Rectangle(
            width,
            height,
            startXCoordinate,
            startYCoordinate );

        // Act
        height += 5;
        rect.Top += 5;

        // Assert
        AssertPropertyChanges(
            rect,
            width,
            height,
            startXCoordinate,
            startYCoordinate );
    }

    [Test]
    public void SetRight_IncreaseRight_WidthAndRightPropertyChange()
    {
        // Arrange
        var startYCoordinate = 1;
        var startXCoordinate = 2;
        var width = 3;
        var height = 4;

        var rect = new Rectangle(
            width,
            height,
            startXCoordinate,
            startYCoordinate );

        // Act
        width += 5;
        rect.Width += 5;

        // Assert
        AssertPropertyChanges(
            rect,
            width,
            height,
            startXCoordinate,
            startYCoordinate );
    }

    [Test]
    public void
        SetRightAndSetWidth_IncreaseRightBy5AndAfterThatSetScaleXTo10AtRectangleWithWidth2StartingFromCoordinationCenter_OnlyWidthChangedAndItIsEqualTo70()
    {
        // Arrange
        var rect = new Rectangle( 2, 10, Vector2.Zero );

        // Act
        rect.Right += 5;
        rect.Scale = rect.Scale with { X = 10 };

        // Assert
        AssertPropertyChanges(
            rect,
            70,
            10 );
    }

    [Test]
    public void
        SetRightAndSetWidth_SetScaleXTo10AndAfterThatIncreaseRightBy5AtRectangleWithWidth2StartingFromCoordinationCenter_OnlyWidthChangedAndItIsEqualTo25()
    {
        // Arrange
        var rect = new Rectangle( 2, 10, Vector2.Zero );

        // Act
        rect.Scale = rect.Scale with { X = 10 };
        rect.Right += 5;

        // Assert
        AssertPropertyChanges(
            rect,
            25,
            10 );
    }

    [Test]
    public void Intersect_RectanglesThatAreActuallyIntersect_ReturnsTrue()
    {
        // Arrange
        IRectangle rect1 = new Rectangle( 4, 5, Vector2.Zero );
        IRectangle rect2 = new Rectangle( 2, 3, Vector2.Zero );

        // Act
        bool doesIntersect = rect1.DoesIntersect( rect2 );

        // Assert
        Assert.That( doesIntersect, Is.True );
    }

    [Test]
    public void Intersect_RectanglesThatDontIntersect_ReturnsFalse()
    {
        // Arrange
        IRectangle rect1 = new Rectangle( 4, 5, Vector2.Zero );
        IRectangle rect2 = new Rectangle( 2, 3, new Vector2( 100 ) );

        // Act
        bool doesIntersect = rect1.DoesIntersect( rect2 );

        // Assert
        Assert.That( doesIntersect, Is.False );
    }

    private static void AssertPropertyChanges(
        Rectangle rect,
        int width,
        int height,
        int startXCoordinate = 0,
        int startYCoordinate = 0 )
    {
        Assert.That( rect.Left, Is.EqualTo( startXCoordinate ) );
        Assert.That( rect.Bottom, Is.EqualTo( startYCoordinate ) );
        Assert.That( rect.Right, Is.EqualTo( startXCoordinate + width ) );
        Assert.That( rect.Top, Is.EqualTo( startYCoordinate + height ) );
        Assert.That( rect.Width, Is.EqualTo( width ) );
        Assert.That( rect.Height, Is.EqualTo( height ) );
    }
}