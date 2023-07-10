namespace DogBank.Api.Commands
{
    public class TransferAmountCommand
    {
        public TransferAccountData TransferAccountOrigin { get; set; }

        public TransferAccountData TransferAccountDestination { get; set; }

        public TransferAmountCommand(TransferAccountData transferAccountOrigin, TransferAccountData transferAccountDestination)
        {
            TransferAccountOrigin = transferAccountOrigin;
            TransferAccountDestination = transferAccountDestination;
        }
    }

    public class TransferAccountData
    {
        public double Amount { get; set; }
        public string Account { get; set; }
    }
}
