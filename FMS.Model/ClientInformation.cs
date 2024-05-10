namespace FMS.Model
{
    public class ClientInformation
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public byte[] Logo { get; set; } 
        public string Slogan { get; set; }
        public string PostalAddress { get; set; }  
        public string BusinessAddress { get; set; }
        public string Telephone { get; set; }
        public string Facsimile { get; set; }
        public string Email { get; set; } 
        public string Website { get; set; }
    }
}
