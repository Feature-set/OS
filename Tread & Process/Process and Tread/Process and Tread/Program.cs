using System;

// 프로세스 및 이벤트 로깅 성능 모니터링 등이 포함된 네임스페이스
using System.Diagnostics;
using System.Threading;

namespace Process_and_Tread
{
    class Program
    {
        static void Main(string[] args)
        {
            // 프로세스 정보 출력
            //ProcessInfo();

            // 프로세스와 스레드 성능 차이
            ProcessAndTreadPerformance();
        }

        #region 프로세스 정보 출력
        static void ProcessInfo()
        {
            Process curProcess = Process.GetCurrentProcess();
            Console.WriteLine("현재 프로세스 이름 : " + curProcess.ProcessName);
            Console.WriteLine("현재 프로세스 ID (PID) : " + curProcess.Id);
            Console.WriteLine("프로세스 시작 시간 : " + curProcess.StartTime);
            Console.WriteLine("프로세스 실행 시간 : " + (DateTime.Now - curProcess.StartTime));
        }
        #endregion

        #region 프로세스와 스레드 성능 차이
        static void ProcessAndTreadPerformance()
        {
            int numberOfProcesses = 3;
            int numberOfThreads = 3;

            // 프로세스 방식
            Console.WriteLine("프로세스 방식");
            Stopwatch processStopwatch = Stopwatch.StartNew();
            for (int i = 0; i < numberOfProcesses; i++)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C echo Hello, world";
                Process.Start(startInfo);
            }
            processStopwatch.Stop();
            Console.WriteLine($"프로세스 방식 소요 시간: {processStopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine();

            // 스레드 방식
            Console.WriteLine("스레드 방식");
            Stopwatch threadStopwatch = Stopwatch.StartNew();
            for (int i = 0; i < numberOfThreads; i++)
            {
                Thread thread = new Thread(() =>
                {
                    Console.WriteLine("Hello, world");
                });
                thread.Start();
            }
            threadStopwatch.Stop();
            Console.WriteLine($"스레드 방식 소요 시간: {threadStopwatch.ElapsedMilliseconds}ms");
            Console.WriteLine();

            Console.ReadLine();
        }
        #endregion
    }
}
