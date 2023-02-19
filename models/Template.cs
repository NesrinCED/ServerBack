namespace Server.models
{
    public class Template
    {
            
        public Guid Id{ get; set; }
        public string Name { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
        public string Project { get; set; } = string.Empty;

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
        /*       get { return ModifiedDate; }
    set
            {
                ModifiedDate = DateTime.Now;
            }*/

    }
}

