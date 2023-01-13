using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLib.Contracts
{
    interface IEmployeeService
    {
        string GetEmployeeById(int employeeId);
        void WriteToWindowsEventLog(string source, string sourceTag, string errorMessage);
    }
}
