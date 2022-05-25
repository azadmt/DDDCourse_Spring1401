using AccountManagement.Domain.BankAccount;
using System;
using Xunit;

namespace AccounManagement.Domain.UnitTest
{
    public class Account
    {
        [Fact]
        public void SameAccountNumber_Shuld_Be_Equal()
        {
            var accountNumber1 = new AccountNumber("123456");
            var accountNumber2 = new AccountNumber("123456");

            Assert.True(accountNumber1== accountNumber2);
        }

        [Fact]
        public void Diffrent_Money_Are_Not_Same()
        {
            var m1 = new Money(1200);
            var m2= new Money(2200);

            Assert.True(m2>m1);
        }
    }
}
