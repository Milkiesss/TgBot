using System.ComponentModel.DataAnnotations.Schema;

namespace congrr.Data
{
    public class model
    {
        public int id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string dolzh { get; set; } = string.Empty;
        public string otdel { get; set; } = string.Empty;

    }
}
