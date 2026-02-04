using NUnit.Framework;
using System;

[TestFixture]
public class UnitTest
{
    [Test]
    public void Test_Deposit_ValidAmount()
    {
        Program account = new Program(100);

        account.Deposit(50);

        Assert.AreEqual(150, account.Balance);
    }

    [Test]
    public void Test_Deposit_NegativeAmount()
    {
        Program account = new Program(100);

        Assert.AreEqual(
            "Deposit amount cannot be negative",
            Assert.Throws<Exception>(() => account.Deposit(-20)).Message
        );
    }

    [Test]
    public void Test_Withdraw_ValidAmount()
    {
        Program account = new Program(200);

        account.Withdraw(50);

        Assert.AreEqual(150, account.Balance);
    }

    [Test]
    public void Test_Withdraw_InsufficientFunds()
    {
        Program account = new Program(100);

        Assert.AreEqual(
            "Insufficient funds.",
            Assert.Throws<Exception>(() => account.Withdraw(200)).Message
        );
    }
}
