﻿namespace PointOfSale.Domain.Enums
{
    public enum ResponseResultType
    {
        Success,
        AlreadyExists,
        NoChanges,
        ValidationError,
        NotFound,
        NotEnoughInInventory,
        NotEnoughWorkers
    }
}
