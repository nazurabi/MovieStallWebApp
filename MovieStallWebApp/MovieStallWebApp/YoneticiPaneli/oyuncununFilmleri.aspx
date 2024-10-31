<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="oyuncununFilmleri.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.oyuncununFilmleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/listeStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lbl_oyuncuAdi" runat="server"></asp:Label><br />
    </div>
    <div class="sayfaBaslik">
        <h3>Oyuncuya Ait Filmler</h3>
    </div>
    <div>
        <asp:ListView ID="lv_oyuncununFilmleri" runat="server" OnItemCommand="lv_oyuncununFilmleri_ItemCommand">
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
                        <th>Yayın Durumu</th>
                        <th style="width: 250px;">Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <img src='../resimler/EserResimleri/<%# Eval("KapakResmi") %>' height="100" />
                    </td>
                    <td><%# Eval("TurIsmi") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Yil") %></td>
                    <td><%# Eval("ImdbPuani") %></td>
                    <td><%# Eval("VizyonTarihi") %></td>
                    <td><%# Eval("Konusu") %></td>
                    <td><%# Eval("YayinDurumGostergesi") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("OFID")%>' CommandName="sil">Listeden Çıkar</asp:LinkButton>
                    </td>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="alternate">
                    <td>
                        <img src='../resimler/EserResimleri/<%# Eval("KapakResmi") %>' height="100" />
                    </td>
                    <td><%# Eval("TurIsmi") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Yil") %></td>
                    <td><%# Eval("ImdbPuani") %></td>
                    <td><%# Eval("VizyonTarihi") %></td>
                    <td><%# Eval("Konusu") %></td>
                    <td><%# Eval("YayinDurumGostergesi") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("OFID")%>' CommandName="sil">Listeden Çıkar</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>

    <div class="sayfaBaslik">
        <h3>Genel Film Listesi</h3>
    </div>
    <div>
        <asp:ListView ID="lv_genelListe" runat="server" OnItemCommand="lv_genelListe_ItemCommand">
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
                        <th>Yayın Durumu</th>
                        <th style="width: 250px;">Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <img src='../resimler/EserResimleri/<%# Eval("KapakResmi") %>' height="100" />
                    </td>
                    <td><%# Eval("TurIsmi") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Yil") %></td>
                    <td><%# Eval("ImdbPuani") %></td>
                    <td><%# Eval("VizyonTarihi") %></td>
                    <td><%# Eval("Konusu") %></td>
                    <td><%# Eval("YayinDurumGostergesi") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_listeyeEkle" runat="server" CssClass="duzenle" CommandArgument='<%# Eval("EserBilgisiID")%>' CommandName="liste">Listeye Ekle</asp:LinkButton>
                    </td>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="alternate">
                    <td>
                        <img src='../resimler/EserResimleri/<%# Eval("KapakResmi") %>' height="100" />
                    </td>
                    <td><%# Eval("TurIsmi") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("Yil") %></td>
                    <td><%# Eval("ImdbPuani") %></td>
                    <td><%# Eval("VizyonTarihi") %></td>
                    <td><%# Eval("Konusu") %></td>
                    <td><%# Eval("YayinDurumGostergesi") %></td>
                    <td>
                        <asp:LinkButton ID="lbtn_listeyeEkle" runat="server" CssClass="duzenle" CommandArgument='<%# Eval("EserBilgisiID")%>' CommandName="liste">Listeye Ekle</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

