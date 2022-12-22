using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.ISP
{
    public class ISPBadSamples
    {
        // interface seggragation => 
        // bir interface değişmesi için terk bir sebep olmalıdır.
        // Interfaclere fazla sorumlulk verme
        // Modelleme yaparken interfacler bize daha esnek bir yapı sundupundan gereksiz yere içerisinde üye (member) kullanımı projede bazı yerlerde tıknamamıza dummy kullanılmayan kodlar ile çalışmak zorunda kalmamıza neden oluyor. 

        public interface ICryptographer 
        {
            string SharedKey { get; set; }

            string Encrypt(string plainText);
            string Decrypt(string chipperText);
        }

        // AES simetik şifreleme algoritması (şifrelenir ve çözülür)
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

        // HASH algoritması (şifre çözülemez)
        public class PasswordCryptographer : ICryptographer
        {
            public string SharedKey { get; set; }

            /// <summary>
            /// Bu methodu çağırma Hash algoritması olduğunda bu method boşa düştü
            /// </summary>
            /// <param name="chipperText"></param>
            /// <returns></returns>
            public string Decrypt(string chipperText)
            {
                throw new NotImplementedException();
            }

           
            public string Encrypt(string plainText)
            {
                throw new NotImplementedException();
            }
        }


        // Mesajlamaşma uygulamaları için uçtan uca mesaj kanalından gidem mesajlar shared Key üzerinden şifrelenmesin sha256 algoritma kullanalım

        // Sistemdeki kullanıclar KVKK kapsamında sistemdeki tüm parolalarını şifrelememiz lazım. HASH => hash geri çözleme



    }
}
