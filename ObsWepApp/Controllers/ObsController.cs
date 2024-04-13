using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ObsWepApp.Models;
using System.Security.Claims;

namespace ObsWepApp.Controllers
{
    
    public class ObsController : Controller
    {
        private readonly ILogger<ObsController> _logger;
        private readonly ObsContext _context;
        public int aktifDonemId = 2;
        public int loginControl = -1;

        public ObsController(ILogger<ObsController> logger, ObsContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        


        [HttpPost]
        public  async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Kullanicis.SingleOrDefault(u => u.KullaniciAdi == model.KullaniciAdi && u.Parola == model.Parola);

                if (user != null)
                {
                    var claims=  new List<Claim>() {
                        new Claim(ClaimTypes.Name,model.KullaniciAdi)
                    };
                    var userIdentity=new ClaimsIdentity(claims,"Login");
                    ClaimsPrincipal principal=new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    
                    
                    // Kullanıcı bulundu, giriş başarılı
                    ViewBag.UserId = user.KullaniciId;
                    ViewBag.UserType = user.KullaniciTuruId;
                    loginControl = user.KullaniciId;
                    TempData["LoginControl"] = loginControl;
                    if (user.KullaniciTuruId == 1)
                    {
                        return RedirectToAction("Ogrenci", new { kullaniciId = user.KullaniciId });
                    }
                    else
                    {
                        return RedirectToAction("Ogrelm", new { kullaniciId = user.KullaniciId });
                    }
                    

                }
                else
                {
                    // Kullanıcı bulunamadı, hata mesajı göster
                    ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlış!";
                    return View();
                }
            }

            return View(model);
        }
        [Authorize]
        public IActionResult Ogrenci(int kullaniciId)
        {
            {
                var tempLoginControl = TempData["LoginControl"];
                if (kullaniciId != Convert.ToInt32(tempLoginControl))
                {
                    return RedirectToAction("Login", "Obs");
                }
                else
                {
                    //Tanımlamalar
                    var ogrId = -1;
                    var ogrAd = "";
                    var ogrSoyad = "";
                    int ogrBolumId = -1;
                    var ogrBolum = "";
                    DateTime ogrKayitTarihi = new DateTime(2000, 1, 1);
                    int ogrElmId = -1;
                    var ogrElmAdi = "";
                    var ogrElmSoyadi = "";
                    var ogrElmUnvanId = -1;
                    var ogrElmUnvan = "";

                    //Öğrenci tablosundan giriş yapanın kullanıcıIdsine göre bilgileri çekiyoruz.
                    #region Öğrenci temel bilgiler
                    var ogrenciBilgisi = _context.Ogrencis
                    .Where(o => o.KullaniciId == kullaniciId)
                    .Select(ogrenci => new
                    {
                        ogrenci.OgrenciId,
                        ogrenci.Adi,
                        ogrenci.Soyadi,
                        ogrenci.KayitTarihi,
                        ogrenci.BolumId
                    })
                    .FirstOrDefault();

                    ogrId = ogrenciBilgisi.OgrenciId;
                    ogrAd = ogrenciBilgisi?.Adi.Trim();
                    ogrSoyad = ogrenciBilgisi?.Soyadi.Trim();
                    ogrBolumId = ogrenciBilgisi.BolumId;
                    ogrKayitTarihi = ogrenciBilgisi.KayitTarihi;
                    #endregion


                    //Bölüm tablosundan ogrBölümIdden bölümü çekiyorum
                    #region öğrenciden bölüm adı öğrenme
                    var bölümBilgisi = _context.Bolums
                    .Where(b => b.BolumId == ogrBolumId)
                    .Select(bolum => new
                    {
                        bolum.BolumAdi

                    })
                    .FirstOrDefault();
                    ogrBolum = bölümBilgisi?.BolumAdi.Trim();
                    #endregion

                    //Danışmanlık tablosundan ÖğrenciId ile ilgili OgrElemanId çekiyorum 
                    #region  danışmanlık tablosundan öğrenciIdden OgrElemanID öğrenme
                    var danismanIdBilgi = _context.Danismanliks
                    .Where(d => d.OgrenciId == ogrId)
                    .Select(ogrEleman => new
                    {
                        ogrEleman.OgrElmId


                    })
                    .FirstOrDefault();
                    ogrElmId = danismanIdBilgi.OgrElmId;
                    #endregion
                    //OgrElemanIdden öğretim elemanı ad soyad unvanId öğrenme
                    #region OgrElemanIdden öğretim elemanı ad soyad unvanId öğrenme
                    var danismanBilgisi = _context.OgretimElemanis
                    .Where(o => o.OgrElmId == ogrElmId)
                    .Select(ogrEleman => new
                    {
                        ogrEleman.Adi,
                        ogrEleman.Soyadi,
                        ogrEleman.UnvanId

                    })
                    .FirstOrDefault();
                    ogrElmAdi = danismanBilgisi?.Adi.Trim();
                    ogrElmSoyadi = danismanBilgisi?.Soyadi.Trim();
                    ogrElmUnvanId = danismanBilgisi.UnvanId;
                    #endregion

                    //unvanIdden danışmanın ünvanını öğrenme
                    #region unvanIdden danışmanın ünvanını öğrenme
                    var unvanBilgisi = _context.Unvans
                    .Where(u => u.UnvanId == ogrElmUnvanId)
                    .Select(unvan => new
                    {
                        unvan.UnvanAdi

                    }).FirstOrDefault();
                    ogrElmUnvan = unvanBilgisi.UnvanAdi.Trim();

                    #endregion

                    //sınıf hesaplama
                    #region sinifhesaplama
                    DateTime bugununTarihi = DateTime.Today;

                    static int BugunleYilFarki(DateTime bugun, DateTime digerTarih)
                    {
                        // Yıl farkını hesapla
                        int yilFarki = bugun.Year - digerTarih.Year;

                        // Eğer bugünün ay ve günü, diğer tarihten önce ise bir yıl çıkar
                        if (bugun.Month < digerTarih.Month || (bugun.Month == digerTarih.Month && bugun.Day < digerTarih.Day))
                        {
                            yilFarki--;
                        }

                        return yilFarki;
                    }
                    int yilFarki = BugunleYilFarki(bugununTarihi, ogrKayitTarihi) + 1;

                    #endregion




                    ViewBag.OgrenciAdi = ogrAd;
                    ViewBag.OgrenciSoyadi = ogrSoyad;
                    ViewBag.BolumAdi = ogrBolum;
                    ViewBag.KayitTarihi = ogrKayitTarihi.ToString().Substring(0, 10);
                    ViewBag.Sinif = yilFarki;
                    ViewBag.DanismanAdi = ogrElmAdi;
                    ViewBag.DanismanSoyadi = ogrElmSoyadi;
                    ViewBag.DanismanUnvan = ogrElmUnvan;






                    return View();
                }
            }
            
        }
        [Authorize]
        public IActionResult Ogrelm(int kullaniciId)
        {
            {
                var tempLoginControl = TempData["LoginControl"];
                if (kullaniciId != Convert.ToInt32(tempLoginControl))
                {
                    return RedirectToAction("Login", "Obs");
                }
                else
                {
                    


                    return View();
                }
            }

        }
    }
}
