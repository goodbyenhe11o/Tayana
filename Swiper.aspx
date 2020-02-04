<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Swiper.aspx.cs" Inherits="TayanaSystem.Swiper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
        .aaa {
            height: 600px;
        }

        .swiper-slide {
            background-size: cover;
            background-position: center;
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

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="aaa">
            
            <div class="swiper-container gallery-top ">
                <div class="swiper-wrapper">
                    <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
                    <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
                    <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
                    <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
                    <div class="swiper-slide" style="background-image:url(./images/DEALERS.jpg)"></div>
                </div>
                <!-- Add Arrows -->
                <div class="swiper-button-next swiper-button-white"></div>
                <div class="swiper-button-prev swiper-button-white"></div>
            </div>
            <div class="swiper-container gallery-thumbs">
                <div class="swiper-wrapper">
                    
                    <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
                    <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
                    <div class="swiper-slide" style="background-image:url('./uploads/200122035033Chita.jpg')"></div>
                    <div class="swiper-slide" style="background-image:url('./images/deckplan01.jpg')"></div>
                    <div class="swiper-slide" style="background-image:url(./images/DEALERS.jpg)"></div>
                </div>
            </div>



            
            
            

        </div>
        
        
        
        <!-- Swiper JS -->
        <script src="javascript/swiper.min.js"></script>
        <!-- Initialize Swiper -->
        <script>
            var galleryThumbs = new Swiper('.gallery-thumbs', {
                spaceBetween: 10,
                slidesPerView: 4,
                loop: true,
                freeMode: true,
                loopedSlides: 5, //looped slides should be the same
                watchSlidesVisibility: true,
                watchSlidesProgress: true,
            });
            var galleryTop = new Swiper('.gallery-top', {
                spaceBetween: 10,
                loop: true,
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


    </form>
</body>
</html>
