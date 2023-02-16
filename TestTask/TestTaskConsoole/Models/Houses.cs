namespace TestTask.Models
{
    public class Houses
    {
        public string name { get; set; }
        public string address { get; set; }
        public int count { get; set; }

        public override string ToString()
        {
            return $"NAME){name}\t|ADDRESS){address}\t|COUNT){count}\n";
        }
    }
}