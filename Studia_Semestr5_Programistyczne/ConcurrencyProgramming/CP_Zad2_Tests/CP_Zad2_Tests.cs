namespace CP_Zad2_Tests;

public class CP_Zad2_Tests
{
    [Fact]
    public void RandomGenerator_CheckGenerateLenghtArray_ArrayMust1000000Elements()
    {
        //Arrange
        int n = 1000000;
        //Act
        var result = RandomNumberGenerator.RandomGenerator(n);
        //Assert
        Assert.NotNull(result);
        Assert.Equal(n, result.Length);
    }
    [Theory]
    [InlineData(new int[] { 5, 2, 9, 1, 5, 6 })]
    [InlineData(new int[] { 10, -2, 0, 3, 7, 15 })]
    [InlineData(new int[] { 1, 4, 61, 26, 6, 42, 7, 8, 8, 22 })]
    public void QuickSortAlgorithm_CheckCorrectSorting_SortArrayAscending(int[] array)
    {
        
        var expected = (int[])array.Clone();
        Array.Sort(expected); 

        
        var result=QuickSortAlgorithm.QuickSort(array, 0, array.Length - 1);

      
        Assert.NotNull(result);
        Assert.Equal(expected, result); 
    }
    [Fact]
    public void LogicalExercise2ConcurrencyProgramming_CheckCorrectSorting_SortArrayAscending()
    {
        // Arrange
        var array = RandomNumberGenerator.RandomGenerator(1000000);
        var expectedArray = (int[])array.Clone();
        Array.Sort(expectedArray); 

        // Act
        var sortedArray = LogicalExercise2ConcurrencyProgramming.ExecuteExercise2(array);

        // Assert
        Assert.NotNull(sortedArray);
        Assert.Equal(expectedArray.Length, sortedArray.Length); 
        Assert.Equal(expectedArray, sortedArray);
    }

}