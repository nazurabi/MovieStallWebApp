<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="uyeDuzenle.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.uyeDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/formStil.css" rel="stylesheet" />
    <script src="ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="formTasiyici">

        <div class="formBaslik">
            <h4>Üyenin Bilgilerini Düzenle</h4>
        </div>
                <div class="formIcerik">
            <div>
                <div style="float: left; width: 350px;">

                    <div class="satir">
                        <label>İsmi</label><br />
                        <asp:TextBox ID="tb_isim" runat="server" CssClass="metinkutu"></asp:TextBox><br />
                    </div>

                    <div class="satir">
                        <label>Soyismi</label><br />
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
                         <%--TextMode="Password"--%>
                    </div>
                </div>

                <div style="float: left; width: 380px; padding: 5px 0px;">
                    <label>Mevcut Avatar</label><br />
                    <asp:Image ID="img_resim" runat="server" Style="height: 290px; max-width: 370px; border: 2px solid silver;" />
                </div>

                <div style="clear: both;"></div>
            </div>
            <div class="satir">
                <asp:CheckBox ID="cb_durum" runat="server" Text=" Durum Aktif" Checked="true"></asp:CheckBox><br />
            </div>

            <div class="satir">
                <label>Yeni Avatar Resmi</label><br />
                <asp:FileUpload ID="fu_resim" runat="server" CssClass="metinkutu"></asp:FileUpload><br />
            </div>

            <div class="satir">
                <asp:LinkButton ID="lbtn_uyeDuzenle" runat="server" CssClass="islembuton" OnClick="lbtn_uyeDuzenle_Click">Üye Bilgilerini Düzenle</asp:LinkButton>
                <asp:Label ID="lbl_bilgi" runat="server" CssClass="bilgipaneli" Visible="false">Üye Bilgileri Başarılı Şekilde Düzenlendi</asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
