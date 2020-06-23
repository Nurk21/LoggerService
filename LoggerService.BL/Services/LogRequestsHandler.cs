using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.BL.Services
{
    public interface ILogRequestsHandler
    {
        Task Create();
        Task GetTaskAsync();
    }
    class LogRequestsHandler : ILogRequestsHandler
    {
        public async Task Create()
        {
            await
        }
        public async Task GetTaskAsync()
        {
            await 
        }
    }
}
