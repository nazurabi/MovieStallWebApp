using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VeriErisimKatmani
{
    public class verikatmani
    {
        SqlConnection con;
        SqlCommand cmd;
        public verikatmani()
        {
            con = new SqlConnection(baglantiyolu.baglanti);
            cmd = con.CreateCommand();
        }
        #region Yönetici Metodları
        
        public yonetici yoneticiGirisi(string mail, string sifre) // Textboxlardan gelen mail ve şifre verisini burada alıyoruz.
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail=@mail AND Sifre=@sifre"; // SQL Injectiona karşı burada @ işaretini kullanıp işleme devam ediyoruz.
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail); // Parameters ile Injection a karşı koruma amacıyla verileri bu şekilde ekliyoruz.
                cmd.Parameters.AddWithValue("@sifre", sifre);// Parameters ile Injection a karşı koruma amacıyla verileri bu şekilde ekliyoruz.
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar()); // Olup olmamasını kontrol etme nedenimiz SQL Injectiondan kaçınmak amacıyla aslında çünkü Injection yese bile if kontrolünü aşıp veriyi bulup içinden detayları alamaz, geriye 1 döndürse bile bu sadece bir sayıdan ibaret olur çünkü count varsa işleme devam et deyip if bloğu kullandık yani arka arkaya birkaç kontrol yaptırdık bu nedenle SQL Injection yemesi bu tarz bir düzen için zor olmaktadır.
                if(sayi==1) // Eğer counttan dönen değer 1 ise mail ve şifrenin olduğunu anlayıp işleme devam eder ve gerekli bilgileri veritabanından çeker.
                {
                    cmd.CommandText = "SELECT Y.YntID, Y.YntTurID,YT.Isim,Y.Isim,Y.Soyisim,Y.KullaniciAdi,Y.Mail,Y.Sifre,Y.Durum,Y.Silinmis FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YntTurID=YT.ID WHERE Y.Mail=@mail AND Y.Sifre=@sifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader okuyucu = cmd.ExecuteReader();
                    yonetici Y = new yonetici();
                    while(okuyucu.Read())
                    {
                        Y.YntID = okuyucu.GetInt32(0);
                        Y.YntTurID = okuyucu.GetInt32(1);
                        Y.YntTur = okuyucu.GetString(2);
                        Y.Isim = okuyucu.GetString(3);
                        Y.Soyisim = okuyucu.GetString(4);
                        Y.KullaniciAdi = okuyucu.GetString(5);
                        Y.Mail = okuyucu.GetString(6);
                        Y.Sifre = okuyucu.GetString(7);
                        Y.Durum = okuyucu.GetBoolean(8);
                        Y.Silinmis = okuyucu.GetBoolean(9);
                    }
                    return Y;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir Hata Oluştu" + ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }


        #endregion

    }
}
