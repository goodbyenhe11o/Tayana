<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="TayanaSystem.test" %>
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
            width: 100%;
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
            height: 500px;
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

    <div class="aaa">
    
    <div class="swiper-container gallery-top ">
        <div class="swiper-wrapper">
            
            <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url(./images/DEALERS.jpg)"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            

        </div>
        <!-- Add Arrows -->
        <div class="swiper-button-next swiper-button-gray"></div>
        <div class="swiper-button-prev swiper-button-red"></div>
    </div>
    <div class="swiper-container gallery-thumbs">
        <div class="swiper-wrapper">
            <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url(./images/DEALERS.jpg)"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
            <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>

        </div>
    </div>

    
    
    </div>
    </asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   
  <!-- Swiper JS -->
    <script src="javascript/swiper.min.js"></script>
  <!-- Initialize Swiper -->
  <script>
    var galleryThumbs = new Swiper('.gallery-thumbs', {
      spaceBetween: 5,
      slidesPerView:10,
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
