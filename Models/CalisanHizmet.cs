namespace WebProjesi.Models
{
    public class CalisanHizmet
    {
        public int CalisanID { get; set; } 
        public Calisan Calisan { get; set; }

        public int HizmetID { get; set; } 
        public Hizmet Hizmet { get; set; }


    }
}
