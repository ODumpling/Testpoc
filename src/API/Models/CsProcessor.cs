namespace API.Models
{
    public class CsProcessor
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public int Architecture { get; set; }
        public int AddressWidth { get; set; }
        public int DataWidth { get; set; }
        public int MaxClockSpeed { get; set; }
        public int CurrentClockSpeed { get; set; }
        public int NumberOfCores { get; set; }
        public int NumberOfLogicalProcessors { get; set; }
        public string ProcessorID { get; set; }
        public string SocketDesignation { get; set; }
        public int ProcessorType { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public int CpuStatus { get; set; }
        public int Availability { get; set; }
    }
}