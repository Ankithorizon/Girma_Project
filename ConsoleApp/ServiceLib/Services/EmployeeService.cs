using Microsoft.Extensions.Logging;
using ServiceLib.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using ServiceLib.HelperClass;


namespace ServiceLib.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly Credentials _credential;

        public EmployeeService(ILogger<EmployeeService> _logger=null)
        // public EmployeeService(ILogger<EmployeeService> _logger)
        {
            this._logger = _logger;
        }


        public EmployeeService(ILogger<EmployeeService> _logge, Credentials credential)
        {
            this._logger = _logger;
            this._credential = credential;
        }

        public void WriteToWindowsEventLog(string source,string sourceTag, string errorMessage)
        {
            EventLog eventLog = new EventLog();
            // eventLog.Source = "Girma_ILogger_EventLog";
            eventLog.Source = source;
            if (!EventLog.SourceExists(source))
            {
                EventLog.CreateEventSource(source, sourceTag);
                eventLog.WriteEntry(errorMessage, EventLogEntryType.Information);
            }
            EventLog myLog = new EventLog();
            myLog.Source = source;
            myLog.WriteEntry(errorMessage, EventLogEntryType.Information);
        }
        public string GetEmployeeById(int employeeId)
        {
            Thread.Sleep(1000);

            if (_credential.UserName=="Girma" && _credential.Password == "Password")
            {
                // ILogger
                _logger?.LogInformation("Connecting ILogger To EventLog @Windows EventLog @ {DT}",
                DateTime.UtcNow.ToLongTimeString());

                // EventLog
                // WriteToWindowsEventLog("Girma_ILogger_EventLog", "GirmaLOG", "Test Message For Windows-Event-Log From C# Class Lib. Project");

                // ILogger
                //_logger?.LogInformation("log-information,,,just about to check for employeeid,,,");
                //_logger?.LogTrace("log-trace,,,just about to check for employeeid,,,");
                //_logger?.LogWarning("log-warning,,,just about to check for employeeid,,,");
                //_logger?.LogCritical("log-critical,,,just about to check for employeeid,,,");
                //_logger?.LogError("log-error,,,just about to check for employeeid,,,");

                if (employeeId == 0)
                {
                    // ILogger
                    //_logger?.LogInformation("log-information,,,now found employeeid of ZERO,,,");
                    //_logger?.LogTrace("log-trace,,,now found employeeid of ZERO,,,");
                    //_logger?.LogWarning("log-warning,,,now found employeeid of ZERO,,,");
                    //_logger?.LogCritical("log-critical,,,now found employeeid of ZERO,,,");
                    //_logger?.LogError("log-error,,,now found employeeid of ZERO,,,");
                    return "Employee-0";
                }
                else
                {
                    // ILogger
                    //_logger?.LogInformation("log-information,,,now found employeeid of NON-ZERO,,,");
                    //_logger?.LogTrace("log-trace,,,now found employeeid of NON-ZERO,,,");
                    //_logger?.LogWarning("log-warning,,,now found employeeid of NON-ZERO,,,");
                    //_logger?.LogCritical("log-critical,,,now found employeeid of NON-ZERO,,,");
                    //_logger?.LogError("log-error,,,now found employeeid of NON-ZERO,,,");
                    return "Employee-X";
                }
            }
            else
            {
                return "Wrong-Credential";
            }
            
        }
    }
}
