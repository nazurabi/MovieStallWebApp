CREATE DATABASE MovieStall
GO
USE MovieStall
GO
CREATE TABLE YoneticiTurleri(
ID int IDENTITY(1,1),
Isim nvarchar(10) not null,
CONSTRAINT pk_yoneticiturleri PRIMARY KEY (ID)
)
GO
INSERT INTO YoneticiTurleri (Isim) VALUES	('Admin')
INSERT INTO YoneticiTurleri (Isim) VALUES	('Moderator')
GO
CREATE TABLE Yoneticiler(
YntID int IDENTITY(1,1),
YntTurID int not null,
Isim nvarchar(30) not null,
Soyisim nvarchar(30) not null,
KullaniciAdi nvarchar(30) not null,
Mail nvarchar(50) not null,
Sifre nvarchar(20) not null,
Durum bit not null,
Silinmis bit not null,
CONSTRAINT pk_yoneticiler PRIMARY KEY (YntID),
CONSTRAINT fk_yoneticiturleri FOREIGN KEY (YntTurID) REFERENCES YoneticiTurleri(ID)
)
GO
INSERT INTO Yoneticiler (YntTurID, Isim, Soyisim, KullaniciAdi, Mail, Sifre, Durum, Silinmis)
VALUES (1,'Nasuh', 'BERBER', 'nazurabi', 'nasuhberber@gmail.com', 'Hn161109*', 1,0)
INSERT INTO Yoneticiler (YntTurID, Isim, Soyisim, KullaniciAdi, Mail, Sifre, Durum, Silinmis)
VALUES (2,'Murtaza', 'ÞUAYÝPOÐLU', 'muþuo', 'muþuo@gmail.com', 'Muþuo2626*', 1,0)
GO
CREATE TABLE Turler(
TurID int IDENTITY(1,1),
TurIsmi nvarchar(15) not null,
CONSTRAINT pk_tur PRIMARY KEY(TurID)
)
GO
CREATE TABLE Kategoriler(
KategoriID int IDENTITY(1,1),
KategoriIsmi nvarchar(20)not null,
Durum bit not null,
Silinmis bit not null,
CONSTRAINT pk_kategoriler PRIMARY KEY (KategoriID),
)
GO
CREATE TABLE EserBilgisi(
EserBilgisiID int IDENTITY(1,1),
TurIDFK int not null,
Isim nvarchar(75) not null,
Yil nvarchar (4) not null,
ImdbPuani nvarchar(3) not null,
VizyonTarihi Date not null,
Konusu ntext not null,
GoruntulemeSayisi bigint,
KapakResmi nvarchar(50) not null,
CONSTRAINT pk_eser PRIMARY KEY(EserBilgisiID),
CONSTRAINT fk_tur FOREIGN KEY(TurIDFK) REFERENCES Turler(TurID)
)
GO
CREATE TABLE Oyuncular(
OyuncuID int IDENTITY(1,1),
OyuncuIsmi nvarchar(30) not null,
OyuncuSoyisim nvarchar(30) not null,
Cinsiyet nvarchar(5) not null,
Biyografi ntext not null,
DogumTarihi date not null,
DogumYeri nvarchar(50) not null,
KapakResmi nvarchar(50) not null,
CONSTRAINT pk_oyuncular PRIMARY KEY(OyuncuID)
)
GO
CREATE TABLE Yonetmenler(
YonetmenID int IDENTITY(1,1),
YonetmenIsmi nvarchar(30) not null,
YonetmenSoyisim nvarchar(30) not null,
Cinsiyet nvarchar(5) not null,
Biyografi ntext not null,
DogumTarihi date not null,
DogumYeri nvarchar(50) not null,
KapakResmi nvarchar(50) not null,
CONSTRAINT pk_oyuncular PRIMARY KEY(YonetmenID)
)
GO
CREATE TABLE Eserler(
EserlerID int IDENTITY(1,1),
EserBilgisiIDFK int not null,
KategoriIDFK int not null,
OyuncuIDFK int not null,
YonetmenIDFK int not null,
YorumIDFK int,
CONSTRAINT pk_eserler PRIMARY KEY (EserlerID),
CONSTRAINT fk_eserbilgisi FOREIGN KEY (EserBilgisiIDFK) REFERENCES EserBilgisi(EserBilgisiID),
CONSTRAINT fk_kategoriler FOREIGN KEY (KategoriIDFK) REFERENCES Kategoriler(KategoriID),
CONSTRAINT fk_oyuncu FOREIGN KEY (OyuncuIDFK) REFERENCES Oyuncular(OyuncuID),
CONSTRAINT fk_yonetmen FOREIGN KEY (YonetmenIDFK) REFERENCES Yonetmenler(YonetmenID),
)
GO
CREATE TABLE Uyeler(
UyeID int IDENTITY(1,1),
Izlediklerim int,--Üyenin izledikleri için
Izlenecekler int,--Üyenin izlemeyi planladýklarý için
Isim nvarchar(30) not null,
Soyisim nvarchar(30) not null,
KullaniciAdi nvarchar(30) not null,
Mail nvarchar(50) not null,
Sifre nvarchar(20) not null,
Avatar nvarchar(50) not null,
Durum bit not null,
Silinmis bit not null,
CONSTRAINT pk_uye PRIMARY KEY (UyeID),
CONSTRAINT fk_izlediklerim FOREIGN KEY(Izlediklerim) REFERENCES Eserler(EserlerID),
CONSTRAINT fk_izlenecekler FOREIGN KEY(Izlenecekler) REFERENCES Eserler(EserlerID)
)
GO
CREATE TABLE Yorumlar(
YrmID int IDENTITY(1,1),
EserlerIDFK int not null,
UyeIDFK int not null,
Yorum ntext not null,
EklemeTarihi date not null,
MovieStallPuani nvarchar(2),
Durum bit,
CONSTRAINT pk_yorum PRIMARY KEY (YrmID),
CONSTRAINT fk_eserler FOREIGN KEY(EserlerIDFK) REFERENCES Eserler(EserlerID),
CONSTRAINT fk_uye FOREIGN KEY(UyeIDFK) REFERENCES Uyeler(UyeID),
)