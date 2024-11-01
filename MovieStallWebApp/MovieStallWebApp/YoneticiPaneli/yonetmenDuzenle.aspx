<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="yonetmenDuzenle.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.yonetmenDuzenle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/formStil.css" rel="stylesheet" />
    <script src="ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="formTasiyici">

        <div class="formBaslik">
            <h4>Yönetmen Bilgilerini Düzenle</h4>
        </div>

        <div class="formIcerik">
            <div>
                <div style="float: left; width: 350px;">

                    <div class="satir">
                        <label>İsmi</label><br />
                        <asp:TextBox ID="tb_yonetmenAdi" runat="server" CssClass="metinkutu"></asp:TextBox><br />
                    </div>

                    <div class="satir">
                        <label>Soyismi</label><br />
                        <asp:TextBox ID="tb_yonetmenSoyismi" runat="server" CssClass="metinkutu"></asp:TextBox><br />
                    </div>

                    <div class="satir">
                        <label>Cinsiyet</label><br />
                        <asp:TextBox ID="tb_cinsiyet" runat="server" CssClass="metinkutu"></asp:TextBox><br />
                    </div>

                    <div class="satir">
                        <label>Doğum Tarihi</label><br />
                        <asp:TextBox ID="tb_dogumTarihi" runat="server" CssClass="metinkutu"></asp:TextBox><br />
                    </div>
                    <div class="satir">
                        <label>Doğum Yeri</label><br />
                        <asp:TextBox ID="tb_dogumYeri" runat="server" CssClass="metinkutu"></asp:TextBox><br />
                    </div>
                </div>

                <div style="float: left; width: 380px; padding: 5px 0px;">
                    <label>Mevcut Görsel</label><br />
                    <asp:Image ID="img_resim" runat="server" Style="height: 290px; max-width: 370px; border: 2px solid silver;" />
                </div>

                <div style="clear: both;"></div>
            </div>
            <div class="satir">
                <label>Biyografisi</label><br />
                <asp:TextBox ID="tb_biyografi" runat="server" CssClass="metinkutu" TextMode="MultiLine"></asp:TextBox><br />
                <script>
                    CKEDITOR.replace('ContentPlaceHolder1_tb_biyografi');
                </script>
            </div>

            <div class="satir">
                <label>Yeni Kapak Resmi</label><br />
                <asp:FileUpload ID="fu_resim" runat="server" CssClass="metinkutu"></asp:FileUpload><br />
            </div>

            <div class="satir">
                <asp:LinkButton ID="lbtn_yonetmenDuzenle" runat="server" CssClass="islembuton" OnClick="lbtn_yonetmenDuzenle_Click">Yönetmen Bilgilerini Düzenle</asp:LinkButton>
                <asp:Label ID="lbl_bilgi" runat="server" CssClass="bilgipaneli" Visible="false">Yönetmen Başarılı Şekilde Düzenlendi</asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
