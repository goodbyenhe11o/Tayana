<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="YachtOverview.aspx.cs" Inherits="TayanaSystem.YachtOverview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link href="css/swiper.min.css" rel="stylesheet" />
    
    <style>
        html, body {
            position: relative;
            height: 100%;
        }
        body {
            font-family: Helvetica Neue, Helvetica, Arial, sans-serif;
            font-size: 14px;
            color:#000;
            margin: 0;
            padding: 0;
        }
        .swiper-container {
            width: 65%;
            height: 300px;
            margin-left: auto;
            margin-right: auto;
        }


        /*.swiper-slide {
            background-size: cover;
            background-position: center;
        }*/

        .swiper-slide {
            background-size: contain;
            background-position: center;
            background-repeat: no-repeat;
        }
        .gallery-top {
            height: 80%;
            width: 100%;
        }
        .gallery-thumbs {
            height: 20%;
            box-sizing: border-box;
            padding: 10px 0;
        }
        .gallery-thumbs .swiper-slide {
            height: 100%;
            opacity: 0.4;
        }
        .gallery-thumbs .swiper-slide-thumb-active {
            opacity: 1;
        }
        .aaa {
            height: 450px;
        }
    </style>


    

</asp:Content>

<asp:Content ID="Pic" ContentPlaceHolderID="ContentPlaceHolderPic" runat="server">

    <%--    <!--遮罩-->
    <div class="bannermasks">
        <img src="./images/company.jpg" alt="&quot;&quot;" width="967" height="371" /></div>
    <!--遮罩結束-->
    <!--------------------------------換圖開始---------------------------------------------------->

    <div class="banner">
        <ul>
            <li>
                <%--<img src="./images/newbanner.jpg" alt="Tayana Yachts" /></li>
        </ul>

    </div>--%>
    <!--------------------------------換圖結束---------------------------------------------------->
    
    <%-- 輪播開始 --%>
    <div class="aaa">
        <div class="swiper-container gallery-top ">

    
            <asp:Repeater ID="rpPicTop" runat="server">
                <HeaderTemplate>
            
                    <div class="swiper-wrapper">

                </HeaderTemplate>
                <ItemTemplate>
                    <div class="swiper-slide" style="background-image:url('<%#Eval("Picture")%>')" ></div>
            
                </ItemTemplate>
                <FooterTemplate>
                </div>
                </FooterTemplate>
            </asp:Repeater>

    
    
            <!-- Add Arrows -->
            <div class="swiper-button-next swiper-button-gray"></div>
            <div class="swiper-button-prev swiper-button-red"></div>
        </div>
        <div class="swiper-container gallery-thumbs">
    
            <asp:Repeater ID="rpPicBottom" runat="server">
                <HeaderTemplate>
            
                    <div class="swiper-wrapper">

                </HeaderTemplate>
                <ItemTemplate>
                    <div class="swiper-slide" style="background-image:url('<%#Eval("Picture")%>')" ></div>
            
                </ItemTemplate>
                <FooterTemplate>
                </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>

    
    
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<!--------------------------------左邊選單開始----------------------------------------------------> 
<div class="left"> 

<div class="left1">
<p><span>YACHTS</span></p>

    <asp:Repeater ID="rpMenu" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li><a href="YachtOverview.aspx?id=<%#Eval("id") %>">
                <asp:Label ID="lbYachtName" runat="server" Text='<%#Eval("YachtName") %>'></asp:Label>
                <asp:Label ID="lbNewBuilding" runat="server" Text='<%#Eval("NewBuilding") %>' ></asp:Label>
                

                </a></li>
        </ItemTemplate>
        <FooterTemplate>
        </ul>
        </FooterTemplate>
    </asp:Repeater>
    
    


</div>




</div>







<!--------------------------------左邊選單結束----------------------------------------------------> 

<!--------------------------------右邊選單開始----------------------------------------------------> 
<div id="crumb"><a href="#">Home</a> >> <a href="#">Yachts</a> >> <a runat="server" ID="YachtLink" href="#"><span class="on1">
    <asp:Literal ID="lrYachtLink" runat="server"></asp:Literal>
</span></a></div>
<div class="right"> 
<div class="right1">
  <div class="title">
      
    <asp:Label ID="lbYachtName" runat="server" ></asp:Label>

  </div>
  
