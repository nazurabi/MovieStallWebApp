<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="yoneticiEkle.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.yoneticiEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/formStil.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="yoneticiFormTasiyici">
        <div class="formBaslik">
            <h4>Yönetici Ekle</h4>
        </div>
        <div class="formIcerik">
            <div>
                <div>
              
                    <div class="satir">
                        <label>Yönetici Türü</label><br />
                        <asp:DropDownList ID="ddl_yoneticiTuru" runat="server" CssClass="metinkutu" DataTextField="YntTur" DataValueField="YntTurID">
                        </asp:DropDownList><br />
                    </div>

                    <div>
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
                        <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinkutu"></asp:TextBox><br />
                    </div>

                    <div class="satir">
                        <div class="durum">
                            <asp:CheckBox ID="cb_durum" runat="server" Text="   Durum Aktif" Checked="true" />
                        </div>
                    </div>
                    <div style="clear: both"></div>
                </div>
            </div>

            <div class="satir">
                <asp:LinkButton Visible="true" ID="lbtn_yoneticiEkle" runat="server" CssClass="islembuton" OnClick="lbtn_yoneticiEkle_Click">Yönetici Ekle</asp:LinkButton>
            </div>
            <div></div>
            <div class="satir">
                <asp:Label ID="lbl_bilgi" runat="server" CssClass="bilgipaneli" Visible="false">Yönetici Başarılı Şekilde Eklendi</asp:Label>
                    <br />
            </div>

        </div>
    </div>
</asp:Content>



