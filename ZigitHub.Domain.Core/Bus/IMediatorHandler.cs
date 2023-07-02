using System.Threading.Tasks;
using ZigitHub.Domain.Core.Commands;

namespace ZigitHub.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
    }
}
