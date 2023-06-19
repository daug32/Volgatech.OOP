using MyListTask;
using NUnit.Framework;

namespace MyListTests;

public class MyListTests
{
    [Test]
    public void Copy_SourceListIsEmpty_ReturnsEmptyList()
    {
        // Arrange
        var source = new MyList<int>();

        // Act
        IMyList<int> result = source.Copy();

        // Assert
        Assert.AreEqual( 0, result.Count );
    }

    [Test]
    public void Copy_SourceListIsNotEmpty_ReturnsListWithSameElements()
    {
        // Arrange
        var source = new MyList<int>
        {
            1, 2, 3, 4
        };

        // Act
        IMyList<int> result = source.Copy();

        // Assert
        Assert.AreEqual( source.Count, result.Count );
        for ( var i = 0; i < source.Count; i++ )
        {
            Assert.AreEqual( source[i], result[i] );
        }
    }

    [Test]
    public void Insert_NoElementsInListInsertAtStart_DoesntThrowItemSuccessfullyInsertedAtStart()
    {
        // Arrange
        var list = new MyList<int>();

        // Act
        list.Insert( 0, 1 );

        // Assert
        Assert.IsTrue( 1 == list.Count );
        Assert.IsTrue( 1 == list[0] );
    }

    [Test]
    public void Insert_NoElementsInListInsertAt5thIndex_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var list = new MyList<int>();
        var index = 5;

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>( () => list.Insert( index, 1 ) );
    }

    [TestCase(
        0,
        100,
        new[] { 1, 2, 3, 4 },
        new[] { 100, 1, 2, 3, 4 } )]
    [TestCase(
        1,
        100,
        new[] { 1, 2, 3, 4 },
        new[] { 1, 100, 2, 3, 4 } )]
    [TestCase(
        2,
        100,
        new[] { 1, 2, 3, 4 },
        new[] { 1, 2, 100, 3, 4 } )]
    [TestCase(
        3,
        100,
        new[] { 1, 2, 3, 4 },
        new[] { 1, 2, 3, 100, 4 } )]
    [TestCase(
        4,
        100,
        new[] { 1, 2, 3, 4 },
        new[] { 1, 2, 3, 4, 100 } )]
    public void Insert_CommonTestsWithValidInput_DoesntThrow(
        int indexToInsert,
        int itemToInsert,
        int[] initialItems,
        int[] expected )
    {
        // Arrange
        var list = new MyList<int>();
        foreach ( int item in initialItems )
        {
            list.Add( item );
        }

        // Act
        list.Insert( indexToInsert, itemToInsert );

        // Assert
        Assert.AreEqual( expected.Length, list.Count );
        for ( var i = 0; i < expected.Length; i++ )
        {
            Assert.AreEqual( expected[i], list[i] );
        }
    }

    [Test]
    public void InsertFirst_NoElementsInList_DoesntThrowAndInsertsElementAtStart()
    {
        // Arrange
        var list = new MyList<int>();
        var item = 10;

        // Act
        list.InsertFirst( item );

        // Arrange
        Assert.AreEqual( 1, list.Count );
        Assert.AreEqual( item, list[0] );
    }

    [Test]
    public void InsertFirst_ListWithItems_DoesntThrowSuccessfullyInsertsElementAtStart()
    {
        // Arrange
        var list = new MyList<int>
        {
            1, 2, 3, 4
        };

        var item = 10;

        // Act
        list.InsertFirst( item );

        // Assert
        Assert.AreEqual( 5, list.Count );
        Assert.AreEqual( item, list[0] );
        Assert.AreEqual( 1, list[1] );
        Assert.AreEqual( 2, list[2] );
        Assert.AreEqual( 3, list[3] );
        Assert.AreEqual( 4, list[4] );
    }

    [Test]
    public void InsertLast_NoElementsInList_DoesntThrowListContainsInsertedElement()
    {
        // Arrange
        var list = new MyList<int>();
        var item = 10;

        // Act
        list.InsertLast( item );

        // Assert
        Assert.AreEqual( 1, list.Count );
        Assert.AreEqual( item, list[0] );
    }

    [Test]
    public void InsertLast_ListContainsElements_DoesntThrowAndSuccessfullyInsertElementAtEnd()
    {
        // Arrange
        var list = new MyList<int>
        {
            1, 2, 3, 4
        };

        var item = 10;

        // Act
        list.InsertLast( item );

        // Assert
        Assert.AreEqual( 5, list.Count );
        Assert.AreEqual( 1, list[0] );
        Assert.AreEqual( 2, list[1] );
        Assert.AreEqual( 3, list[2] );
        Assert.AreEqual( 4, list[3] );
        Assert.AreEqual( item, list[^1] );
    }

    [Test]
    public void RemoveAt_NoElementsInList_ThrowsArgumentOutOfRangeException()
    {
        // Arrange
        var list = new MyList<int>();

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>( () => list.RemoveAt( 0 ) );
    }

    [Test]
    public void RemoveAt_ListContainsElementsAndRemoveItemFromFirstPosition_DoesntThrowAndElementRemoveSuccessfully()
    {
        // Arrange
        var list = new MyList<int>
        {
            1, 2, 3, 4
        };

        // Act
        list.RemoveAt( 0 );

        // Assert
        Assert.AreEqual( 3, list.Count );
        Assert.AreEqual( 2, list[0] );
        Assert.AreEqual( 3, list[1] );
        Assert.AreEqual( 4, list[2] );
    }

    [Test]
    public void RemoveAt_ListContainsElementsAndRemoveItemFromLastPosition_DoesntThrowAndElementRemoveSuccessfully()
    {
        // Arrange
        var list = new MyList<int>
        {
            1, 2, 3, 4
        };

        // Act
        list.RemoveAt( 3 );

        // Assert
        Assert.AreEqual( 3, list.Count );
        Assert.AreEqual( 1, list[0] );
        Assert.AreEqual( 2, list[1] );
        Assert.AreEqual( 3, list[2] );
    }

    [Test]
    public void RemoveAt_ListContainsElementsAndRemoveItemFromCenter_DoesntThrowAndElementRemoveSuccessfully()
    {
        // Arrange
        var list = new MyList<int>
        {
            1, 2, 3, 4
        };

        list.RemoveAt( 1 );

        // Assert
        Assert.AreEqual( 3, list.Count );
        Assert.AreEqual( 1, list[0] );
        Assert.AreEqual( 3, list[1] );
        Assert.AreEqual( 4, list[2] );
    }

    [Test]
    public void RemoveAt_ListContainsOneElement_DoesntThrowAndTheElementIsSuccessfullyRemoved()
    {
        // Arrange
        var list = new MyList<int>
        {
            1
        };
        
        // Act
        list.RemoveAt( 0 );
        
        // Assert
        Assert.AreEqual( 0, list.Count );
        Assert.Throws<ArgumentOutOfRangeException>( () =>
        {
            int a = list[0];
        } );
    }
}