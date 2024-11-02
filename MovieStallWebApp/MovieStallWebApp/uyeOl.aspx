<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="uyeOl.aspx.cs" Inherits="MovieStallWebApp.uyeOl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/sayfaTasarimi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="formTasiyiciUyelik">
        <div class="formBaslik">
            <h4>Üye Ol</h4>
        </div>
        <div class="formIcerikUyeOl">
            <div class="satir">
                <label>İsim</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>Soyisim</label><br />
                <asp:TextBox ID="tb_soyisim" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>Kullanıcı Adı</label><br />
                <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>Mail</label><br />
                <asp:TextBox ID="tb_mail" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>Şifre</label><br />
                <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinkutu" TextMode="Password"></asp:TextBox><br />
            </div>

            <div class="satir">
                <label>Avatar</label><br />
                <asp:FileUpload ID="fu_resim" runat="server" CssClass="metinkutu"></asp:FileUpload><br />
            </div>
            <div class="satir">
                <br />
                <asp:LinkButton ID="lbtn_uyeOl" runat="server" CssClass="islembuton" OnClick="lbtn_uyeOl_Click">Üye Ol</asp:LinkButton>

                <div class="satir">
                        <br />
                    <asp:Label ID="lbl_bilgi" runat="server" CssClass="bilgipaneli" Visible="false">Üyelik Başarılı Şekilde Oluşturuldu</asp:Label>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

