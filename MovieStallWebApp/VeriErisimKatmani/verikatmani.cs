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
                if (sayi == 1) // Eğer counttan dönen değer 1 ise mail ve şifrenin olduğunu anlayıp işleme devam eder ve gerekli bilgileri veritabanından çeker.
                {
                    cmd.CommandText = "SELECT Y.YntID, Y.YntTurID,YT.Isim,Y.Isim,Y.Soyisim,Y.KullaniciAdi,Y.Mail,Y.Sifre,Y.Durum,Y.Silinmis FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YntTurID=YT.ID WHERE Y.Mail=@mail AND Y.Sifre=@sifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader okuyucu = cmd.ExecuteReader();
                    yonetici Y = new yonetici();
                    while (okuyucu.Read())
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

        #region Kategori Metodları

        public bool kategoriEkle(kategori K)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES(@kategoriIsmi,@durum,@silinmis)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriIsmi", K.KategoriIsmi);
                cmd.Parameters.AddWithValue("@durum", K.Durum);
                cmd.Parameters.AddWithValue("@silinmis", K.Silinmis);
                con.Open();
                cmd.ExecuteNonQuery();
                return true; ;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir Hata Oluştu" + ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        //public List<kategori> kategoriListele()
        //{
        //    List<kategori> kategoriler = new List<kategori>();
        //    try
        //    {
        //        cmd.CommandText = "SELECT KategoriID,KategoriIsmi,Durum,Silinmis FROM Kategoriler";
        //        cmd.Parameters.Clear();
        //        con.Open();
        //        SqlDataReader okuyucu = cmd.ExecuteReader();
        //        while (okuyucu.Read())
        //        {
        //            kategori ktgr = new kategori();
        //            ktgr.KategoriID = okuyucu.GetInt32(0);
        //            ktgr.KategoriIsmi = okuyucu.GetString(1);
        //            ktgr.Durum = okuyucu.GetBoolean(2);
        //            ktgr.Silinmis = okuyucu.GetBoolean(3);
        //            kategoriler.Add(ktgr);
        //        }
        //        return kategoriler;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Bir Hata Oluştu" + ex);
        //        return null;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        public List<kategori> kategoriListele(bool silinmis)
        {
            List<kategori> kategoriler = new List<kategori>();
            try
            {
                cmd.CommandText = "SELECT KategoriID,KategoriIsmi,Durum,Silinmis FROM Kategoriler WHERE Silinmis=@Silinmis";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Silinmis", silinmis);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    kategori ktgr = new kategori();
                    ktgr.KategoriID = okuyucu.GetInt32(0);
                    ktgr.KategoriIsmi = okuyucu.GetString(1);
                    ktgr.Durum = okuyucu.GetBoolean(2);
                    ktgr.Silinmis = okuyucu.GetBoolean(3);
                    kategoriler.Add(ktgr);
                }
                return kategoriler;
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

        //public List<kategori> kategoriListele(bool silinmis, bool durum)
        //{
        //    List<kategori> kategoriler = new List<kategori>();
        //    try
        //    {
        //        cmd.CommandText = "SELECT KategoriID,KategoriIsmi,Durum,Silinmis FROM Kategoriler WHERE Silinmis=@Silinmis AND Durum=@durum";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@Silinmis", silinmis);
        //        cmd.Parameters.AddWithValue("@Durum", durum);
        //        con.Open();
        //        SqlDataReader okuyucu = cmd.ExecuteReader();
        //        while (okuyucu.Read())
        //        {
        //            kategori ktgr = new kategori();
        //            ktgr.KategoriID = okuyucu.GetInt32(0);
        //            ktgr.KategoriIsmi = okuyucu.GetString(1);
        //            ktgr.Durum = okuyucu.GetBoolean(2);
        //            ktgr.Silinmis = okuyucu.GetBoolean(3);
        //            kategoriler.Add(ktgr);
        //        }
        //        return kategoriler;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Bir Hata Oluştu" + ex);
        //        return null;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}
        public void kategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Silinmis=1 WHERE KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public void kategoriDuzenle(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Kategoriler WHERE KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Kategoriler SET Durum=@durum WHERE KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@durum", !durum);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
            finally
            {

                con.Close();
            }
        }
        public void kategoriSilinmisGeriAl(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Silinmis FROM Kategoriler WHERE KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool silinmis = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Kategoriler SET Silinmis=@silinmis WHERE KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@silinmis", !silinmis);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                con.Close();
            }
        }
        public kategori kategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT KategoriID,KategoriIsmi,Durum,Silinmis FROM Kategoriler WHERE KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                kategori ktgr = new kategori();
                while (okuyucu.Read())
                {
                    ktgr.KategoriID = okuyucu.GetInt32(0);
                    ktgr.KategoriIsmi = okuyucu.GetString(1);
                    ktgr.Durum = okuyucu.GetBoolean(2);
                    ktgr.Silinmis = okuyucu.GetBoolean(3);
                }
                return ktgr;
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
        public bool kategoriGuncelle(kategori K)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET KategoriIsmi=@isim,Durum=@durum WHERE KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", K.KategoriID);
                cmd.Parameters.AddWithValue("@isim", K.KategoriIsmi);
                cmd.Parameters.AddWithValue("@durum", K.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir Hata Oluştu" + ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Tür Metodu

        public List<tur> turListele()
        {
            List<tur> turler = new List<tur>();
            try
            {
                cmd.CommandText = "SELECT TurID,TurIsmi FROM Turler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    tur tr = new tur();
                    tr.TurID = okuyucu.GetInt32(0);
                    tr.TurIsmi = okuyucu.GetString(1);
                    turler.Add(tr);
                }
                return turler;
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

        #region Eser Metodları

        public bool eserEkle(eser E)
        {
            try
            {
                cmd.CommandText = "INSERT INTO EserBilgisi(TurIDFK,Isim,Yil,ImdbPuani,VizyonTarihi,Konusu,GoruntulemeSayisi,KapakResmi) VALUES(@turIDFK,@isim,@yil,@imdbPuani,@vizyonTarihi,@konusu,@goruntulemeSayisi,@kapakResmi)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@turIDFK", E.TurIDFK);
                //cmd.Parameters.AddWithValue("@turIsmi", E.TurIsmi);
                //cmd.Parameters.AddWithValue("@kategoriIDFK", E.KategoriIDFK);
                //cmd.Parameters.AddWithValue("@kategoriIsmi",E.KategoriIsmi );
                cmd.Parameters.AddWithValue("@isim", E.Isim);
                cmd.Parameters.AddWithValue("@yil", E.Yil);
                cmd.Parameters.AddWithValue("@imdbPuani", E.ImdbPuani);
                cmd.Parameters.AddWithValue("@vizyonTarihi", E.VizyonTarihi);
                cmd.Parameters.AddWithValue("@konusu", E.Konusu);
                //cmd.Parameters.AddWithValue("@oyuncular", E.Oyuncular);
                //cmd.Parameters.AddWithValue("@yonetmen", E.Yonetmen);
                cmd.Parameters.AddWithValue("@goruntulemeSayisi", E.GoruntulemeSayisi);
                cmd.Parameters.AddWithValue("@kapakResmi", E.KapakResmi);
                con.Open();
                cmd.ExecuteNonQuery();
                return true; ;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir Hata Oluştu" + ex);
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        //public List<eser> eserListele()
        //{
        //    List<eser> eserler = new List<eser>();
        //    try
        //    {

        //        cmd.CommandText = "SELECT EserBilgisiID ,TurIDFK ,KategoriIDFK ,E.Isim ,Yil ,ImdbPuani ,VizyonTarihi ,Konusu ,Oyuncular ,Yonetmen ,GoruntulemeSayisi ,KapakResmi ,Yorum , MovieStallPuani , EklemeTarihi ,KullaniciAdi ,Avatar FROM EserBilgisi AS E LEFT JOIN Yorumlar AS Y ON E.EserBilgisiID= Y.EserBilgisiIDFK LEFT JOIN Uyeler AS U ON U.UyeID= Y.UyeIDFK";
        yukarıyı düzenle burada kaldım 28.10.2024


        //        cmd.Parameters.Clear();
        //        con.Open();
        //        SqlDataReader okuyucu = cmd.ExecuteReader();
        //        while (okuyucu.Read())
        //        {
        //            eser E = new eser();
        //            E.EserBilgisiID = okuyucu.GetInt32(0);
        //            E.TurIDFK = okuyucu.GetInt32(1);
        //            E.TurIsmi = okuyucu.GetInt32(2);
        //            E.Isim = okuyucu.GetString(3);
        //            E.Yil = okuyucu.GetString(4);
        //            E.ImdbPuani = okuyucu.GetString(5);
        //            E.VizyonTarihi = okuyucu.GetString(6);
        //            E.Konusu = okuyucu.GetString(7);
        //            E.GoruntulemeSayisi = okuyucu.GetInt64(10);
        //            E.KapakResmi = okuyucu.GetString(11);
        //     
        //            eserler.Add(E);
        //        }
        //        return eserler;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Bir Hata Oluştu" + ex);
        //        return null;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}


        #endregion
    }
}
