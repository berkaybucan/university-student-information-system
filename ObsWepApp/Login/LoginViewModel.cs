using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz.")]
        public string Parola { get; set; }
    }

