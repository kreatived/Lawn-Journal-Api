using System;

namespace LawnJournalApi.Exceptions
{
    public class LawnSectionNotFoundException: Exception
    {
        public string SectionId { get; }

        public LawnSectionNotFoundException(string sectionId)
        {
            SectionId = sectionId;
        }
    }
}