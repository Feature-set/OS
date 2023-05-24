using System;
using System.Threading;

namespace Mutex_Lock
{
    class Program
    {
        static int lockValue = 0; // 상호 배제를 위한 int 변수

        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(DoWork);
                thread.Start(i);
            }

            Console.WriteLine();
        }
        static void DoWork(object threadId)
        {
            Console.WriteLine($"스레드 {threadId} 작업 시작");

            while (Interlocked.Exchange(ref lockValue, 1) != 0)
            {
                // lockValue가 0이 될 때까지 반복하여 대기
                Thread.Sleep(100);
            }

            try
            {
                // 상호 배제되어야 할 작업 수행
                Console.WriteLine($"스레드 {threadId} 작업 중");

                // 일부 시간 동안 작업을 유지하기 위해 Sleep 사용
                Thread.Sleep(2000);
            }
            finally
            {
                lockValue = 0; // 임계 영역 해제
            }

            Console.WriteLine($"스레드 {threadId} 작업 완료");
        }
    }
}

