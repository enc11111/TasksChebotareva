using System.Reflection.Metadata.Ecma335;

namespace MyServer;

public static class MyServer
{
    private static int _count;
    private static ReaderWriterLockSlim _rwLocker = new ReaderWriterLockSlim();
    public static int GetCount()
    {
        _rwLocker.EnterReadLock();
        try
        {
            return _count;
        }
        finally
        {
            _rwLocker.ExitReadLock();
        }
    }
    public static void AddToCount(int value)
    {
        _rwLocker.EnterWriteLock();
        _count += value;
        _rwLocker.ExitWriteLock();
    }
}
