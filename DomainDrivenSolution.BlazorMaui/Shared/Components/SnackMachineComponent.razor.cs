
using DomainDrivenSolution.Logic;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel;

namespace DomainDrivenSolution.BlazorMaui.Shared.Components
{
    public partial class SnackMachineComponent
    {
        [Inject]
        private ISnackbar Snackbar { get; set; }

        [Parameter]
        public SnackMachine SnackMachine { get; set; } = new SnackMachine();

        public string MoneyInTransaction => SnackMachine.MoneyInTransaction.ToString();

        public Money MoneyInside => SnackMachine.MoneyInside + SnackMachine.MoneyInTransaction;
        
        private string _message = "";
        public string Message
        {
            get { return _message; }
            private set
            {
                _message = value;
                StateHasChanged();
            }
        }

        private void BuySnack()
        {
            SnackMachine.BuySnack();
            StateHasChanged();
            Message = "Snack bought!";
            Snackbar.Add(Message, Severity.Success);
        }

        private void ReturnMoney()
        {
            SnackMachine.ReturnMoney();
            StateHasChanged();
            Message = "Money was returned";
            Snackbar.Add(Message, Severity.Info);
        }
        private void InsertAmount(Money amount)
        {
            SnackMachine.InsertMoney(amount);
            StateHasChanged();
            Message = $"You have inserted: {amount}";
            Snackbar.Add(Message, Severity.Info);
        }
    }
}
