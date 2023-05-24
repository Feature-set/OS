using System;

// 프로세스 및 이벤트 로깅 성능 모니터링 등이 포함된 네임스페이스
using System.Diagnostics;

namespace Process_and_Tread
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessInfo();
        }

        static void ProcessInfo()
        {
            Process curProcess = Process.GetCurrentProcess();
            Console.WriteLine("현재 프로세스 이름 : " + curProcess.ProcessName);
            Console.WriteLine("현재 프로세스 ID (PID) : " + curProcess.Id);
            Console.WriteLine("프로세스 시작 시간 : " + curProcess.StartTime);
            Console.WriteLine("프로세스 실행 시간 : " + (DateTime.Now - curProcess.StartTime));
        }
    }
}
