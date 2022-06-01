using AccountManagement.Application.Contract;
using AccountManagement.Domain.BankAccount;
using Framework.Core;
using System;

public class OpenNewAccountCommandHandler :
    ICommandHandler<OpenNewAccountCommand>,
    ICommandHandler<WithdrawFromAccountCommand>
{
    private readonly IBankAccountRepository accountRepository;
    private readonly IBus eventBus;

    public OpenNewAccountCommandHandler(IBankAccountRepository accountRepository, IBus eventBus)
    {
        this.accountRepository = accountRepository;
        this.eventBus = eventBus;
    }

    public void Handle(OpenNewAccountCommand command)
    {
        //generate identity 
        var account = BankAccountAggregate.Create(
            Guid.NewGuid(),
            command.OwnerId,
            new AccountNumber(command.Number),
            AccountType.Current
            );

        accountRepository.Add(account);
        //foreach (var @event in account.Changes)
        //{
        //    eventBus.Publish((dynamic)@event);
        //}
    }

    public void Handle(WithdrawFromAccountCommand command)
    {
        var account = accountRepository.Get(command.AccountId);
        account.Withraw(new Money(command.Amount));
    }
}



