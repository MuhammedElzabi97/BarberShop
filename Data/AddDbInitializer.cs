using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebProjesi.Data;
using WebProjesi.Models;

namespace WebProjesi
{
    public static class AddDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();


                //kategori

                //if (!context.Kategori.Any())
                //{
                //    context.Kategori.AddRange(
                //        new Kategori { KategoriAdi = "Saç" },
                //        new Kategori { KategoriAdi = "Sakal" },
                //        new Kategori { KategoriAdi = "Cilt" },
                //        new Kategori { KategoriAdi = "Özel Hizmetler" }
                //    );
                //    context.SaveChanges();
                //}

                //Calisan
                //if (!context.Calisanlar.Any())
                //{
                //    context.Calisanlar.AddRange(new List<Calisan>()
                //    {
                //        new Calisan
                //        {
                //            Ad_Soyad = "Ahmet Yılmaz",
                //            BaslangicSaati = new TimeSpan(9, 0, 0), 
                //            BitisSaati = new TimeSpan(18, 0, 0),  
                //            Calisan_Resmi = "ahmet.jpg"
                //        },
                //        new Calisan
                //        {
                //            Ad_Soyad = "Mehmet Kaya",
                //            BaslangicSaati = new TimeSpan(10, 0, 0), // 10:00 صباحًا
                //            BitisSaati = new TimeSpan(19, 0, 0),    // 7:00 مساءً
                //            Calisan_Resmi = "mehmet.jpg"
                //        }
                //    });
                //    context.SaveChanges();
                //}

         

                ////Hizmet

                //if (!context.Hizmetler.Any())
                //{
                //    var kategoriSac = context.Kategori.FirstOrDefault(k => k.KategoriAdi == "Saç");
                //    var kategoriSakal = context.Kategori.FirstOrDefault(k => k.KategoriAdi == "Sakal");

                //    context.Hizmetler.AddRange(
                //        new Hizmet 
                //        {
                //            HizmetAdi = "Saç Kesimi",
                //            Sure = 30, 
                //            Ucret = 50, 
                //            KategoriID = kategoriSac.KategoriID,
                //            Aciklama = "Standart saç kesimi" ,
                //            ImageURL = "https://www.ringmybarber.com/wp-content/uploads/2022/10/qualities-of-a-highly-professional-barber.jpg",
                //            AktifMi = true
                //        },
                //        new Hizmet { HizmetAdi = "Sakal Tıraşı",
                //            Sure = 20, 
                //            Ucret = 30,
                //            KategoriID = kategoriSakal.KategoriID,
                //            Aciklama = "Standart saç kesimi",
                //            ImageURL = "https://www.ringmybarber.com/wp-content/uploads/2022/10/qualities-of-a-highly-professional-barber.jpg",
                //            AktifMi = true
                //        }
                //    );
                //    context.SaveChanges();
                //}

                ////Calisan_Hizmet

                //if (!context.CalisanHizmetler.Any())
                //{
                //    var calisan1 = context.Calisanlar.FirstOrDefault(c => c.Ad_Soyad == "Ahmet Yılmaz");
                //    var hizmet1 = context.Hizmetler.FirstOrDefault(h => h.HizmetAdi == "Saç Kesimi");

                //    context.CalisanHizmetler.AddRange(
                //        new CalisanHizmet { CalisanID = calisan1.CalisanID, HizmetID = hizmet1.HizmetID }
                //    );
                //    context.SaveChanges();
                //}

                    //Rendevu

                    //if (!context.Randevular.Any())
                    //{
                    //    var calisan1 = context.Calisanlar.FirstOrDefault(c => c.Ad_Soyad == "Ahmet Yılmaz");
                    //    var hizmet1 = context.Hizmetler.FirstOrDefault(h => h.HizmetAdi == "Saç Kesimi");

                    //    context.Randevular.AddRange(
                    //        new Randevu
                    //        {
                    //            CalisanID = calisan1.CalisanID,
                    //            HizmetID = hizmet1.HizmetID,
                    //            MusteriAdi = "Ali Veli",
                    //            RandevuTarihi = DateTime.Now.AddHours(2),
                    //            Durum = "Onaylandı",
                    //            Notlar = "İlk ziyaret",
                    //            Ucret = hizmet1.Ucret
                    //        }
                    //    );
                    //    context.SaveChanges();
                    //}






            }
        }
    }
}
