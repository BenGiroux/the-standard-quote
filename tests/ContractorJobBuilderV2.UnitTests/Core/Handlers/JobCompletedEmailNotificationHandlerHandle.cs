using System;
using System.Threading;
using System.Threading.Tasks;
using ContractorJobBuilderV2.Core;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Core.Events;
using ContractorJobBuilderV2.Core.Handlers;
using ContractorJobBuilderV2.Core.Interfaces;
using ContractorJobBuilderV2.Core.ValueObjects;
using Moq;
using Xunit;

namespace ContractorJobBuilderV2.UnitTests.Core.Handlers
{
    public class JobCompletedEmailNotificationHandlerHandle
    {
        private JobCompletedEmailNotificationHandler _handler;
        private Mock<IEmailSender> _emailSenderMock;

        public JobCompletedEmailNotificationHandlerHandle()
        {
            _emailSenderMock = new Mock<IEmailSender>();
            _handler = new JobCompletedEmailNotificationHandler(_emailSenderMock.Object);
        }

        [Fact]
        public async Task ThrowsExceptionGivenNullEventArgument()
        {
            Exception ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
        }

        [Fact]
        public async Task SendsEmailGivenEventInstance()
        {
            await _handler.Handle(new JobAddedEvent(new Job(new TitleAndDescription("Job Title", "Job Description"), IndustryType.Carpentry)), CancellationToken.None);

            _emailSenderMock.Verify(sender => sender.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
