<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieStallWebApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/sayfaTasarimi.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >
        <br />
        <asp:Label ID="lbl_kategoriAdi" runat="server" Style="padding-left: 20px; font-weight:600"></asp:Label>
        <br />
    </div>
    <div>
        <asp:ListView ID="lv_kategorininFilmleri" runat="server">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" class="tablo">
                    <tr>
                        <th>Kapak Resmi</th>
                        <th>Türü</th>
                        <th>İsim</th>
                        <th>Yıl</th>
                        <th>İmdb Puanı</th>
                        <th>Vizyon Tarihi</th>
                        <th>Konusu</th>
                        <th>Görüntüleme Sayısı</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <a href='eserDetay.aspx?EserBilgisiID=<%# Eval("EserBilgisiID") %>'>
                            <img src='../resimler/EserResimleri/<%# Eval("KapakResmi") %>' height="100" />
                        </a>
                    </td>
                    <td><%# Eval("TurIsmi") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Yil") %></td>
                    <td><%# Eval("ImdbPuani") %></td>
                    <td><%# Eval("VizyonTarihi") %></td>
                    <td><%# Eval("Konusu") %></td>
                    <td><%# Eval("GoruntulemeSayisi") %></td>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

