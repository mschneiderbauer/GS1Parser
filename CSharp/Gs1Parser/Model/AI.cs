using System;

namespace Gs1Parser
{
    public class AI
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int LengthOfAI { get; set; }
        public DataType DataDescription { get; set; }
        public int LengthOfData { get; set; }
        public bool GroupSeparatorPresent { get; set; }
        public int NumberOfDecimals { get; set; } // determined in parsing

        public AI(string ai, string description, DataType dataDescription, int lengthOfData, bool groupSeparatorPresent)
        {
            this.Id = ai;
            this.Description = description;
            this.LengthOfAI = ai.Length;
            this.DataDescription = dataDescription;
            this.LengthOfData = lengthOfData;
            this.GroupSeparatorPresent = groupSeparatorPresent;
        }

        public override string ToString()
        {
            return String.Format("{0} [{1}]", Id, Description);
        }
    }
}
