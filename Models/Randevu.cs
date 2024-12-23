public class Randevu
{
    public int RandevuId { get; set; } // PK
    public DateTime Tarih { get; set; }
    public string Saat { get; set; }

    public int HizmetId { get; set; } // FK
    public Hizmet Hizmet { get; set; }

    public int CalisanId { get; set; } // FK
    public Calisan Calisan { get; set; }

    public int KullaniciId { get; set; } // FK
    public Kullanici Kullanici { get; set; }
}

