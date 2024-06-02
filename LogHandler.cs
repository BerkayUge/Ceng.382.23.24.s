using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ceng._382._23._24.s._202011055
{
    public class LogHandler
{
    private readonly ILogger _logger;

    public LogHandler(ILogger logger)
    {
        _logger = logger;
    }

    public void AddLog(LogRecord log)
    {
        _logger.Log(log);
    }
}
}