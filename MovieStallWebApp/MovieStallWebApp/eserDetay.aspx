<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="eserDetay.aspx.cs" Inherits="MovieStallWebApp.eserDetay" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <link href="css/sayfaTasarimi.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="padding-left: 20px; font-weight: 600">
        <br />
        Eser Adı:<asp:Literal ID="ltrl_eserAdi" runat="server"></asp:Literal>
        <br />
    </div>

    <div class="eserDetay">
        <div>
            <div style="float: left; width: 600px;">
                <div>
                    <div style="float: left; width: 300px; padding: 5px 0px;">
                        <asp:Image ID="img_resim" runat="server" Style="height: 290px; max-width: 300px; border: 2px solid silver;" />
                    </div>
                </div>
                <div style="float: left; padding-left: 20px;">
                    <div class="satir">
                        Türü:&nbsp&nbsp<asp:Literal ID="ltrl_tur" runat="server"></asp:Literal>
                    </div>

                    <div class="satir">
                        İsmi:&nbsp&nbsp<asp:Literal ID="ltrl_isim" runat="server"></asp:Literal>
                    </div>

                    <div class="satir">
                        Yıl:&nbsp&nbsp<asp:Literal ID="ltrl_yil" runat="server"></asp:Literal>
                    </div>

                    <div class="satir">
                        İMDB:&nbsp&nbsp<asp:Literal ID="ltrl_imdb" runat="server"></asp:Literal>
                    </div>

                    <div class="satir">
                        Vizyon Tarihi:&nbsp<asp:Literal ID="ltrl_vizyonTarihi" runat="server"></asp:Literal>
                    </div>

                    <div class="satir">
                        Yönetmen İsmi:&nbsp<asp:Literal ID="ltrl_yonetmen" runat="server"></asp:Literal>
                    </div>

                    <div class="satir">
                        Oyuncular:&nbsp<asp:Literal ID="ltrl_oyuncu" runat="server"></asp:Literal>
                    </div>
                </div>

            </div>

        </div>
    </div>

    <div class="satir" style="float: left; padding-left: 20px;">
        Konusu:<asp:Literal ID="ltrl_konu" runat="server"></asp:Literal>
        <br />
    </div>

    <div style="clear: both;"></div>

    <div class="yorumTasiyici">
        <div class="yorumTasiyiciBaslik">
            <asp:Literal Text="Film Hakkında Yorumlar" runat="server" />
        </div>
        <div>
            <label>YORUM</label>
        </div>
        <div style="clear: both"></div>
    </div>


    <div class="yorumTasiyici">

        <div class="yorumTasiyiciBaslik">
            <label>Yorumunuz</label>&nbsp&nbsp
            <asp:Label ID="lbl_girisKontrol" runat="server" CssClass="bilgipaneliGiris" Visible="true">Yorum Yapabilmek İçin Giriş Yapmalısınız</asp:Label>
            <br />
            <br />
            <asp:TextBox ID="tb_yorum" runat="server" CssClass="multiText" TextMode="MultiLine" Visible="false"></asp:TextBox><br />
            <div>
                <label for='ddl_moviestallPuani'><b>Movie Stall Puanınız</b></label>
                <select id='ddl_moviestallPuani' name='puan' runat="server">
                    <option value=''></option>
                    <option value='bir'>1</option>
                    <option value='iki'>2</option>
                    <option value='üç'>3</option>
                    <option value='dört'>4</option>
                    <option value='beş'>5</option>
                </select>
            </div>
        </div>

        <div class="yorumTasiyiciBaslik">
            <br />
            <asp:LinkButton ID="lbtn_yorumEkle" runat="server" CssClass="islembuton" Visible="false" OnClick="lbtn_yorumEkle_Click">Yorum Ekle</asp:LinkButton>
            <asp:Label ID="lbl_bilgi" runat="server" CssClass="bilgipaneli" Visible="false">Yorumunuz Onay Beklemektedir</asp:Label>
        </div>

    </div>



</asp:Content>
