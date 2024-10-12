<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="giris.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/girisStil.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="tasiyici">
            <div class="sol">
                <div style="height: 60px;">
                    <h3>Giriş</h3>
                    <hr style="width: 318px" />
                    <asp:Panel ID="girisbilgipaneli" runat="server" CssClass="girisbilgipaneli" Visible="false">
                        <asp:Label ID="lbl_mesaj" runat="server">Kullanıcı Bulunamadı</asp:Label>
                    </asp:Panel>
                </div>
                <div class="satir">
                    <label>Mail</label><br />
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="metinkutu" placeholder="mail@gmail.com"></asp:TextBox>
                </div>
                <div class="satir">
                    <label>Şifre</label><br />
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinkutu" placeholder="1234****" TextMode="Password"></asp:TextBox>
                </div>
                <div class="satir">
                    <asp:Button ID="btn_giris" runat="server" Text="Yönetici Girişi" CssClass="girisButon" OnClick="btn_giris_Click" />
                </div>
                <div class="satir">
                    <a href="#" class="unuttum">Şifremi Unuttum</a>
                </div>
            </div>
            <div class="sag">
                <h2>Giriş Paneline Hoşgeldiniz</h2>
                <h5 style="margin-top: 260px;">Bu Alandan Üye Girişi Yapılmamaktadır.<br />
                    Üye Girişi İçin</h5>
                <a href="#" class="uyelink">Tıklayınız</a>
            </div>
            <div style="clear: both"></div>
        </div>
    </form>
</body>
</html>
