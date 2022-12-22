using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.ISP
{
    public class ISPBestSamples
    {
        // interface seggragation => 
        // bir interface değişmesi için terk bir sebep olmalıdır.
        // Interfaclere fazla sorumlulk verme
        // Modelleme yaparken interfacler bize daha esnek bir yapı sundupundan gereksiz yere içerisinde üye (member) kullanımı projede bazı yerlerde tıknamamıza dummy kullanılmayan kodlar ile çalışmak zorunda kalmamıza neden oluyor.
        
        // Interfaceleri olabildiğince Atomik kullan.

        public interface ISharedKey
        {
            string SharedKey { get; set; }
        }

        public interface IEncryptor
        {
            string Encrypt(string plainText);
        }

        public interface IDecryptor
        {
            string Decrypt(string chipperText);
        }

        public interface ICryptographer : IEncryptor,IDecryptor,ISharedKey
        {

        }

        // AES 
        public class MessageCryptographer : ICryptographer
        {
            public string SharedKey { get; set; } = "xzsdUy32539-asdsad&7";

            public string Decrypt(string chipperText)
            {
                throw new NotImplementedException();
            }

            public string Encrypt(string plainText)
            {
                throw new NotImplementedException();
            }
        }


        // HASH
        public class PasswordCryptographer : IEncryptor, ISharedKey
        {
            public string SharedKey { get; set; }

            public string Encrypt(string plainText)
            {
                throw new NotImplementedException();
            }
        }


        // Mesajlamaşma uygulamaları için uçtan uca mesaj kanalından gidem mesajlar shared Key üzerinden şifrelenmesin sha256 algoritma kullanalım

        // Sistemdeki kullanıclar KVKK kapsamında sistemdeki tüm parolalarını şifrelememiz lazım. HASH => hash geri çözleme



    }
}
