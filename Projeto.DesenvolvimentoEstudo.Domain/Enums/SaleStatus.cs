namespace Projeto.DesenvolvimentoEstudo.Domain.Enums;

public enum SaleStatus
{
    Unknown = 0,
    PendingPayment = 1,
    PaymentApproved = 2,
    Processing = 3,
    AwaitingShipment = 4,
    Shipped = 5,
    InTransit = 6,
    Delivered = 7,
    Cancelled = 8,
    FailedPayment = 9,
    Returned = 10,
    Refunded = 11
}
