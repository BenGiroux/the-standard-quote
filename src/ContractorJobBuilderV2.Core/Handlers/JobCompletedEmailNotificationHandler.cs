using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using ContractorJobBuilderV2.Core.Events;
using ContractorJobBuilderV2.Core.Interfaces;
using MediatR;

namespace ContractorJobBuilderV2.Core.Handlers
{
    public class JobCompletedEmailNotificationHandler : INotificationHandler<JobAddedEvent>
    {
        private readonly IEmailSender _emailSender;

        public JobCompletedEmailNotificationHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        // configure a test email server to demo this works
        // https://ardalis.com/configuring-a-local-test-email-server
        public Task Handle(JobAddedEvent domainEvent, CancellationToken cancellationToken)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            return _emailSender.SendEmailAsync("test@test.com", "test@test.com", $"{domainEvent.CompletedJob.TitleAndDescription.Title} was completed.", domainEvent.CompletedJob.ToString());
        }
    }
}
