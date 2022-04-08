using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public const string Added = "Başarıyla eklendi";
        public const string Updated = "Başarıyla güncellendi";
        public const string Deleted = "Başarıyla silindi";
        public const string Geted = "Data başarıyla getirildi";
        public const string Listed = "Data başarıyla listelendi";

        public const string TheCarHasNotBeenDeliveredYet = "Araba henüz teslim edilmedi";
        public const string TheImageLimitForThisCarHasBeenExceeded = "Bu araba için daha fazla resim eklenemez";
        public const string EmailNotFound = "Email bulunamadı";
        public const string PasswordIsIncorrect = "Şifre yanlış";
        public const string LoginSuccessful = "Giriş başarılı";
        public const string EmailIsAlreadyRegistered = "Email zaten kayıtlı";
        public const string RegistrationSuccessful = "Kayıt başarılı";
        public const string TokenCreated = "Token başarı ile oluşturuldu";
        public const string NotAuthorized = "Yetkiniz yok";
    }
}
