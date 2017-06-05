namespace Sign.Models.Business
{
public   class Beneficiary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }

        public string Contract { get; set; }

        public string Note { get; set; }
    }
}
