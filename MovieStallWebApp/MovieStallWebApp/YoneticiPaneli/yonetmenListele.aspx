<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="yonetmenListele.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.yonetmenListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/listeStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="sayfaBaslik">
        <h3>Yönetmenler</h3>
    </div>
    <div>
        <asp:ListView ID="lv_yonetmenler" runat="server" OnItemCommand="lv_yonetmenler_ItemCommand">
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
                        <img src='../resimler/YonetmenResimleri/<%# Eval("KapakResmi") %>' height="100" />
                    </td>
                    <td><%# Eval("YonetmenIsmi") %></td>
                    <td><%# Eval("YonetmenSoyisim") %></td>
                    <td><%# Eval("Cinsiyet") %></td>
                    <td><%# Eval("Biyografi") %></td>
                    <td><%# Eval("DogumTarihi") %></td>
                    <td><%# Eval("DogumYeri") %></td>
                    <td><%# Eval("DuzenlenmeTarihi") %></td>
                    <td>
                        <a href='yonetmenDuzenle.aspx?YonetmenID=<%# Eval("YonetmenID") %>' class="geriAl">Bilgilerini Düzenle</a>
                        <a href='yonetmeninFilmleri.aspx?YonetmenID=<%# Eval("YonetmenID") %>' class="duzenle">Yönetmenin Filmleri</a>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="sil" CommandArgument='<%# Eval("YonetmenID")%>' CommandName="sil">Yönetmeni Sil</asp:LinkButton>

                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="alternate">
                    <td>
                        <img src='../resimler/YonetmenResimleri/<%# Eval("KapakResmi") %>' height="100" />
                    </td>
                    <td><%# Eval("YonetmenIsmi") %></td>
                    <td><%# Eval("YonetmenSoyisim") %></td>
                    <td><%# Eval("Cinsiyet") %></td>
                    <td><%# Eval("Biyografi") %></td>
                    <td><%# Eval("DogumTarihi") %></td>
                    <td><%# Eval("DogumYeri") %></td>
                    <td><%# Eval("DuzenlenmeTarihi") %></td>
                    <td>
                        <a href='yonetmenDuzenle.aspx?YonetmenID=<%# Eval("YonetmenID") %>' class="geriAl">Bilgilerini Düzenle</a>
                        <a href='yonetmeninFilmleri.aspx?YonetmenID=<%# Eval("YonetmenID") %>' class="duzenle">Yönetmenin Filmleri</a>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="sil" CommandArgument='<%# Eval("YonetmenID")%>' CommandName="sil">Yönetmeni Sil</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

