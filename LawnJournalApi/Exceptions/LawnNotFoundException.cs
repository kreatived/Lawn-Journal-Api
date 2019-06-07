using System;

namespace LawnJournalApi.Exceptions
{
    public class LawnNotFoundException: Exception
    {
        public string LawnId { get; }

        public LawnNotFoundException(string lawnId)
        {
            LawnId = lawnId;
        }
    }
}