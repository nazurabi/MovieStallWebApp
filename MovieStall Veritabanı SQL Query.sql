CREATE DATABASE MovieStall
GO
USE MovieStall
GO
CREATE TABLE YoneticiTurleri(
ID int IDENTITY(1,1),
Isim nvarchar(10),
CONSTRAINT pk_yoneticiturleri PRIMARY KEY (ID)
)
GO
INSERT INTO YoneticiTurleri (Isim) VALUES	('Admin')
INSERT INTO YoneticiTurleri (Isim) VALUES	('Moderator')
GO
CREATE TABLE Yoneticiler(
YntID int IDENTITY(1,1),
YntTurID int,
Isim nvarchar(30),
Soyisim nvarchar(30),
KullaniciAdi nvarchar(30),
Mail nvarchar(50),
Sifre nvarchar(20),
Durum bit,
Silinmis bit,
CONSTRAINT pk_yoneticiler PRIMARY KEY (YntID),
CONSTRAINT fk_yoneticiturleri FOREIGN KEY (YntTurID) REFERENCES YoneticiTurleri(ID)
)
GO
INSERT INTO Yoneticiler (YntTurID, Isim, Soyisim, KullaniciAdi, Mail, Sifre, Durum, Silinmis)
VALUES (1,'Nasuh', 'BERBER', 'nazurabi', 'nasuhberber@nazurabi.com', '1234', 1,0)
INSERT INTO Yoneticiler (YntTurID, Isim, Soyisim, KullaniciAdi, Mail, Sifre, Durum, Silinmis)
VALUES (2,'Murtaza', 'ÞUAYÝPOÐLU', 'muþuo', 'muþuo@gmail.com', 'Muþuo2626*', 1,0)
GO
CREATE TABLE Turler(
TurID int IDENTITY(1,1),
TurIsmi nvarchar(15),
CONSTRAINT pk_tur PRIMARY KEY(TurID)
)
INSERT INTO Turler (TurIsmi) VALUES ('Film')
INSERT INTO Turler (TurIsmi) VALUES ('Dizi')
INSERT INTO Turler (TurIsmi) VALUES ('Kýsa Film')
INSERT INTO Turler (TurIsmi) VALUES ('Belgesel')
GO
CREATE TABLE Kategoriler(
KategoriID int IDENTITY(1,1),
KategoriIsmi nvarchar(20),
Durum bit,
Silinmis bit,
CONSTRAINT pk_kategoriler PRIMARY KEY (KategoriID),
)
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Aile',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Aksiyon',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Animasyon',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Bilim Kurgu',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Biyografi',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Dram',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Fantastik',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Gerilim',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Gizem',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Komedi',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Korku',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Macera',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Müzik',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Polisiye',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Romantik',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Savaþ',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Spor',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Tarih',1,0 )
INSERT INTO Kategoriler(KategoriIsmi,Durum,Silinmis) VALUES ( 'Vahþi Batý',1,0 )
GO
CREATE TABLE EserBilgisi(
EserBilgisiID int IDENTITY(1,1),
TurIDFK int,
Isim nvarchar(75),
Yil nvarchar (4),
ImdbPuani nvarchar(3),
VizyonTarihi nvarchar(15),
Konusu nvarchar(max),
GoruntulemeSayisi bigint,
KapakResmi nvarchar(max),
YayinDurum bit,
CONSTRAINT pk_eser PRIMARY KEY(EserBilgisiID),
CONSTRAINT fk_tur FOREIGN KEY(TurIDFK) REFERENCES Turler(TurID)
)
GO
CREATE TABLE KategoriyeAitFilmler(
KEserID int IDENTITY(1,1),
KategoriIDFK int,
EserBilgisiIDFK int,
CONSTRAINT pk_keser PRIMARY KEY (KEserID),
CONSTRAINT fk_kategori FOREIGN KEY(KategoriIDFK) REFERENCES Kategoriler(KategoriID),
CONSTRAINT fk_eserbilgisikat FOREIGN KEY(EserBilgisiIDFK) REFERENCES EserBilgisi(EserBilgisiID)
)
GO
CREATE TABLE Oyuncular(
OyuncuID int IDENTITY(1,1),
OyuncuIsmi nvarchar(30),
OyuncuSoyisim nvarchar(30),
Cinsiyet nvarchar(5),
Biyografi nvarchar(max),
DogumTarihi nvarchar(15),
DogumYeri nvarchar(50),
KapakResmi nvarchar(max),
CONSTRAINT pk_oyuncular PRIMARY KEY(OyuncuID)
)
GO
CREATE TABLE OyuncununFilmleri(
OFID int IDENTITY(1,1),
OyuncuIDFK int,
EserBilgisiIDFK int,
CONSTRAINT pk_ofid PRIMARY KEY (OFID),
CONSTRAINT fk_oyuncu FOREIGN KEY(OyuncuIDFK) REFERENCES Oyuncular(OyuncuID),
CONSTRAINT fk_eserbilgisiof FOREIGN KEY(EserBilgisiIDFK) REFERENCES EserBilgisi(EserBilgisiID)
)
GO
CREATE TABLE Yonetmenler(
YonetmenID int IDENTITY(1,1),
YonetmenIsmi nvarchar(30),
YonetmenSoyisim nvarchar(30),
Cinsiyet nvarchar(5),
Biyografi nvarchar(max),
DogumTarihi nvarchar(15),
DogumYeri nvarchar(50),
KapakResmi nvarchar(max),
CONSTRAINT pk_yonetmen PRIMARY KEY(YonetmenID)
)
GO
CREATE TABLE YonetmeninFilmleri(
YFID int IDENTITY(1,1),
YonetmenIDFK int,
EserBilgisiIDFK int,
CONSTRAINT pk_yfid PRIMARY KEY (YFID),
CONSTRAINT fk_yonetmen FOREIGN KEY(YonetmenIDFK) REFERENCES Yonetmenler(YonetmenID),
CONSTRAINT fk_eserbilgisiyf FOREIGN KEY(EserBilgisiIDFK) REFERENCES EserBilgisi(EserBilgisiID)
)
GO
CREATE TABLE Uyeler(
UyeID int IDENTITY(1,1),
Izlediklerim int,--Üyenin izledikleri için
Izlenecekler int,--Üyenin izlemeyi planladýklarý için
Isim nvarchar(30),
Soyisim nvarchar(30),
KullaniciAdi nvarchar(30),
Mail nvarchar(50),
Sifre nvarchar(20),
Avatar nvarchar(50),
Durum bit,
Silinmis bit,
CONSTRAINT pk_uye PRIMARY KEY (UyeID),
CONSTRAINT fk_izlediklerim FOREIGN KEY(Izlediklerim) REFERENCES EserBilgisi(EserBilgisiID),
CONSTRAINT fk_izlenecekler FOREIGN KEY(Izlenecekler) REFERENCES EserBilgisi(EserBilgisiID)
)
GO
INSERT INTO Uyeler (Isim, Soyisim,KullaniciAdi,Mail,Sifre,Durum,Silinmis)
VALUES ('Murtaza','MURTOÐLU','murmurt','murtazamurtoglu@gmail.com','1234',1,0)
GO
CREATE TABLE Yorumlar(
YrmID int IDENTITY(1,1),
UyeIDFK int,
EserBilgisiIDFK int,
Yorum nvarchar(max),
EklemeTarihi date,
MovieStallPuani nvarchar(2),
Durum bit,
CONSTRAINT pk_yorum PRIMARY KEY (YrmID),
CONSTRAINT fk_uye FOREIGN KEY(UyeIDFK) REFERENCES Uyeler(UyeID),
CONSTRAINT fk_eserbilgisiyrm FOREIGN KEY (EserBilgisiIDFK) REFERENCES EserBilgisi(EserBilgisiID)
)
GO
--CREATE TABLE Eserler(
--EserlerID int IDENTITY(1,1),
--EserBilgisiIDFK int not null,
--KategoriIDFK int not null,
--OyuncuIDFK int not null,
--YonetmenIDFK int not null,
--YorumIDFK int,
--CONSTRAINT pk_eserler PRIMARY KEY (EserlerID),
--CONSTRAINT fk_eserbilgisi FOREIGN KEY (EserBilgisiIDFK) REFERENCES EserBilgisi(EserBilgisiID),
--CONSTRAINT fk_kategoriler FOREIGN KEY (KategoriIDFK) REFERENCES Kategoriler(KategoriID),
--CONSTRAINT fk_oyuncu FOREIGN KEY (OyuncuIDFK) REFERENCES Oyuncular(OyuncuID),
--CONSTRAINT fk_yonetmen FOREIGN KEY (YonetmenIDFK) REFERENCES Yonetmenler(YonetmenID),
--CONSTRAINT fk_yorum FOREIGN KEY (YorumIDFK) REFERENCES Yorumlar(YrmID)
--)

CREATE TABLE SecilenTur(
STID int IDENTITY(1,1),
SonSecilen int,
CONSTRAINT pk_sonsecilen PRIMARY KEY(STID)
)
GO
INSERT INTO SecilenTur (SonSecilen)
VALUES (0)