<!--------------------------------內容開始----------------------------------------------------> 

<!--次選單-->
<div class="menu_y">
<ul>
<li class="menu_y00">YACHTS</li>
<li><a class="menu_yli01" runat="server" ID="aOverview" ClientIDMode="Static">Overview</a></li>
<li><a class="menu_yli02" runat="server" ID="aLayout" ClientIDMode="Static">Layout & deck plan</a></li>
<li><a class="menu_yli03" runat="server" ID="aSpecification" ClientIDMode="Static">Specification</a></li>
</ul>
</div> 
<!--次選單-->
  <div class="box1">
      Overview內容
    <asp:Literal ID="lrOverviewContent" runat="server" ></asp:Literal>
  </div>
  
<div class="box3">
<h4>PRINCIPAL DIMENSION</h4>
    
    <asp:Literal ID="lrOverviewDimensions" runat="server"></asp:Literal>

<%--<table class="table02">
  <tr>
    <td class="table02td01">
    <table>
      <tr>
        <th>L.O.A.</th>
        <td>72’-0”</td>
      </tr>
      <tr class="tr003">
        <th>L.W.L.</th>
        <td>60’-10”</td>
      </tr>
      <tr>
        <th>Beam</th>
        <td>20’-0”</td>
      </tr>
      <tr class="tr003">
        <th>Draft (Fin Keel)</th>
        <td>8’-6”</td>
      </tr>
      <tr>
        <th>Displacement</th>
        <td>96100lbs</td>
      </tr>
      <tr class="tr003">
        <th>Ballast (Fin Keel)</th>
        <td>24850lbs</td>
      </tr>
      <tr>
        <th>Sail Area (Main + 150% Triangle)<br />
Main (9.0 oz)<br />
          Stays (9.0 oz)<br />
          No. 1 Genoa (7.2 oz)<br />
          Genoa (150%) (7.2 oz)<br />
          I :<br />
          J :<br />
          P :<br />
          E :</th>
        <td>2748 sq. <br />
          ft996 sq. ft<br />
          386 sq. ft<br />
          1167 sq. ft<br />
          1782 sq. ft<br />
          87’-0”<br />
          27’-1.75”<br />
          75’-4”<br />
          26’-0”<br /></td>
      </tr>
      <tr class="tr003">
        <th>D/L=191.47Ballast/Displacement</th>
        <td>28.10%</td>
      </tr>
      <tr>
        <th>Exterior Style, Interior Designer</th>
        <td>Andrew Winch</td>
      </tr>
      <tr class="tr003">
        <th>Naval Architect Designer</th>
        <td>Bill Dixon</td>
      </tr>
    </table></td>
    <td><img src="images/ya01.jpg" alt="&quot;&quot;" width="278" height="345" /></td>
  </tr>
</table>--%>


</div>
<p class="topbuttom"><img src="images/top.gif" alt="top" /></p>

<!--下載開始-->
<div class="downloads">
<p><img src="images/downloads.gif" alt="&quot;&quot;" /></p>

    <asp:Repeater ID="rpDownload" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <a href="#">
                    Downloads 001
                </a>
            </li>

        </ItemTemplate>
        <FooterTemplate>
        </ul>
        </FooterTemplate>

    </asp:Repeater>
    

 </div>
<!--下載結束-->
  
  
  <!--------------------------------內容結束------------------------------------------------------> 
</div>
</div>

<!--------------------------------右邊選單結束----------------------------------------------------> 
    
    
     
    <!-- Swiper JS -->
    <script src="javascript/swiper.min.js"></script>
    <!-- Initialize Swiper -->
    <script>
        var galleryThumbs = new Swiper('.gallery-thumbs', {
            spaceBetween: 5,
            slidesPerView:6,
            loop: true,
            freeMode: true,
            loopedSlides: 5, //looped slides should be the same
            watchSlidesVisibility: true,
            watchSlidesProgress: true,
        });
        var galleryTop = new Swiper('.gallery-top', {
            spaceBetween: 10,
            loop:true,
            loopedSlides: 5, //looped slides should be the same
            navigation: {
                nextEl: '.swiper-button-next',
                prevEl: '.swiper-button-prev',
            },
            thumbs: {
                swiper: galleryThumbs,
            },
        });
    </script>


</asp:Content>
