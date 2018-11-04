<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AnalitikBilisimSite.UI.Pages.Index" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700%7CVarela+Round" rel="stylesheet" />
    <link type="text/css" rel="stylesheet" href="~/Assets/css/bootstrap.min.css" />
    <link type="text/css" rel="stylesheet" href="~/Assets/css/owl.carousel.css" />
    <link type="text/css" rel="stylesheet" href="~/Assets/css/owl.theme.default.css" />
    <link type="text/css" rel="stylesheet" href="~/Assets/css/magnific-popup.css" />
    <link rel="stylesheet" href="~/Assets/css/font-awesome.min.css" />
    <link type="text/css" rel="stylesheet" href="~/Assets/css/style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section id="intro">
        <div class="intro-container">
            <div id="introCarousel" class="carousel  slide carousel-fade" data-ride="carousel">

                <ol class="carousel-indicators"></ol>

                <div class="carousel-inner" role="listbox">

                    <div class="carousel-item active">
                        <div class="carousel-background">
                            <asp:Image ID="ImageSlider1" runat="server" meta:resourcekey="ImageSlider1Resource1" />
                        </div>
                        <div class="carousel-container">
                            <div class="carousel-content">
                                <h2>
                                    <asp:Label ID="lblSliderTitle1" runat="server" meta:resourcekey="lblSliderTitle1Resource1"></asp:Label>
                                </h2>
                                <p>
                                    <asp:Label ID="lblSliderWriting1" runat="server" meta:resourcekey="lblSliderWriting1Resource1"></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>

                    <div class="carousel-item">
                        <div class="carousel-background">
                            <asp:Image ID="ImageSlider2" runat="server" meta:resourcekey="ImageSlider2Resource1" />
                        </div>
                        <div class="carousel-container">
                            <div class="carousel-content">
                                <h2>
                                    <asp:Label ID="lblSliderTitle2" runat="server" meta:resourcekey="lblSliderTitle2Resource1" ></asp:Label>
                                </h2>
                                <p>
                                    <asp:Label ID="lblSliderWriting2" runat="server" meta:resourcekey="lblSliderWriting2Resource1"></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>

                    <div class="carousel-item">
                        <div class="carousel-background">
                            <asp:Image ID="ImageSlider3" runat="server" meta:resourcekey="ImageSlider3Resource1" />
                        </div>
                        <div class="carousel-container">
                            <div class="carousel-content">
                                <h2>
                                    <asp:Label ID="lblSliderTitle3" runat="server" meta:resourcekey="lblSliderTitle3Resource1"></asp:Label>
                                </h2>
                                <p>
                                    <asp:Label ID="lblSliderWriting3" runat="server" meta:resourcekey="lblSliderWriting3Resource1"></asp:Label>
                                </p>
                            </div>
                        </div>
                    </div>
                

                </div>

                <a class="carousel-control-prev" href="#introCarousel" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon ion-chevron-left" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>

                <a class="carousel-control-next" href="#introCarousel" role="button" data-slide="next">
                    <span class="carousel-control-next-icon ion-chevron-right" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>

            </div>
        </div>
    </section>

    <main id="main">

        <section id="about">
            <div class="container">

                <header class="section-header">
                    <h3>
                        <asp:Label ID="lblAboutTitle" runat="server" meta:resourcekey="lblAboutTitleResource1"></asp:Label>
                    </h3>
                    <p>
                        <asp:Label ID="lblAboutWriting" runat="server" meta:resourcekey="lblAboutWritingResource1"></asp:Label>
                    </p>
                </header>

                <div class="row about-cols">

                    <div class="col-md-4 wow fadeInUp">
                        <div class="about-col">
                            <div class="img">
                                <asp:Image ID="ImgMission" runat="server" Width="100%" meta:resourcekey="ImgMissionResource1" />
                                <div class="icon"><i class="ion-ios-speedometer-outline"></i></div>
                            </div>
                            <h2 class="title">
                                <asp:Label ID="lblMissionTitle" runat="server" meta:resourcekey="lblMissionTitleResource1"></asp:Label>
                            </h2>
                            <p>
                                <asp:Label ID="lblMissionWriting" runat="server" meta:resourcekey="lblMissionWritingResource1"></asp:Label>
                                <asp:LinkButton ID="btnMission" runat="server" OnClick="btnMission_Click" meta:resourcekey="btnMissionResource1">
                                    <asp:Label ID="lblMore1" runat="server"></asp:Label>
                                </asp:LinkButton>
                            </p>
                        </div>
                    </div>

                    <div class="col-md-4 wow fadeInUp" data-wow-delay="0.1s">
                        <div class="about-col">
                            <div class="img">
                                <asp:Image ID="ImgPlan" runat="server" Width="100%" meta:resourcekey="ImgPlanResource1" />
                                <div class="icon"><i class="ion-ios-list-outline"></i></div>
                            </div>
                            <h2 class="title">
                                <asp:Label ID="lblPlanTitle" runat="server" meta:resourcekey="lblPlanTitleResource1"></asp:Label>
                            </h2>
                            <p>
                                <asp:Label ID="lblPlanWriting" runat="server" meta:resourcekey="lblPlanWritingResource1"></asp:Label>
                                <asp:LinkButton ID="btnPlan" runat="server" OnClick="btnMission_Click" meta:resourcekey="btnPlanResource1">
                                    <asp:Label ID="lblMore2" runat="server"></asp:Label>
                                </asp:LinkButton>
                            </p>
                        </div>
                    </div>

                    <div class="col-md-4 wow fadeInUp" data-wow-delay="0.2s">
                        <div class="about-col">
                            <div class="img">
                                <asp:Image ID="ImgVision" runat="server" Width="100%" meta:resourcekey="ImgVisionResource1" />
                                <div class="icon"><i class="ion-ios-eye-outline"></i></div>
                            </div>
                            <h2 class="title">
                                <asp:Label ID="lblVisionTitle" runat="server" meta:resourcekey="lblVisionTitleResource1"></asp:Label>
                            </h2>
                            <p>
                                <asp:Label ID="lblVisionWriting" runat="server" meta:resourcekey="lblVisionWritingResource1"></asp:Label>
                                <asp:LinkButton ID="btnVision" runat="server" OnClick="btnMission_Click" meta:resourcekey="btnVisionResource1">
                                    <asp:Label ID="lblMore3" runat="server"></asp:Label>
                                </asp:LinkButton>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </section>


        <section id="services">
            <div class="container">

                <header class="section-header wow fadeInUp">
                    <h3>
                        <asp:Label ID="lblServiceTitle" runat="server"></asp:Label>
                    </h3>
                    <p>
                        <asp:Label ID="lblServiceWriting" runat="server"></asp:Label>
                    </p>
                </header>

                <div class="row">
                    <asp:ListView ID="ListService" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-3 col-md-6 box wow bounceInUp" data-wow-duration="1.4s">
                                <div class="icon"><i class="ion-ios-analytics-outline"></i></div>
                                <h4 class="title">
                                    <asp:Label ID="lblServiceTitle" runat="server" Text='<%# Eval("Title") %>' meta:resourcekey="lblServiceTitleResource1"></asp:Label>
                                </h4>
                                <p class="description">
                                    <asp:Label ID="lblServiceWriting" runat="server" Text='<%# Eval("BigWriting")+"..." %>' meta:resourcekey="lblServiceWritingResource1"></asp:Label>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <asp:Button ID="btnService" class="btnService" runat="server" Text="Daha Fazla" OnClick="btnService_Click" meta:resourcekey="btnServiceResource1" />
            </div>
        </section>

        <section id="services">
            <div class="container">
                <header class="section-header wow fadeInUp">
                    <h3>
                        <asp:Label ID="lblSolutionTitle" runat="server"></asp:Label>
                    </h3>
                    <p>
                        <asp:Label ID="lblSolutionWriting" runat="server"></asp:Label>
                    </p>
                </header>
                <div class="row">
                    <asp:ListView ID="ListSolution" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-3 col-md-6 box wow bounceInUp" data-wow-duration="1.4s">
                                <div class="icon"><i class="ion-ios-analytics-outline"></i></div>
                                <h4 class="title">
                                    <asp:Label ID="lblSolutionTitle" runat="server" Text='<%# Eval("Title") %>' meta:resourcekey="lblSolutionTitleResource1"></asp:Label>
                                </h4>
                                <p class="description">
                                    <asp:Label ID="lblSolutionWriting" runat="server" Text='<%# Eval("SmallWriting")+"..." %>' meta:resourcekey="lblSolutionWritingResource1"></asp:Label>
                                </p>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <asp:Button ID="btnSolution" class="btnService" runat="server" Text="Daha Fazla" OnClick="btnSolution_Click" meta:resourcekey="btnSolutionResource1" />
            </div>
        </section>

        <section id="about">
            <div class="container">
                <header class="section-header">
                    <h3>
                        <asp:Label ID="lblNewsTitle" runat="server" Text="Label"></asp:Label>
                    </h3>
                </header>
                <div class="row about-cols">
                    <asp:ListView ID="ListNews" runat="server">
                        <ItemTemplate>
                            <div class="col-md-4 wow fadeInUp">
                                <div class="about-col">
                                    <div class="img">
                                        <asp:Image ID="ImgNews" runat="server" Width="100%" ImageUrl='<%# Eval("Image") %>' Height="150px" meta:resourcekey="ImgNewsResource1" />
                                    </div>
                                    <h2 class="title">
                                        <asp:Label ID="lblNewsTitle" runat="server" Text='<%# Eval("Title") %>' meta:resourcekey="lblNewsTitleResource1"></asp:Label>
                                    </h2>
                                    <p>
                                        <asp:Label ID="lblNewsWriting" runat="server" Text='<%# Eval("SmallWriting")+"..." %>' meta:resourcekey="lblNewsWritingResource1"></asp:Label><br />
                                        <asp:LinkButton ID="btnNews" runat="server" OnClick="btnNews_Click" CommandArgument='<%# Eval("ID") %>' Style="float: right" meta:resourcekey="btnNewsResource1"><%=More %></asp:LinkButton>
                                    </p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <asp:Button ID="btnNewsDetails" class="btnService" runat="server" Text="Daha Fazla" OnClick="btnNewsDetails_Click" meta:resourcekey="btnNewsDetailsResource1" />
            </div>
        </section>


        <section id="clients" class="wow fadeInUp">
            <div class="container">
                <header class="section-header">
                    <h3>
                        <asp:Label ID="lblReferenceTitle" runat="server"></asp:Label>
                    </h3>
                </header>
                <div class="owl-carousel clients-carousel">
                    <asp:ListView ID="listReferance" runat="server">
                        <ItemTemplate>
                            <asp:Image ID="ImgReferance" runat="server" ImageUrl='<%# Eval("ReferanceLogo") %>' meta:resourcekey="ImgReferanceResource1" Width="200" Height="150" />
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </section>


        <%--<section id="testimonials" class="section-bg wow fadeInUp">
            <div class="container">

                <header class="section-header">
                    <h3>Görüşler</h3>
                </header>

                <div class="owl-carousel testimonials-carousel">
                    <div class="testimonial-item">
                        <img src="img/testimonial-1.jpg" class="testimonial-img" alt="">
                        <h3>Saul Goodman</h3>
                        <h4>Ceo &amp; Founder</h4>
                        <p>
                            <img src="img/quote-sign-left.png" class="quote-sign-left" alt="">
                            Proin iaculis purus consequat sem cure digni ssim donec porttitora entum suscipit rhoncus. Accusantium quam, ultricies eget id, aliquam eget nibh et. Maecen aliquam, risus at semper.
              <img src="img/quote-sign-right.png" class="quote-sign-right" alt="">
                        </p>
                    </div>

                    <div class="testimonial-item">
                        <img src="img/testimonial-2.jpg" class="testimonial-img" alt="">
                        <h3>Sara Wilsson</h3>
                        <h4>Designer</h4>
                        <p>
                            <img src="img/quote-sign-left.png" class="quote-sign-left" alt="">
                            Export tempor illum tamen malis malis eram quae irure esse labore quem cillum quid cillum eram malis quorum velit fore eram velit sunt aliqua noster fugiat irure amet legam anim culpa.
              <img src="img/quote-sign-right.png" class="quote-sign-right" alt="">
                        </p>
                    </div>

                    <div class="testimonial-item">
                        <img src="img/testimonial-3.jpg" class="testimonial-img" alt="">
                        <h3>Jena Karlis</h3>
                        <h4>Store Owner</h4>
                        <p>
                            <img src="img/quote-sign-left.png" class="quote-sign-left" alt="">
                            Enim nisi quem export duis labore cillum quae magna enim sint quorum nulla quem veniam duis minim tempor labore quem eram duis noster aute amet eram fore quis sint minim.
              <img src="img/quote-sign-right.png" class="quote-sign-right" alt="">
                        </p>
                    </div>

                    <div class="testimonial-item">
                        <img src="img/testimonial-4.jpg" class="testimonial-img" alt="">
                        <h3>Matt Brandon</h3>
                        <h4>Freelancer</h4>
                        <p>
                            <img src="img/quote-sign-left.png" class="quote-sign-left" alt="">
                            Fugiat enim eram quae cillum dolore dolor amet nulla culpa multos export minim fugiat minim velit minim dolor enim duis veniam ipsum anim magna sunt elit fore quem dolore labore illum veniam.
              <img src="img/quote-sign-right.png" class="quote-sign-right" alt="">
                        </p>
                    </div>

                    <div class="testimonial-item">
                        <img src="img/testimonial-5.jpg" class="testimonial-img" alt="">
                        <h3>John Larson</h3>
                        <h4>Entrepreneur</h4>
                        <p>
                            <img src="img/quote-sign-left.png" class="quote-sign-left" alt="">
                            Quis quorum aliqua sint quem legam fore sunt eram irure aliqua veniam tempor noster veniam enim culpa labore duis sunt culpa nulla illum cillum fugiat legam esse veniam culpa fore nisi cillum quid.
              <img src="img/quote-sign-right.png" class="quote-sign-right" alt="">
                        </p>
                    </div>
                </div>
            </div>
        </section>--%>

    </main>

</asp:Content>
