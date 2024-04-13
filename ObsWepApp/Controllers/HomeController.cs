using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using ObsWepApp.Models;
using System.Diagnostics;

namespace ObsWepApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ObsContext _context;
        int kullaniciId=-1;

        public HomeController(ILogger<HomeController> logger, ObsContext context)
        {
            _logger = logger;
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    //Tanımlamalar
        //    var ogrId = -1;
        //    var ogrAd = "";
        //    var ogrSoyad = "";
        //    int ogrBolumId = -1;
        //    var ogrBolum = "";
        //    DateTime ogrKayitTarihi = new DateTime(2000, 1, 1); 
        //    int ogrElmId = -1;
        //    var ogrElmAdi = "";
        //    var ogrElmSoyadi = "";
        //    var ogrElmUnvanId = -1;
        //    var ogrElmUnvan = "";

        //    //Öğrenci tablosundan giriş yapanın kullanıcıIdsine göre bilgileri çekiyoruz.
        //    #region Öğrenci temel bilgiler
        //    var ogrenciBilgisi = _context.Ogrencis
        //    .Where(o => o.KullaniciId == 1)
        //    .Select(ogrenci => new
        //    {
        //        ogrenci.OgrenciId,
        //        ogrenci.Adi,
        //        ogrenci.Soyadi,
        //        ogrenci.KayitTarihi,
        //        ogrenci.BolumId
        //    })
        //    .FirstOrDefault();

        //    ogrId = ogrenciBilgisi.OgrenciId;
        //    ogrAd = ogrenciBilgisi?.Adi.Trim();
        //    ogrSoyad = ogrenciBilgisi?.Soyadi.Trim();
        //    ogrBolumId = ogrenciBilgisi.BolumId;
        //    ogrKayitTarihi = ogrenciBilgisi.KayitTarihi;
        //    #endregion


        //    //Bölüm tablosundan ogrBölümIdden bölümü çekiyorum
        //    #region öğrenciden bölüm adı öğrenme
        //    var bölümBilgisi = _context.Bolums
        //    .Where(b => b.BolumId == ogrBolumId)
        //    .Select(bolum => new
        //    {
        //        bolum.BolumAdi

        //    })
        //    .FirstOrDefault();
        //    ogrBolum = bölümBilgisi?.BolumAdi.Trim();
        //    #endregion

        //    //Danışmanlık tablosundan ÖğrenciId ile ilgili OgrElemanId çekiyorum 
        //    #region  danışmanlık tablosundan öğrenciIdden OgrElemanID öğrenme
        //    var danismanIdBilgi = _context.Danismanliks
        //    .Where(d => d.OgrenciId == ogrId)
        //    .Select(ogrEleman => new
        //    {
        //        ogrEleman.OgrElmId


        //    })
        //    .FirstOrDefault();
        //    ogrElmId = danismanIdBilgi.OgrElmId;
        //    #endregion
        //    //OgrElemanIdden öğretim elemanı ad soyad unvanId öğrenme
        //    #region OgrElemanIdden öğretim elemanı ad soyad unvanId öğrenme
        //    var danismanBilgisi = _context.OgretimElemanis
        //    .Where(o => o.OgrElmId == ogrElmId)
        //    .Select(ogrEleman => new
        //    {
        //        ogrEleman.Adi,
        //        ogrEleman.Soyadi,
        //        ogrEleman.UnvanId

        //    })
        //    .FirstOrDefault();
        //    ogrElmAdi = danismanBilgisi?.Adi.Trim();
        //    ogrElmSoyadi = danismanBilgisi?.Soyadi.Trim();
        //    ogrElmUnvanId = danismanBilgisi.UnvanId;
        //    #endregion

        //    //unvanIdden danışmanın ünvanını öğrenme
        //    #region unvanIdden danışmanın ünvanını öğrenme
        //    var unvanBilgisi = _context.Unvans
        //    .Where(u => u.UnvanId == ogrElmUnvanId)
        //    .Select(unvan => new
        //    {
        //        unvan.UnvanAdi

        //    }).FirstOrDefault();
        //    ogrElmUnvan = unvanBilgisi.UnvanAdi.Trim();

        //    #endregion

        //    //sınıf hesaplama
        //    #region sinifhesaplama
        //    DateTime bugununTarihi = DateTime.Today;

        //    static int BugunleYilFarki(DateTime bugun, DateTime digerTarih)
        //    {
        //        // Yıl farkını hesapla
        //        int yilFarki = bugun.Year - digerTarih.Year;

        //        // Eğer bugünün ay ve günü, diğer tarihten önce ise bir yıl çıkar
        //        if (bugun.Month < digerTarih.Month || (bugun.Month == digerTarih.Month && bugun.Day < digerTarih.Day))
        //        {
        //            yilFarki--;
        //        }

        //        return yilFarki;
        //    }
        //    int yilFarki = BugunleYilFarki(bugununTarihi, ogrKayitTarihi)+1;

        //    #endregion




        //    ViewBag.OgrenciAdi = ogrAd;
        //    ViewBag.OgrenciSoyadi = ogrSoyad;
        //    ViewBag.BolumAdi = ogrBolum;
        //    ViewBag.KayitTarihi = ogrKayitTarihi.ToString().Substring(0, 10);
        //    ViewBag.Sinif = yilFarki;
        //    ViewBag.DanismanAdi = ogrElmAdi;
        //    ViewBag.DanismanSoyadi = ogrElmSoyadi;
        //    ViewBag.DanismanUnvan = ogrElmUnvan;






        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}