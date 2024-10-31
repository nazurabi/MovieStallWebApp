<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="yonetmenEkle.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.yonetmenEkle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/formStil.css" rel="stylesheet" />
    <script src="ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="formTasiyici">
        <div class="formBaslik">
            <h4>Yönetmen Ekle</h4>
        </div>
        <div class="formIcerik">
            <div class="satir">
                <label>İsmi</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>Soyismi</label><br />
                <asp:TextBox ID="tb_soyisim" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>Cinsiyet</label><br />
                <asp:TextBox ID="tb_cinsiyet" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>Doğum Tarihi</label><br />
                <asp:TextBox ID="tb_dogumtarihi" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>Doğum Yeri</label><br />
                <asp:TextBox ID="tb_dorumyeri" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>Biyografi</label><br />
                <asp:TextBox ID="tb_biyografi" runat="server" CssClass="metinkutu" TextMode="MultiLine"></asp:TextBox><br />
                <script>
                    CKEDITOR.replace('ContentPlaceHolder1_tb_biyografi');
                </script>
            </div>

            <div class="satir">
                <label>Kapak Resmi</label><br />
                <asp:FileUpload ID="fu_resim" runat="server" CssClass="metinkutu"></asp:FileUpload><br />
            </div>
            <div class="satir">
                <asp:LinkButton ID="lbtn_yonetmenEkle" runat="server" CssClass="islembuton" OnClick="lbtn_yonetmenEkle_Click">Yönetmen Ekle</asp:LinkButton>
                <asp:Label ID="lbl_bilgi" runat="server" CssClass="bilgipaneli" Visible="false">Yönetmen Başarılı Şekilde Eklendi</asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
