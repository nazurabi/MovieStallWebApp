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
VALUES (2,'Murtaza', '�UAY�PO�LU', 'mu�uo', 'mu�uo@gmail.com', 'Mu�uo2626*', 1,0)
GO
CREATE TABLE Turler(
TurID int IDENTITY(1,1),
TurIsmi nvarchar(15),
CONSTRAINT pk_tur PRIMARY KEY(TurID)
)
GO
CREATE TABLE Kategoriler(
KategoriID int IDENTITY(1,1),
KategoriIsmi nvarchar(20),
Durum bit,
Silinmis bit,
CONSTRAINT pk_kategoriler PRIMARY KEY (KategoriID),
)
GO
CREATE TABLE EserBilgisi(
EserBilgisiID int IDENTITY(1,1),
TurIDFK int,
KategoriIDFK int,
Isim nvarchar(75),
Yil nvarchar (4),
ImdbPuani nvarchar(3),
VizyonTarihi Date,
Konusu ntext,
Oyuncular nvarchar(225),
Yonetmen nvarchar(75),
GoruntulemeSayisi bigint,
KapakResmi nvarchar(50),
CONSTRAINT pk_eser PRIMARY KEY(EserBilgisiID),
CONSTRAINT fk_tur FOREIGN KEY(TurIDFK) REFERENCES Turler(TurID),
CONSTRAINT fk_kategori FOREIGN KEY(KategoriIDFK) REFERENCES Kategoriler(KategoriID)
)
GO
CREATE TABLE Uyeler(
UyeID int IDENTITY(1,1),
Izlediklerim int,--�yenin izledikleri i�in
Izlenecekler int,--�yenin izlemeyi planlad�klar� i�in
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
CREATE TABLE Yorumlar(
YrmID int IDENTITY(1,1),
UyeIDFK int,
Yorum ntext,
EklemeTarihi date,
MovieStallPuani nvarchar(2),
Durum bit,
CONSTRAINT pk_yorum PRIMARY KEY (YrmID),
CONSTRAINT fk_uye FOREIGN KEY(UyeIDFK) REFERENCES Uyeler(UyeID),
)
GO
CREATE TABLE Eserler(
EserlerID int IDENTITY(1,1),
EserBilgisiIDFK int,
YorumIDFK int,
CONSTRAINT pk_eserler PRIMARY KEY (EserlerID),
CONSTRAINT fk_eserbilgisi FOREIGN KEY (EserBilgisiIDFK) REFERENCES EserBilgisi(EserBilgisiID),
CONSTRAINT fk_yorum FOREIGN KEY (YorumIDFK) REFERENCES Yorumlar(YrmID)
)