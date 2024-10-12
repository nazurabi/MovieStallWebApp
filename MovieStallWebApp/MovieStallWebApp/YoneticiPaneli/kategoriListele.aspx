<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="kategoriListele.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.kategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/listeStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sayfaBaslik">
        <h3>Kategoriler</h3>
    </div>
    <div class="tabloTasiyici">
        <asp:ListView ID="lv_kategoriler" runat="server">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" class="tablo">
                    <tr>
                        <th>ID</th>
                        <th>Kategori İsmi</th>
                        <th>Durum</th>
                        <th>Silinmiş</th>
                        <th>Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("KategoriID") %></td>
                    <td><%# Eval("KategoriIsmi") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td><%# Eval("Silinmis") %></td>
                    <td>
                        <a href="#" class="duzenle">Düzenle</a>
                        <a href="#" class="sil">Sil</a>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="alternate">
                    <td><%# Eval("KategoriID") %></td>
                    <td><%# Eval("KategoriIsmi") %></td>
                    <td><%# Eval("Durum") %></td>
                    <td><%# Eval("Silinmis") %></td>
                    <td>
                        <a href="#" class="duzenle">Düzenle</a>
  <a href="#" class="sil">Sil</a>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
