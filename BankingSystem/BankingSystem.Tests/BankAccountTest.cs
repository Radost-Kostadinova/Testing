using NUnit.Framework;
using System;

namespace BankingSystem.Tests
{
    public class BankAccountTests
    {
        [Test]
        public void DepositShouldIncreaseBalance()
        {
            {
                //Arange
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = 100;

                //Act
                bankAccount.Deposit(depositAmount);

                //Assert
                Assert.AreEqual(depositAmount, bankAccount.Balance);
            }
        }

        [Test]
        public void AccountInicializeWhithPositiveValue()
        {
            {
                //Arange

                //Act
                BankAccount bankAccount = new BankAccount(123, 200m);

                //Assert
                Assert.AreEqual(200m, bankAccount.Balance);
            }
        }


        [TestCase(100)]
        [TestCase(3500)]
        [TestCase(2400)]
        public void DepositShouldIncreaseBalanceAll(decimal depositAmount)
        {
            {
                //Arange
                BankAccount bankAccount = new BankAccount(123);

                //Act
                bankAccount.Deposit(depositAmount);

                //Assert
                Assert.AreEqual(depositAmount, bankAccount.Balance);
            }
        }


        [Test]
        public void NegativeAmountShouldThrowInvalidOperateException()
        {
            {
                //Arange
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = -100;


                //Act and Assert
                Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));
            }
        }



        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExceptionsWithMessage()
        {
            {
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = -100;

                var ex = Assert.Throws<InvalidOperationException>(() => bankAccount.Deposit(depositAmount));
                Assert.AreEqual(ex.Message, "Negative amount");
            }
        }

        [Test]
        public void DepositShouldIncreaseBalance2()
        {
            {
                //Arange
                int id = 123;
                decimal amountDeposit = 2000m;
                BankAccount bankAccount = new BankAccount(id);

                //Act
                bankAccount.Deposit(amountDeposit);

                //Assert
                Assert.AreEqual(amountDeposit, bankAccount.Balance);

            }
        }

        [Test]
        public void ConstructorShouldSetZeroBalance()
        {
            {
                //Arange
                int id = 123;

                //Act
                BankAccount account = new BankAccount(id);

                //Assert
                Assert.AreEqual(0,account.Balance);

            }
        }

        [Test]
        public void ConstructorShouldInisializeId()
        {
            //Arange
            int id = 123;

            //Act
            BankAccount account = new BankAccount(id);

            //Assert
            Assert.AreEqual(id,account.Id);
        }


    }
}