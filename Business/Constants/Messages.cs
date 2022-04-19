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

        public const string ThisCarHasNotBeenReturnedYet = "Bu araba henüz teslim edilmedi";
        public const string ImageLimitForThisCarHasBeenExceeded = "Bu araba için daha fazla resim eklenemez";
        public const string EmailNotFound = "Email bulunamadı";
        public const string PasswordIsIncorrect = "Şifre yanlış";
        public const string LoginSuccessful = "Giriş başarılı";
        public const string EmailIsAlreadyRegistered = "Email zaten kayıtlı";
        public const string RegistrationSuccessful = "Kayıt başarılı";
        public const string TokenCreated = "Token başarı ile oluşturuldu";
        public const string NotAuthorized = "Yetkiniz yok";
        public const string PaymentSuccessful = "Ödeme işlemi başarılı";
        public const string ThisCarIsAlreadyRentedInSelectedDateRange = "Bu araba seçilen tarih aralığında zaten kiralanmış";
        public const string ReturnDateCannotBeLeftBlankAsThisCarWasAlsoRentedAtALaterDate = "Bu araç, daha sonraki bir tarihte kiralanmış olduğu için teslim tarihi boş bırakılamaz";
        public const string ReturnDateCannotBeEarlierThanRentDate = "Teslim tarihi, kiralama tarihinden daha önce olamaz";
        public const string RentalDateCannotBeBeforeToday = "Geçmişe araba kiralayamazsın :)";
        public const string RentalSuccessful = "Kiralama işlemi başarılı";
        public const string CustomerFindeksPointIsNotEnoughForThisCar = "Findeks puanınız bu araba için yeterli değil";
        public const string ThisCardIsAlreadyRegisteredForThisCustomer = "Bu kart, bu müşteri için zaten kayıtlı";
        public const string PaymentInformationSuccessfullySaved = "Ödeme bilgileri başarıyla kayıt edildi";
        public const string PasswordsDoNotMatch = "Şifreler uyuşmuyor";
        public const string LastTwoDigitsOfYearMustBeEntered = "Yılın sadece son 2 hanesi girilmelidir";
        public const string EmailUpdated = "Email başarıyla güncellendi";
        public const string FirstAndLastNameUpdated = "Ad ve Soyad başarıyla güncellendi";
        public const string PasswordUpdated = "Şifre başarıyla güncellendi";
        public const string ModelYearMustBeEnteredAsFourCharacters = "Model yılı 4 karakter olarak girilmelidir";
        public const string CardNumberMustConsistOfLettersOnly = "Kart numarası sadece harflerden oluşmalıdır";
    }
}
