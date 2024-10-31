<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="kategoriEkle.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.kategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/formStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">

        <div class="formBaslik">
            <h4>Kategori Ekle</h4>
        </div>

        <div class="formIcerik">

            <div class="satir">
                <label>Kategori Adı</label><br />
                <asp:TextBox ID="tb_kategoriadi" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>

            <div class="satir">
                <div class="durum">
                    <asp:CheckBox ID="cb_durum" runat="server" Text="   Durum Aktif" Checked="true" />
                </div>
                <div style="clear: both"></div>
            </div>

            <div class="satir">
                <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="islembuton" OnClick="lbtn_ekle_Click">Kategori Ekle</asp:LinkButton>
                <asp:Label ID="lbl_bilgi" runat="server" CssClass="bilgipaneli" Visible="false">Kategori Başarılı Şekilde Eklendi</asp:Label>
            </div>

        </div>
    </div>
</asp:Content>
