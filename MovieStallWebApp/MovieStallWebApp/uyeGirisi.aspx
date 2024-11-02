<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="uyeGirisi.aspx.cs" Inherits="MovieStallWebApp.uyeGirisi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/sayfaTasarimi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                <asp:Button ID="btn_giris" runat="server" Text="Giriş Yap" CssClass="girisButon" OnClick="btn_giris_Click" />
            </div>
            <div class="satir">
                <a href="https://mail.google.com/" class="unuttum">Şifremi Unuttum</a>
            </div>
        </div>
        <div class="sag">
            <h2>Giriş Paneline Hoşgeldiniz</h2>
        </div>
        <div style="clear: both"></div>
    </div>
</asp:Content>
