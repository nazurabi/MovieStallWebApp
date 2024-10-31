<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPaneli/yoneticipnl.Master" AutoEventWireup="true" CodeBehind="eserListele.aspx.cs" Inherits="MovieStallWebApp.YoneticiPaneli.eserListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/listeStil.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="sayfaBaslik">
        <h3>Yayındaki Eserler</h3>
    </div>
    <div>
        <asp:ListView ID="lv_eserler_aktif" runat="server" OnItemCommand="lv_eserler_aktif_ItemCommand">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" class="esertablo">
                    <tr>
                        <th>Kapak Resmi</th>
                        <th>Türü</th>
                        <th>İsim</th>
                        <th>Yıl</th>
                        <th>İmdb Puanı</th>
                        <th>Vizyon Tarihi</th>
                        <th>Konusu</th>
                        <th>Görüntüleme Sayısı</th>
                        <th>Düzenlenme Tarihi</th>
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
                    <td><%# Eval("GoruntulemeSayisi") %></td>
                    <td><%# Eval("DuzenlenmeTarihi") %></td>
                    <td><%# Eval("YayinDurumGostergesi") %></td>
                    <td>
                        <a href='eserDuzenle.aspx?EserBilgisiID=<%# Eval("EserBilgisiID") %>' class="geriAl">Eser Düzenle</a>
                        <asp:LinkButton ID="lbtn_duzenle" runat="server" CssClass="duzenle" CommandArgument='<%# Eval("EserBilgisiID")%>' CommandName="durum">Durum Düzenle</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("EserBilgisiID")%>' CommandName="sil">Sil</asp:LinkButton>
                    </td>
                </tr>
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
                    <td><%# Eval("GoruntulemeSayisi") %></td>
                    <td><%# Eval("DuzenlenmeTarihi") %></td>
                    <td><%# Eval("YayinDurumGostergesi") %></td>
                    <td>
                        <a href='eserDuzenle.aspx?EserBilgisiID=<%# Eval("EserBilgisiID") %>' class="geriAl">Eser Düzenle</a>
                        <asp:LinkButton ID="lbtn_duzenle" runat="server" CssClass="duzenle" CommandArgument='<%# Eval("EserBilgisiID")%>' CommandName="durum">Durum Düzenle</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("EserBilgisiID")%>' CommandName="sil">Sil</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>

    <div class="sayfaBaslik">
        <h3>Yayınlanmamış Eserler</h3>
    </div>
    <div>
        <asp:ListView ID="lv_eserler_pasif" runat="server" OnItemCommand="lv_eserler_pasif_ItemCommand">
            <LayoutTemplate>
                <table cellspacing="0" cellpadding="0" class="esertablo">
                    <tr>
                        <th>Kapak Resmi</th>
                        <th>Türü</th>
                        <th>İsim</th>
                        <th>Yıl</th>
                        <th>İmdb Puanı</th>
                        <th>Vizyon Tarihi</th>
                        <th>Konusu</th>
                        <th>Görüntüleme Sayısı</th>
                        <th>Düzenlenme Tarihi</th>
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
                    <td><%# Eval("GoruntulemeSayisi") %></td>
                    <td><%# Eval("DuzenlenmeTarihi") %></td>
                    <td><%# Eval("YayinDurumGostergesi") %></td>
                    <td>
                        <a href='eserDuzenle.aspx?EserBilgisiID=<%# Eval("EserBilgisiID") %>' class="geriAl">Eser Düzenle</a>
                        <asp:LinkButton ID="lbtn_duzenle" runat="server" CssClass="duzenle" CommandArgument='<%# Eval("EserBilgisiID")%>' CommandName="durum">Durum Düzenle</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("EserBilgisiID")%>' CommandName="sil">Sil</asp:LinkButton>
                    </td>
                </tr>
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
                    <td><%# Eval("GoruntulemeSayisi") %></td>
                    <td><%# Eval("DuzenlenmeTarihi") %></td>
                    <td><%# Eval("YayinDurumGostergesi") %></td>
                    <td>
                        <a href='eserDuzenle.aspx?EserBilgisiID=<%# Eval("EserBilgisiID") %>' class="geriAl">Eser Düzenle</a>
                        <asp:LinkButton ID="lbtn_duzenle" runat="server" CssClass="duzenle" CommandArgument='<%# Eval("EserBilgisiID")%>' CommandName="durum">Durum Düzenle</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("EserBilgisiID")%>' CommandName="sil">Sil</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
        </asp:ListView>
    </div>

</asp:Content>
