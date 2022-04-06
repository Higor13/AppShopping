using AppShopping.Helpers.MVVM;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    public class TicketScanViewModel : BaseViewModel
    {
        public string TicketNumber { get; set; }
        public ICommand TicketScanCommand { get; set; }
        private string _message;
        public string Message { 
            get 
            {
                return _message;
            }
            set
            {
                SetProperty(ref _message, value);
            }
        }
        public ICommand TicketPaidHistoryCommand { get; set; }

        public TicketScanViewModel()
        {
            TicketScanCommand = new Command(TicketScan);
            TicketPaidHistoryCommand = new Command(TicketPaidHistory);
        }

        private void TicketScan()
        {
            // Camera - Scanear codigo de barras

            TicketProcess("");
        }
        private void TicketProcess(string ticketNumber)
        {
            try
            {
                var ricket = new TicketService().GetTicketInfo(ticketNumber);

                // Navegar para a pag de pagamento do ticket
            }
            catch (Exception e)
            {

                Message = e.Message;
            }
        }
        private void TicketPaidHistory()
        {

        }
    }
}
