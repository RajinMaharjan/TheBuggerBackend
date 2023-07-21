using Excallibur.Domain.Entites;

namespace Excallibur.Application.Common.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
