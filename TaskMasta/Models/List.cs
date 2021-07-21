namespace TaskMasta.Models
{
    public class List
    {
        public int Id {get;set;}
        public string ListName {get; set;}
        public string CreatorId {get;set;}
         
         public Profile Profile {get; set;}
    }
}