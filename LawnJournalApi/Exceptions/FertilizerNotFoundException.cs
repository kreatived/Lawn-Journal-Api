using System;

namespace LawnJournalApi.Exceptions
{
    public class FertilizerNotFoundException: Exception
    {
        public string FertilizerId { get; }

        public FertilizerNotFoundException(string fertilizerId)
        {
            FertilizerId = fertilizerId;
        }
    }
}