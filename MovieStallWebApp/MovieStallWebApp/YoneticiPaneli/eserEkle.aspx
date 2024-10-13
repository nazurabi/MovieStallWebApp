<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="eserEkle.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.eserEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/formStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="formTasiyici">
        <div class="formBaslik">
            <h4>Eser Ekle</h4>
        </div>
        <div class="formIcerik">
            <div class="satir">
                <label>Türü</label><br />
                <asp:DropDownList ID="ddl_tur" runat="server" CssClass="metinkutu" DataTextField="TurIsmi" DataValueField="TurID">
                </asp:DropDownList><br />
            </div>
            <div class="satir">
                <label>Kategorisi</label><br />
                <asp:DropDownList ID="ddl_kategori" runat="server" CssClass="metinkutu" DataTextField="KategoriIsmi" DataValueField="KategoriID">
                </asp:DropDownList><br />
            </div>
            <div class="satir">
                <label>İsmi</label><br />
                <asp:TextBox ID="tb_kategoriadi" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>Yıl</label><br />
                <asp:TextBox ID="TextBox1" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>İMDB Puanı</label><br />
                <asp:TextBox ID="TextBox2" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>Vizyon Tarihi</label><br />
                <asp:TextBox ID="TextBox3" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>Konusu</label><br />
                <asp:TextBox ID="tb_konu" runat="server" CssClass="metinkutu" TextMode="MultiLine"></asp:TextBox><br />
            </div>
            <div class="satir">
                <label>Kapak Resmi</label><br />
                <asp:FileUpload ID="fu_resim" runat="server" CssClass="metinkutu"></asp:FileUpload><br />
            </div>






            <div class="satir">
                <%--     <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="islembuton" OnClick="lbtn_ekle_Click">Kategori Ekle</asp:LinkButton>
               <asp:Label ID="lbl_bilgi" runat="server" CssClass="bilgipaneli" Visible="false">Kategori Başarılı Şekilde Eklendi</asp:Label>--%>
            </div>
        </div>
    </div>






</asp:Content>
