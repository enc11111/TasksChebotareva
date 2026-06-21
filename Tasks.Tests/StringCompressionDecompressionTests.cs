using Tasks;
namespace Tasks.Tests;
  
public class StringCompressionDecompressionTests
{
    [Fact]
    public void StringCompressionOneLetterTest1()
    {
        var strOrig = "raaaybbcccdde";
        var res = StringCompressionDecompression.StringCompress(strOrig);
        Assert.Equal("ra3yb2c3d2e", res);
    }
    [Fact]
    public void StringCompressionTheSameLetterTest2()
    {
        var strOrig = "rrrrrrrrrrrrr";
        var res = StringCompressionDecompression.StringCompress(strOrig);
        Assert.Equal("r13", res);
    }
    [Fact]
    public void StringCompressionEmptyStrTest3()
    {
        string strOrig = string.Empty;
        Assert.Throws<ArgumentException>(() => StringCompressionDecompression.StringCompress(strOrig));
        //Assert.Equal(string.Empty, res);
    }
    [Fact]
    public void StringCompressionOnlyOneLetterTest4()
    {
        string strOrig = "a";
        var res = StringCompressionDecompression.StringCompress(strOrig);
        Assert.Equal("a", res);
    }
    [Fact]
    public void StringDecompressionOneLetterTest5()
    {
        var strOrig = "ra3yb2c3d2e";
        var res = StringCompressionDecompression.StringDecompress(strOrig);
        Assert.Equal("raaaybbcccdde", res);
    }
    [Fact]
    public void StringDecompressEmptyStrTest6()
    {
        string strOrig = string.Empty;
        Assert.Throws<ArgumentException>(() => StringCompressionDecompression.StringDecompress(strOrig));
    }
    [Fact]
    public void StringDecompressionTheSameLetterTest7()
    {
        var strOrig = "r13";
        var res = StringCompressionDecompression.StringDecompress(strOrig);
        Assert.Equal("rrrrrrrrrrrrr", res);
    }
    [Fact]
    public void StringDecompressionOnlyOneLetterTest8()
    {
        string strOrig = "a";
        var res = StringCompressionDecompression.StringDecompress(strOrig);
        Assert.Equal("a", res);
    }
	[Fact]
    public void StringCompressionDecompressionRepetitionsTest9()
    {
        string strOrig = "abbaaca";
        var resCompressed = StringCompressionDecompression.StringCompress(strOrig);
        var resDecompressed = StringCompressionDecompression.StringDecompress(resCompressed);
        Assert.Equal(strOrig, resDecompressed);
    }
    [Fact]
    public void StringCompressionWrongFormatTest10()
    {
        string strOrig = "10";
        Assert.Throws<ArgumentOutOfRangeException>(() => StringCompressionDecompression.StringCompress(strOrig));
    }
    [Fact]
    public void StringDecompressionWrongFormatTest11()
    {
        string strOrig = "10g";
        Assert.Throws<ArgumentOutOfRangeException>(() => StringCompressionDecompression.StringDecompress(strOrig));
    }
}
