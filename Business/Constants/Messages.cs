using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductNameInvalid = "Ürün ismi en az 2 karakter olmalıdır.";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir.";
        public static string ProductAdded = "Ürün başarıyla eklendi.";
        public static string ProductNameAlreadyExist = "Ürünün ismi başka bir ürünle aynı olamaz. Lütfen farklı bir isim giriniz.";
        public static string CategoryLimitExceeded = "Kategori sayısı 15'i geçtiğinden yeni ürün eklenemez.";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kullanıcı kayıt oldu.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string UserAlreadyExists = "Kullanıcı zaten var.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        public static string ProductsListedByCategoryId = "Ürünler, kategoriye göre getirildi.";
    }
}
