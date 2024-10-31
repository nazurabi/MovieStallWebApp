<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="eserEkle.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.eserEkle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/formStil.css" rel="stylesheet" />
    <script src="ckeditor/ckeditor.js"></script>
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
                <label>İsmi</label><br />
                <asp:TextBox ID="tb_eserAdi" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>

            <div class="satir">
                <label>Yıl</label><br />
                <asp:TextBox ID="tb_yil" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>

            <div class="satir">
                <label>İMDB Puanı</label><br />
                <asp:TextBox ID="tb_imdb" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>

            <div class="satir">
                <label>Vizyon Tarihi</label><br />
                <asp:TextBox ID="tb_vizyonTarihi" runat="server" CssClass="metinkutu"></asp:TextBox><br />
            </div>

            <div class="satir">
                <label>Konusu</label><br />
                <asp:TextBox ID="tb_konu" runat="server" CssClass="metinkutu" TextMode="MultiLine"></asp:TextBox><br />
                <script>
                    CKEDITOR.replace('ContentPlaceHolder1_tb_konu');
                </script>
            </div>

            <div class="satir">
                <label>Kapak Resmi</label><br />
                <asp:FileUpload ID="fu_resim" runat="server" CssClass="metinkutu"></asp:FileUpload><br />
            </div>

            <div class="satir">
                <div class="kayitdurum">
                    <asp:CheckBox ID="cb_yayinla" runat="server" Text="   Eseri Yayınla" Checked="true" />
                </div>
            </div>

            <div class="satir">
                <asp:LinkButton ID="lbtn_eserEkle" runat="server" CssClass="islembuton" OnClick="lbtn_eserEkle_Click">Eser Ekle</asp:LinkButton>
                <asp:Label ID="lbl_bilgi" runat="server" CssClass="bilgipaneli" Visible="false">Eser Başarılı Şekilde Eklendi</asp:Label>
            </div>

        </div>
    </div>
</asp:Content>
