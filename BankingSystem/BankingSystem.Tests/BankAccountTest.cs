using NUnit.Framework;
using System;

namespace BankingSystem.Tests
{
    public class BankAccountTests
    {

        [Test]
        public void DepositShouldIncreaseBalance1()
        {
            {
                //Arange
                int id = 123;
                int amount = 500;
                BankAccount bankAccount = new BankAccount(id, amount);
                decimal depositAmount = 100;

                //Act
                bankAccount.Deposit(depositAmount);

                //Assert
                Assert.AreEqual(depositAmount + amount, bankAccount.Balance, "Balance should increase with possitive number");
            }
        }

        [TestCase(123, 500)]
        [TestCase(123,500.7686)]
        [TestCase(123,0)]
        public void ConstructorShouldSetBalanceCorrectly(int id,decimal amount)
        {
            {
                //Arange and Act
                BankAccount bankAccount = new BankAccount(id, amount);

                //Assert
                Assert.AreEqual( amount, bankAccount.Balance);

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
        public void BalanceShouldThrowArgumentExcpetionWhenBalanceIsNegative()
        {
            {
                //Arange
                int id = 123;
                decimal amount = -100.939m;

                //Act and Assert
                Assert.Throws<ArgumentException>(() => new BankAccount(id, amount));
            }
        }



        [Test]
        public void NegativeAmountShouldThrowInvalidOperationExceptionsWithMessage()
        {
            {
                //Arange
                BankAccount bankAccount = new BankAccount(123);
                decimal depositAmount = -100;

                //Assert and Act
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



        [Test]
        public void BalanceShouldThrowCurrentMessageWhenAmountIsNegative()
        {
            {
                int id = 123;
                decimal amount = -100.123m;
                string message = "Balance must be positive or zero";

                var ex = Assert.Throws<ArgumentException>(() => new BankAccount(id, amount));
                Assert.AreEqual(message, ex.Message);
            }
        }

        [TestCase(123,1500)]
        [TestCase(123,1999.9030)]
         
        public void BonusShouldIncreaseBalanceWhenBalanceIsLessOrEqual1000(int id,decimal balance)
        {
            BankAccount bankAccount = new BankAccount(id, balance);
            bankAccount.Bonus();
            Assert.AreEqual(balance,bankAccount.Balance);
        }

        [TestCase(123, 500)]
        [TestCase(123, 100)]

        public void BonusShouldIncreaseBalanceWhenIsBetweeen100And2000(int id, decimal balance)
        {
            BankAccount bankAccount = new BankAccount(id, balance);
            var expectedResult = balance + 100;
            bankAccount.Bonus();
            Assert.AreEqual(expectedResult, bankAccount.Balance);
        }



    }
}