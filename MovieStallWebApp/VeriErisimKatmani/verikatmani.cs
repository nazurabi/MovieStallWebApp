using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Policy;

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


        public bool yoneticiEkle(yonetici Y)
        {
            try
            {
                cmd.CommandText = " INSERT INTO Yoneticiler(YntTurID, Isim, Soyisim, KullaniciAdi, Mail, Sifre, Durum, Silinmis) VALUES(@yntTur, @isim, @soyisim, @kullaniciAdi, @mail, @sifre, @durum, @silinmis)";

                cmd.Parameters.Clear();
               
                cmd.Parameters.AddWithValue("@yntTur", Y.YntTurID);
                cmd.Parameters.AddWithValue("@isim", Y.Isim);
                cmd.Parameters.AddWithValue("@soyisim", Y.Soyisim);
                cmd.Parameters.AddWithValue("@kullaniciAdi", Y.KullaniciAdi);
                cmd.Parameters.AddWithValue("@mail", Y.Mail);
                cmd.Parameters.AddWithValue("@sifre", Y.Sifre);
                cmd.Parameters.AddWithValue("@durum", Y.Durum);
                cmd.Parameters.AddWithValue("@silinmis", Y.Silinmis);
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

        public List<yonetici> yoneticiListele()
        {
            List<yonetici> yoneticiler = new List<yonetici>();
            try
            {

                cmd.CommandText = "SELECT YntID ,YntTurID, YT.Isim, Y.Isim, Soyisim, KullaniciAdi, Mail, Sifre, Durum, Silinmis  FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YntTurID= YT.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    yonetici Y = new yonetici();
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

                    yoneticiler.Add(Y);
                }
                return yoneticiler;
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

        public void yoneticiSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Yoneticiler WHERE YntID=@id";
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

        public yonetici yoneticiGetir(int id)
        {
            try
            {

                cmd.CommandText = "SELECT YntTurID, YT.Isim, Y.Isim, Soyisim, KullaniciAdi, Mail, Sifre, Durum, Silinmis  FROM Yoneticiler AS Y JOIN YoneticiTurleri AS YT ON Y.YntTurID= YT.ID WHERE YntTurID=@yntTurID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@yntTurID", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                yonetici Y = new yonetici();
                while (okuyucu.Read())
                {
                    Y.YntTurID = okuyucu.GetInt32(0);
                    Y.YntTur = okuyucu.GetString(1);
                    Y.Isim = okuyucu.GetString(2);
                    Y.Soyisim = okuyucu.GetString(3);
                    Y.KullaniciAdi = okuyucu.GetString(4);
                    Y.Mail = okuyucu.GetString(5);
                    Y.Sifre = okuyucu.GetString(6);
                    Y.Durum = okuyucu.GetBoolean(7);
                    Y.Silinmis = okuyucu.GetBoolean(8);
                }
                return Y;
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

        public bool yoneticiGuncelle(yonetici Y)
        {
            try
            {
                cmd.CommandText = "UPDATE Yoneticiler SET Isim=@isim, Soyisim=@soyisim, KullaniciAdi=@kullaniciAdi, Mail=@mail, Sifre=@sifre, Durum=@durum, Silinmis=@silinmis WHERE YntID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", Y.Isim);
                cmd.Parameters.AddWithValue("@soyisim", Y.Soyisim);
                cmd.Parameters.AddWithValue("@kullaniciAdi", Y.KullaniciAdi);
                cmd.Parameters.AddWithValue("@mail", Y.Mail);
                cmd.Parameters.AddWithValue("@sifre", Y.Sifre);
                cmd.Parameters.AddWithValue("@durum", Y.Durum);
                cmd.Parameters.AddWithValue("@silinmis", Y.Silinmis);
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
                    if (ktgr.Durum)
                    {
                        ktgr.YayinDurumGostergesi = "Yayında";
                    }
                    else
                    {
                        ktgr.YayinDurumGostergesi = "Yayında Değil";
                    }
                    ktgr.Silinmis = okuyucu.GetBoolean(3);
                    if (ktgr.Silinmis)
                    {
                        ktgr.SilinmisDurumGostergesi = "Kategori Silinmiş";
                    }
                    else
                    {
                        ktgr.SilinmisDurumGostergesi = "Kategori Aktif";
                    }

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

        public List<eser> kategoriyeAitFilmleriListele(int id)
        {
            List<eser> eserler = new List<eser>();
            try
            {

                cmd.CommandText = "SELECT E.EserBilgisiID, T.TurIsmi, E.Isim, E.Yil, E.ImdbPuani, E.VizyonTarihi, E.Konusu, E.KapakResmi, E.YayinDurum, KF.KEserID, E.GoruntulemeSayisi FROM EserBilgisi AS E JOIN Turler AS T ON E.TurIDFK=T.TurID JOIN KategoriyeAitFilmler AS KF ON E.EserBilgisiID= KF.EserBilgisiIDFK WHERE KF.KategoriIDFK=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    eser E = new eser();
                    E.EserBilgisiID = okuyucu.GetInt32(0);
                    E.TurIsmi = okuyucu.GetString(1);
                    E.Isim = okuyucu.GetString(2);
                    E.Yil = okuyucu.GetString(3);
                    E.ImdbPuani = okuyucu.GetString(4);
                    E.VizyonTarihi = okuyucu.GetString(5);
                    E.Konusu = okuyucu.GetString(6).Substring(0, 200) + "...";
                    E.KapakResmi = okuyucu.GetString(7);
                    E.YayinDurum = okuyucu.GetBoolean(8);
                    E.KEserID = okuyucu.GetInt32(9);
                    E.GoruntulemeSayisi = okuyucu.GetInt64(10);
                    if (E.YayinDurum)
                    {
                        E.YayinDurumGostergesi = "Yayında";
                    }
                    else
                    {
                        E.YayinDurumGostergesi = "Yayında Değil";
                    }
                    eserler.Add(E);
                }
                return eserler;
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

        public List<eser> kategoriyeAitFilmleriListele(int id, bool secim)
        {
            List<eser> eserler = new List<eser>();
            try
            {

                cmd.CommandText = "SELECT E.EserBilgisiID, T.TurIsmi, E.Isim, E.Yil, E.ImdbPuani, E.VizyonTarihi, E.Konusu, E.KapakResmi, E.YayinDurum, KF.KEserID, E.GoruntulemeSayisi FROM EserBilgisi AS E JOIN Turler AS T ON E.TurIDFK=T.TurID JOIN KategoriyeAitFilmler AS KF ON E.EserBilgisiID= KF.EserBilgisiIDFK WHERE KF.KategoriIDFK=@id AND E.YayinDurum=@secim";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@secim", secim);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    eser E = new eser();
                    E.EserBilgisiID = okuyucu.GetInt32(0);
                    E.TurIsmi = okuyucu.GetString(1);
                    E.Isim = okuyucu.GetString(2);
                    E.Yil = okuyucu.GetString(3);
                    E.ImdbPuani = okuyucu.GetString(4);
                    E.VizyonTarihi = okuyucu.GetString(5);
                    E.Konusu = okuyucu.GetString(6).Substring(0, 200) + "...";
                    E.KapakResmi = okuyucu.GetString(7);
                    E.YayinDurum = okuyucu.GetBoolean(8);
                    E.KEserID = okuyucu.GetInt32(9);
                    E.GoruntulemeSayisi = okuyucu.GetInt64(10);
                    if (E.YayinDurum)
                    {
                        E.YayinDurumGostergesi = "Yayında";
                    }
                    else
                    {
                        E.YayinDurumGostergesi = "Yayında Değil";
                    }
                    eserler.Add(E);
                }
                return eserler;
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

        public bool kategoriyeFilmEkle(kategoriyeaitfilmler KF)
        {
            try
            {
                cmd.CommandText = "INSERT INTO KategoriyeAitFilmler(KategoriIDFK,EserBilgisiIDFK) VALUES(@kategoriIDFK,@eserBilgisiIDFK)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriIDFK", KF.KategoriIDFK);
                cmd.Parameters.AddWithValue("@eserBilgisiIDFK", KF.EserBilgisiIDFK);

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

        public void kategoridenFilmSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM KategoriyeAitFilmler WHERE KEserID=@id";
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

        public List<eser> tureAitKategorileriListele(int id)
        {
            List<eser> eserler = new List<eser>();
            try
            {
                //E.YayinDurum, KF.KEserID,
                cmd.CommandText = "SELECT E.EserBilgisiID, KF.KategoriIDFK, E.TurIDFK, T.TurIsmi, KTGR.KategoriIsmi, E.Isim, E.Yil, E.ImdbPuani, E.VizyonTarihi, E.Konusu, E.KapakResmi FROM EserBilgisi AS E JOIN Turler AS T ON E.TurIDFK=T.TurID JOIN KategoriyeAitFilmler AS KF ON E.EserBilgisiID= KF.EserBilgisiIDFK JOIN Kategoriler AS KTGR ON KTGR.KategoriID= KF.KategoriIDFK WHERE E.TurIDFK=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    eser E = new eser();
                    E.EserBilgisiID = okuyucu.GetInt32(0);
                    E.KategoriIDFK = okuyucu.GetInt32(1);
                    E.TurIDFK = okuyucu.GetInt32(2);
                    E.TurIsmi = okuyucu.GetString(3);
                    E.KategoriIsmi = okuyucu.GetString(4);
                    E.Isim = okuyucu.GetString(5);
                    E.Yil = okuyucu.GetString(6);
                    E.ImdbPuani = okuyucu.GetString(7);
                    E.VizyonTarihi = okuyucu.GetString(8);
                    E.Konusu = okuyucu.GetString(9).Substring(0, 200) + "...";
                    E.KapakResmi = okuyucu.GetString(10);

                    //E.YayinDurum = okuyucu.GetBoolean(8);
                    //E.KEserID = okuyucu.GetInt32(9);

                    if (E.YayinDurum)
                    {
                        E.YayinDurumGostergesi = "Yayında";
                    }
                    else
                    {
                        E.YayinDurumGostergesi = "Yayında Değil";
                    }
                    eserler.Add(E);
                }
                return eserler;
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

        public void sonSecilenGuncelle(int secim)
        {
            try
            {
                cmd.CommandText = "UPDATE SecilenTur SET SonSecilen=@secim";
                cmd.Parameters.Clear();
                con.Open();
                cmd.Parameters.AddWithValue("@secim", secim);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public secilenTur sonSecilenGetir()
        {
            try
            {
                cmd.CommandText = "SELECT SonSecilen FROM SecilenTur";
                cmd.Parameters.Clear();
                con.Open();
                secilenTur ST = new secilenTur();
                ST.SonSecilen = Convert.ToInt32(cmd.ExecuteScalar());
                return ST;
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
                cmd.CommandText = "INSERT INTO EserBilgisi(TurIDFK,Isim,Yil,ImdbPuani,VizyonTarihi,Konusu,GoruntulemeSayisi,KapakResmi,YayinDurum) VALUES(@turIDFK,@isim,@yil,@imdbPuani,@vizyonTarihi,@konusu,@goruntulemeSayisi,@kapakResmi,@yayinDurum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@turIDFK", E.TurIDFK);
                cmd.Parameters.AddWithValue("@isim", E.Isim);
                cmd.Parameters.AddWithValue("@yil", E.Yil);
                cmd.Parameters.AddWithValue("@imdbPuani", E.ImdbPuani);
                cmd.Parameters.AddWithValue("@vizyonTarihi", E.VizyonTarihi);
                cmd.Parameters.AddWithValue("@konusu", E.Konusu);
                cmd.Parameters.AddWithValue("@goruntulemeSayisi", E.GoruntulemeSayisi);
                cmd.Parameters.AddWithValue("@kapakResmi", E.KapakResmi);
                cmd.Parameters.AddWithValue("@yayinDurum", E.YayinDurum);
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

        public List<eser> eserListele(bool yayindurum)
        {
            List<eser> eserler = new List<eser>();
            try
            {

                cmd.CommandText = "SELECT EserBilgisiID ,TurIDFK ,T.TurIsmi ,E.Isim ,Yil ,ImdbPuani ,VizyonTarihi ,Konusu ,GoruntulemeSayisi ,KapakResmi, DuzenlenmeTarihi, YayinDurum FROM EserBilgisi AS E JOIN Turler AS T ON E.TurIDFK= T.TurID WHERE YayinDurum=@yayinDurum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@yayinDurum", yayindurum);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    eser E = new eser();
                    E.EserBilgisiID = okuyucu.GetInt32(0);
                    E.TurIDFK = okuyucu.GetInt32(1);
                    E.TurIsmi = okuyucu.GetString(2);
                    E.Isim = okuyucu.GetString(3);
                    E.Yil = okuyucu.GetString(4);
                    E.ImdbPuani = okuyucu.GetString(5);
                    E.VizyonTarihi = okuyucu.GetString(6);
                    E.Konusu = okuyucu.GetString(7).Substring(0, 200) + "...";
                    E.GoruntulemeSayisi = okuyucu.GetInt64(8);
                    E.KapakResmi = okuyucu.GetString(9);
                    if (!okuyucu.IsDBNull(10))
                    {
                        E.DuzenlenmeTarihi = Convert.ToDateTime(okuyucu.GetDateTime(10));
                    }
                    E.YayinDurum = okuyucu.GetBoolean(11);
                    if (E.YayinDurum)
                    {
                        E.YayinDurumGostergesi = "Yayında";
                    }
                    else
                    {
                        E.YayinDurumGostergesi = "Yayında Değil";
                    }
                    eserler.Add(E);
                }
                return eserler;
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

        public List<eser> eserListele()
        {
            List<eser> eserler = new List<eser>();
            try
            {

                cmd.CommandText = "SELECT EserBilgisiID ,TurIDFK ,T.TurIsmi ,E.Isim ,Yil ,ImdbPuani ,VizyonTarihi ,Konusu ,GoruntulemeSayisi ,KapakResmi, DuzenlenmeTarihi, YayinDurum FROM EserBilgisi AS E JOIN Turler AS T ON E.TurIDFK= T.TurID ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    eser E = new eser();
                    E.EserBilgisiID = okuyucu.GetInt32(0);
                    E.TurIDFK = okuyucu.GetInt32(1);
                    E.TurIsmi = okuyucu.GetString(2);
                    E.Isim = okuyucu.GetString(3);
                    E.Yil = okuyucu.GetString(4);
                    E.ImdbPuani = okuyucu.GetString(5);
                    E.VizyonTarihi = okuyucu.GetString(6);
                    E.Konusu = okuyucu.GetString(7).Substring(0, 200) + "...";
                    E.GoruntulemeSayisi = okuyucu.GetInt64(8);
                    E.KapakResmi = okuyucu.GetString(9);
                    if (!okuyucu.IsDBNull(10))
                    {
                        E.DuzenlenmeTarihi = Convert.ToDateTime(okuyucu.GetDateTime(10));
                    }
                    E.YayinDurum = okuyucu.GetBoolean(11);
                    if (E.YayinDurum)
                    {
                        E.YayinDurumGostergesi = "Yayında";
                    }
                    else
                    {
                        E.YayinDurumGostergesi = "Yayında Değil";
                    }
                    eserler.Add(E);
                }
                return eserler;
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

        public void eserDuzenle(int id)
        {
            try
            {
                cmd.CommandText = "SELECT YayinDurum FROM EserBilgisi WHERE EserBilgisiID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE EserBilgisi SET YayinDurum=@yayinDurum WHERE EserBilgisiID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@yayinDurum", !durum);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

            }
            finally
            {

                con.Close();
            }
        }

        public void eserSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM EserBilgisi WHERE EserBilgisiID=@id";
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

        public eser eserGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT EserBilgisiID ,TurIDFK ,T.TurIsmi ,E.Isim ,Yil ,ImdbPuani ,VizyonTarihi ,Konusu ,KapakResmi, YayinDurum FROM EserBilgisi AS E JOIN Turler AS T ON E.TurIDFK= T.TurID WHERE EserBilgisiID=@eserBilgisiID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@eserBilgisiID", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                eser E = new eser();
                while (okuyucu.Read())
                {
                    E.EserBilgisiID = okuyucu.GetInt32(0);
                    E.TurIDFK = okuyucu.GetInt32(1);
                    E.TurIsmi = okuyucu.GetString(2);
                    E.Isim = okuyucu.GetString(3);
                    E.Yil = okuyucu.GetString(4);
                    E.ImdbPuani = okuyucu.GetString(5);
                    E.VizyonTarihi = okuyucu.GetString(6);
                    E.Konusu = okuyucu.GetString(7);
                    E.KapakResmi = okuyucu.GetString(8);
                    E.YayinDurum = okuyucu.GetBoolean(9);
                }
                return E;
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

        public bool eserGuncelle(eser E)
        {
            try
            {
                cmd.CommandText = "UPDATE EserBilgisi SET TurIDFK=@turIDFK,Isim=@isim,Yil=@yil,ImdbPuani=@imdbPuani,VizyonTarihi=@vizyonTarihi,Konusu=@konusu,KapakResmi=@kapakResmi,YayinDurum=@yayinDurum,DuzenlenmeTarihi=@duzenlenmeTarihi WHERE EserBilgisiID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@turIDFK", E.TurIDFK);
                cmd.Parameters.AddWithValue("@isim", E.Isim);
                cmd.Parameters.AddWithValue("@yil", E.Yil);
                cmd.Parameters.AddWithValue("@imdbPuani", E.ImdbPuani);
                cmd.Parameters.AddWithValue("@vizyonTarihi", E.VizyonTarihi);
                cmd.Parameters.AddWithValue("@konusu", E.Konusu);
                cmd.Parameters.AddWithValue("@kapakResmi", E.KapakResmi);
                cmd.Parameters.AddWithValue("@yayinDurum", E.YayinDurum);
                cmd.Parameters.AddWithValue("@duzenlenmeTarihi", E.DuzenlenmeTarihi);
                cmd.Parameters.AddWithValue("@id", E.EserBilgisiID);

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

        public void eserGoruntulemeArttir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT GoruntulemeSayisi FROM EserBilgisi WHERE EserBilgisiID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE EserBilgisi SET GoruntulemeSayisi=@sayi WHERE EserBilgisiID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@sayi", sayi + 1);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Yönetmen Metodları

        public bool yonetmenEkle(yonetmen Y)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yonetmenler(YonetmenIsmi,YonetmenSoyisim,Cinsiyet,Biyografi,DogumTarihi,DogumYeri,KapakResmi) VALUES(@yonetmenIsmi,@yonetmenSoyisim,@cinsiyet,@biyografi,@dogumTarihi,@dogumYeri,@kapakResmi)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@yonetmenIsmi", Y.YonetmenIsmi);
                cmd.Parameters.AddWithValue("@yonetmenSoyisim", Y.YonetmenSoyisim);
                cmd.Parameters.AddWithValue("@cinsiyet", Y.Cinsiyet);
                cmd.Parameters.AddWithValue("@biyografi", Y.Biyografi);
                cmd.Parameters.AddWithValue("@dogumTarihi", Y.DogumTarihi);
                cmd.Parameters.AddWithValue("@dogumYeri", Y.DogumYeri);
                cmd.Parameters.AddWithValue("@kapakResmi", Y.KapakResmi);
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

        public List<yonetmen> yonetmenListele()
        {
            List<yonetmen> yonetmenler = new List<yonetmen>();
            try
            {

                cmd.CommandText = "SELECT YonetmenID, YonetmenIsmi, YonetmenSoyisim, Cinsiyet, Biyografi, DogumTarihi, DogumYeri, KapakResmi,DuzenlenmeTarihi  FROM Yonetmenler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    yonetmen Y = new yonetmen();
                    Y.YonetmenID = okuyucu.GetInt32(0);
                    Y.YonetmenIsmi = okuyucu.GetString(1);
                    Y.YonetmenSoyisim = okuyucu.GetString(2);
                    Y.Cinsiyet = okuyucu.GetString(3);
                    Y.Biyografi = okuyucu.GetString(4).Substring(0, 200) + "...";
                    Y.DogumTarihi = okuyucu.GetString(5);
                    Y.DogumYeri = okuyucu.GetString(6);
                    Y.KapakResmi = okuyucu.GetString(7);
                    if (!okuyucu.IsDBNull(8))
                    {
                        Y.DuzenlenmeTarihi = Convert.ToDateTime(okuyucu.GetDateTime(8));
                    }
                    yonetmenler.Add(Y);
                }
                return yonetmenler;
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

        public void yonetmenSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Yonetmenler WHERE YonetmenID=@id";
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

        public yonetmen yonetmenGetir(int id)
        {
            try
            {

                cmd.CommandText = "SELECT YonetmenID, YonetmenIsmi, YonetmenSoyisim, Cinsiyet, Biyografi, DogumTarihi, DogumYeri, KapakResmi  FROM Yonetmenler WHERE YonetmenID=@yonetmenID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@yonetmenID", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                yonetmen Y = new yonetmen();
                while (okuyucu.Read())
                {
                    Y.YonetmenID = okuyucu.GetInt32(0);
                    Y.YonetmenIsmi = okuyucu.GetString(1);
                    Y.YonetmenSoyisim = okuyucu.GetString(2);
                    Y.Cinsiyet = okuyucu.GetString(3);
                    Y.Biyografi = okuyucu.GetString(4);
                    Y.DogumTarihi = okuyucu.GetString(5);
                    Y.DogumYeri = okuyucu.GetString(6);
                    Y.KapakResmi = okuyucu.GetString(7);
                }
                return Y;
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

        public bool yonetmenGuncelle(yonetmen Y)
        {
            try
            {
                cmd.CommandText = "UPDATE Yonetmenler SET YonetmenIsmi=@yonetmenIsmi,YonetmenSoyisim=@yonetmenSoyisim,Cinsiyet=@cinsiyet,Biyografi=@biyografi,DogumTarihi=@dogumTarihi,DogumYeri=@dogumYeri,KapakResmi=@kapakResmi,DuzenlenmeTarihi=@duzenlenmeTarihi WHERE YonetmenID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@yonetmenIsmi", Y.YonetmenIsmi);
                cmd.Parameters.AddWithValue("@yonetmenSoyisim", Y.YonetmenSoyisim);
                cmd.Parameters.AddWithValue("@cinsiyet", Y.Cinsiyet);
                cmd.Parameters.AddWithValue("@biyografi", Y.Biyografi);
                cmd.Parameters.AddWithValue("@dogumTarihi", Y.DogumTarihi);
                cmd.Parameters.AddWithValue("@dogumYeri", Y.DogumYeri);
                cmd.Parameters.AddWithValue("@kapakResmi", Y.KapakResmi);
                cmd.Parameters.AddWithValue("@duzenlenmeTarihi", Y.DuzenlenmeTarihi);
                cmd.Parameters.AddWithValue("@id", Y.YonetmenID);
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

        public List<eser> yonetmeneAitFilmleriListele(int id)
        {
            List<eser> eserler = new List<eser>();
            try
            {

                cmd.CommandText = "SELECT E.EserBilgisiID ,T.TurIsmi ,E.Isim ,E.Yil ,E.ImdbPuani ,E.VizyonTarihi ,E.Konusu ,E.KapakResmi,E.YayinDurum, YF.YFID FROM EserBilgisi AS E JOIN Turler AS T ON E.TurIDFK=T.TurID JOIN YonetmeninFilmleri AS YF ON E.EserBilgisiID= YF.EserBilgisiIDFK JOIN Yonetmenler AS YNTMN ON YNTMN.YonetmenID=YF.YonetmenIDFK WHERE YF.YonetmenIDFK=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    eser E = new eser();
                    E.EserBilgisiID = okuyucu.GetInt32(0);
                    E.TurIsmi = okuyucu.GetString(1);
                    E.Isim = okuyucu.GetString(2);
                    E.Yil = okuyucu.GetString(3);
                    E.ImdbPuani = okuyucu.GetString(4);
                    E.VizyonTarihi = okuyucu.GetString(5);
                    E.Konusu = okuyucu.GetString(6).Substring(0, 200) + "...";
                    E.KapakResmi = okuyucu.GetString(7);
                    E.YayinDurum = okuyucu.GetBoolean(8);
                    E.YFID = okuyucu.GetInt32(9);

                    if (E.YayinDurum)
                    {
                        E.YayinDurumGostergesi = "Yayında";
                    }
                    else
                    {
                        E.YayinDurumGostergesi = "Yayında Değil";
                    }
                    eserler.Add(E);
                }
                return eserler;
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

        public bool yonetmeneFilmEkle(yonetmeninfilmleri YF)
        {
            try
            {
                cmd.CommandText = "INSERT INTO YonetmeninFilmleri(YonetmenIDFK,EserBilgisiIDFK) VALUES(@yonetmenIDFK,@eserBilgisiIDFK)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@yonetmenIDFK", YF.YonetmenIDFK);
                cmd.Parameters.AddWithValue("@eserBilgisiIDFK", YF.EserBilgisiIDFK);

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

        public void yonetmendenFilmSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM YonetmeninFilmleri WHERE YFID=@id";
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

        #endregion

        #region Oyuncu Metodları
        public bool oyuncuEkle(oyuncu O)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Oyuncular(OyuncuIsmi,OyuncuSoyisim,Cinsiyet,Biyografi,DogumTarihi,DogumYeri,KapakResmi) VALUES(@oyuncuIsmi,@oyuncuSoyisim,@cinsiyet,@biyografi,@dogumTarihi,@dogumYeri,@kapakResmi)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@oyuncuIsmi", O.OyuncuIsmi);
                cmd.Parameters.AddWithValue("@oyuncuSoyisim", O.OyuncuSoyisim);
                cmd.Parameters.AddWithValue("@cinsiyet", O.Cinsiyet);
                cmd.Parameters.AddWithValue("@biyografi", O.Biyografi);
                cmd.Parameters.AddWithValue("@dogumTarihi", O.DogumTarihi);
                cmd.Parameters.AddWithValue("@dogumYeri", O.DogumYeri);
                cmd.Parameters.AddWithValue("@kapakResmi", O.KapakResmi);
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

        public List<oyuncu> oyuncuListele()
        {
            List<oyuncu> oyuncular = new List<oyuncu>();
            try
            {
                cmd.CommandText = "SELECT OyuncuID, OyuncuIsmi, OyuncuSoyisim, Cinsiyet, Biyografi, DogumTarihi, DogumYeri, KapakResmi, DuzenlenmeTarihi  FROM Oyuncular";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    oyuncu O = new oyuncu();
                    O.OyuncuID = okuyucu.GetInt32(0);
                    O.OyuncuIsmi = okuyucu.GetString(1);
                    O.OyuncuSoyisim = okuyucu.GetString(2);
                    O.Cinsiyet = okuyucu.GetString(3);
                    O.Biyografi = okuyucu.GetString(4).Substring(0, 200) + "...";
                    O.DogumTarihi = okuyucu.GetString(5);
                    O.DogumYeri = okuyucu.GetString(6);
                    O.KapakResmi = okuyucu.GetString(7);
                    if (!okuyucu.IsDBNull(8))
                    {
                        O.DuzenlenmeTarihi = Convert.ToDateTime(okuyucu.GetDateTime(8));
                    }
                    oyuncular.Add(O);
                }
                return oyuncular;
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

        public void oyuncuSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Oyuncular WHERE OyuncuID=@id";
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

        public oyuncu oyuncuGetir(int id)
        {
            try
            {

                cmd.CommandText = "SELECT OyuncuID, OyuncuIsmi, OyuncuSoyisim, Cinsiyet, Biyografi, DogumTarihi, DogumYeri, KapakResmi  FROM Oyuncular WHERE OyuncuID=@oyuncuID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@oyuncuID", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                oyuncu O = new oyuncu();
                while (okuyucu.Read())
                {
                    O.OyuncuID = okuyucu.GetInt32(0);
                    O.OyuncuIsmi = okuyucu.GetString(1);
                    O.OyuncuSoyisim = okuyucu.GetString(2);
                    O.Cinsiyet = okuyucu.GetString(3);
                    O.Biyografi = okuyucu.GetString(4);
                    O.DogumTarihi = okuyucu.GetString(5);
                    O.DogumYeri = okuyucu.GetString(6);
                    O.KapakResmi = okuyucu.GetString(7);
                }
                return O;
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

        public bool oyuncuGuncelle(oyuncu O)
        {
            try
            {
                cmd.CommandText = "UPDATE Oyuncular SET OyuncuIsmi=@oyuncuIsmi, OyuncuSoyisim=@oyuncuSoyisim, Cinsiyet=@cinsiyet, Biyografi=@biyografi, DogumTarihi=@dogumTarihi, DogumYeri=@dogumYeri, KapakResmi=@kapakResmi, DuzenlenmeTarihi=@duzenlenmeTarihi WHERE OyuncuID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@oyuncuIsmi", O.OyuncuIsmi);
                cmd.Parameters.AddWithValue("@oyuncuSoyisim", O.OyuncuSoyisim);
                cmd.Parameters.AddWithValue("@cinsiyet", O.Cinsiyet);
                cmd.Parameters.AddWithValue("@biyografi", O.Biyografi);
                cmd.Parameters.AddWithValue("@dogumTarihi", O.DogumTarihi);
                cmd.Parameters.AddWithValue("@dogumYeri", O.DogumYeri);
                cmd.Parameters.AddWithValue("@kapakResmi", O.KapakResmi);
                cmd.Parameters.AddWithValue("@duzenlenmeTarihi", O.DuzenlenmeTarihi);
                cmd.Parameters.AddWithValue("@id", O.OyuncuID);
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

        public List<eser> oyuncuyaAitFilmleriListele(int id)
        {
            List<eser> eserler = new List<eser>();
            try
            {

                cmd.CommandText = "SELECT E.EserBilgisiID ,T.TurIsmi ,E.Isim ,E.Yil ,E.ImdbPuani ,E.VizyonTarihi ,E.Konusu ,E.KapakResmi,E.YayinDurum, OYFLM.OFID FROM EserBilgisi AS E JOIN Turler AS T ON E.TurIDFK=T.TurID JOIN OyuncununFilmleri AS OYFLM ON E.EserBilgisiID= OYFLM.EserBilgisiIDFK JOIN Oyuncular AS OYNC ON OYNC.OyuncuID=OYFLM.OyuncuIDFK WHERE OYFLM.OyuncuIDFK=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader okuyucu = cmd.ExecuteReader();
                while (okuyucu.Read())
                {
                    eser E = new eser();
                    E.EserBilgisiID = okuyucu.GetInt32(0);
                    E.TurIsmi = okuyucu.GetString(1);
                    E.Isim = okuyucu.GetString(2);
                    E.Yil = okuyucu.GetString(3);
                    E.ImdbPuani = okuyucu.GetString(4);
                    E.VizyonTarihi = okuyucu.GetString(5);
                    E.Konusu = okuyucu.GetString(6).Substring(0, 200) + "...";
                    E.KapakResmi = okuyucu.GetString(7);
                    E.YayinDurum = okuyucu.GetBoolean(8);
                    E.OFID = okuyucu.GetInt32(9);

                    if (E.YayinDurum)
                    {
                        E.YayinDurumGostergesi = "Yayında";
                    }
                    else
                    {
                        E.YayinDurumGostergesi = "Yayında Değil";
                    }
                    eserler.Add(E);
                }
                return eserler;
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

        public bool oyuncuyaFilmEkle(oyuncununfilmleri OF)
        {
            try
            {
                cmd.CommandText = "INSERT INTO OyuncununFilmleri(OyuncuIDFK,EserBilgisiIDFK) VALUES(@oyuncuIDFK,@eserBilgisiIDFK)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@oyuncuIDFK", OF.OyuncuIDFK);
                cmd.Parameters.AddWithValue("@eserBilgisiIDFK", OF.EserBilgisiIDFK);

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

        public void oyuncudanFilmSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM OyuncununFilmleri WHERE OFID=@id";
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
        #endregion
    }
}
