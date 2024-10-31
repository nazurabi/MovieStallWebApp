<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="oyuncuListele.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.oyuncuListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/listeStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="sayfaBaslik">
        <h3>Oyuncular</h3>
    </div>
    <div>
        <asp:ListView ID="lv_oyuncular" runat="server" OnItemCommand="lv_oyuncular_ItemCommand">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" class="esertablo">
                    <tr>
                        <th>Kapak Resmi</th>
                        <th>İsim</th>
                        <th>Soyisim</th>
                        <th>Cinsiyet</th>
                        <th>Biyografi</th>
                        <th>Doğum Tarihi</th>
                        <th>Doğum Yeri</th>
                        <th>Bilgilerinin Düzenlenme Tarihi</th>
                        <th style="width: 350px;">Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <img src='../resimler/OyuncuResimleri/<%# Eval("KapakResmi") %>' height="100" />
                    </td>
                    <td><%# Eval("OyuncuIsmi") %></td>
                    <td><%# Eval("OyuncuSoyisim") %></td>
                    <td><%# Eval("Cinsiyet") %></td>
                    <td><%# Eval("Biyografi") %></td>
                    <td><%# Eval("DogumTarihi") %></td>
                    <td><%# Eval("DogumYeri") %></td>
                    <td><%# Eval("DuzenlenmeTarihi") %></td>
                    <td>
                        <a href='oyuncuDuzenle.aspx?OyuncuID=<%# Eval("OyuncuID") %>' class="geriAl">Bilgilerini Düzenle</a>
                        <a href='oyuncununFilmleri.aspx?OyuncuID=<%# Eval("OyuncuID") %>' class="duzenle">Oyuncunun Filmleri</a>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="sil" CommandArgument='<%# Eval("OyuncuID")%>' CommandName="sil">Oyuncu Sil</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="alternate">
                    <td>
                        <img src='../resimler/OyuncuResimleri/<%# Eval("KapakResmi") %>' height="100" />
                    </td>
                    <td><%# Eval("OyuncuIsmi") %></td>
                    <td><%# Eval("OyuncuSoyisim") %></td>
                    <td><%# Eval("Cinsiyet") %></td>
                    <td><%# Eval("Biyografi") %></td>
                    <td><%# Eval("DogumTarihi") %></td>
                    <td><%# Eval("DogumYeri") %></td>
                    <td><%# Eval("DuzenlenmeTarihi") %></td>
                    <td>
                        <a href='oyuncuDuzenle.aspx?OyuncuID=<%# Eval("OyuncuID") %>' class="geriAl">Bilgilerini Düzenle</a>
                        <a href='oyuncununFilmleri.aspx?OyuncuID=<%# Eval("OyuncuID") %>' class="duzenle">Oyuncunun Filmleri</a>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="sil" CommandArgument='<%# Eval("OyuncuID")%>' CommandName="sil">Oyuncu Sil</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

