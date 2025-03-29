namespace TestTask_2
{
    public static class Server
    {
        static int count = 0;
        static ReaderWriterLockSlim mainLock = new ReaderWriterLockSlim();

        public static int GetCount()
        {
            mainLock.EnterReadLock();

            try
            { return count; }

            finally
            { mainLock.ExitReadLock(); }
        }

        public static void AddToCount(int value)
        {
            mainLock.EnterWriteLock();
            count += value;
            mainLock.ExitWriteLock();
        }
    }
}
