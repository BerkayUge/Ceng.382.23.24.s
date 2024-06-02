using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace Ceng._382._23._24.s._202011055
{
    
public class FileLogger : ILogger
{
    private readonly string _logFilePath;

    public FileLogger(string logFilePath)
    {
        _logFilePath = logFilePath;
    }

    public void Log(LogRecord log)
    {
        string json = JsonSerializer.Serialize(log);
        File.AppendAllText(_logFilePath, json + Environment.NewLine);
    }
}
}