using System;

namespace TodoList.Data.Entities
{
    public class Affair
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Annotation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
