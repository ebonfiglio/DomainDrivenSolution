using DomainDrivenSolution.Logic;
using FluentAssertions;
using static DomainDrivenSolution.Logic.Money;

namespace DomainDrivenSolution.Tests
{
    public class SnackMachineSpecs
    {
        [Fact]
        public void Return_money_empties_money_in_transaction()
        {
            SnackMachine snackMachine = new();

            snackMachine.InsertMoney(Dollar);

            snackMachine.ReturnMoney();

            snackMachine.MoneyInTransaction.Amount.Should().Be(0m);
        }

        [Fact]
        public void Inserted_money_goes_to_money_in_transaction()
        {
            SnackMachine snackMachine = new();
            snackMachine.InsertMoney(Dollar);
            snackMachine.MoneyInTransaction.Amount.Should().Be(1m);
        }

        [Fact]
        public void Cannot_insert_more_than_one_coin_or_note_at_time()
        {
            SnackMachine snackMachine = new();
            Money TwoCent = Cent + Cent;
            Action action = () => snackMachine.InsertMoney(TwoCent);
            action.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Money_in_transaction_goes_to_money_inside_after_purchase()
        {
            SnackMachine snackMachine = new();
            snackMachine.InsertMoney(Dollar);
            snackMachine.InsertMoney(Dollar);

            snackMachine.BuySnack();

            snackMachine.MoneyInTransaction.Should().Be(None);
            snackMachine.MoneyInside.Should().Be(2m);
        }
    }
}
