using System.Reflection;

namespace MyServer.Tests;

public class MyServerTests
{
   /* [Fact]
    public void ReadTest1()
    {
        var readerTasks = new List<Task>();
        for (int i = 0; i < 5; i++)
        {
            readerTasks.Add(Task.Run(() =>
            {
                MyServer.GetCount();
            }));
        }
        Task.WaitAll(readerTasks.ToArray());

        Assert.Equal(0, MyServer.GetCount());
    }
    [Fact]
    public void WriteTest2()
    {
        var writerTask = Task.Run(() => MyServer.AddToCount(3));
        var writerTask2 = Task.Run(() => MyServer.AddToCount(2));

        Task.WaitAll([writerTask, writerTask2]);
        Assert.Equal(5, MyServer.GetCount());
    }*/
    [Fact]
    public void ReadWriteTest3()
    {
        var rwTasks = new List<Task>();
        for (int i = 0; i < 5; i++)
        {
            if (i % 2 == 0)
            {
                rwTasks.Add(Task.Run(() =>
                {
                    MyServer.GetCount();
                }));
            }
            else
            {
                rwTasks.Add(Task.Run(() =>
                {
                    MyServer.AddToCount(2);
                }));
            }
        }
        Task.WaitAll(rwTasks.ToArray());

        Assert.Equal(4, MyServer.GetCount());
    }
}
