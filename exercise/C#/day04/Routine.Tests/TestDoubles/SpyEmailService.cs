using FluentAssertions;

namespace Routine.Tests.TestDoubles;

public class SpyEmailService : IEmailService
{
    private bool _newEmailsHaveBeenRead;

    public void ReadNewEmails() => _newEmailsHaveBeenRead = true;

    public void NewEmailsHaveBeenRead() => _newEmailsHaveBeenRead.Should().BeTrue();
}