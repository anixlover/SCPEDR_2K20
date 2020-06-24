<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MasterPage.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<meta http-equiv="X-UA-Compatible" content="IE=Edge" />
	<meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />

	<link rel="icon" href="favicon.ico" type="image/x-icon" />

	<!-- Google Fonts -->
	<link href="https://fonts.googleapis.com/css?family=Roboto:400,700&subset=latin,cyrillic-ext" rel="stylesheet" type="text/css"/>
	<link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" type="text/css"/>

	<link href="plugins/bootstrap/css/bootstrap.css" rel="stylesheet"/>
	<link href="plugins/node-waves/waves.css" rel="stylesheet" />
	<link href="plugins/animate-css/animate.css" rel="stylesheet" />
	<link href="plugins/morrisjs/morris.css" rel="stylesheet" />

	<!-- Custom Css -->
	<link href="css/style.css" rel="stylesheet"/>
	<link href="css/themes/all-themes.css" rel="stylesheet" />

	<title>SCPEDR</title>
</head>
<body class="theme-red">
	<!-- Page Loader -->
	<div class="page-loader-wrapper">
		<div class="loader">
			<div class="preloader">
				<div class="spinner-layer pl-red">
					<div class="circle-clipper left">
						<div class="circle"></div>
					</div>
					<div class="circle-clipper right">
						<div class="circle"></div>
					</div>
				</div>
			</div>
			<p>Please wait...</p>
		</div>
	</div>
	<!-- #END# Page Loader -->
	<!-- Overlay For Sidebars -->
	<div class="overlay"></div>
	<!-- #END# Overlay For Sidebars -->
	<!-- Search Bar -->
	<div class="search-bar">
		<div class="search-icon">
			<i class="material-icons">search</i>
		</div>
		<input type="text" placeholder="START TYPING..."/>
		<div class="close-search">
			<i class="material-icons">close</i>
		</div>
	</div>
	<!-- #END# Search Bar -->
	<!-- Top Bar -->
	<nav class="navbar theme-red ">
		<div class="container-fluid">
			<div class="navbar-header">
				<a href="javascript:void(0);" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse" aria-expanded="false"></a>
				<a href="javascript:void(0);" class="bars"></a>
				<a class="navbar-brand" href="index.html">SCPEDR
				</a>
			</div>
			<div class="collapse navbar-collapse" id="navbar-collapse">
				<ul class="nav navbar-nav navbar-right">
					<!-- Call Search -->
					<li><a href="javascript:void(0);" class="js-search" data-close="true"><i class="material-icons">search</i></a></li>
					<!-- #END# Call Search -->
					<!-- Notifications -->
					<li class="dropdown">
						<a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button">
							<i class="material-icons">notifications</i>
							<%--<span class="label-count">0</span>--%>
						</a>
						<ul class="dropdown-menu">
							<li class="header">NOTIFICATIONS</li>
							<li class="body">

							</li>
							<li class="footer">
								<a href="javascript:void(0);">View All Notifications</a>
							</li>
						</ul>
					</li>
					<!-- #END# Notifications -->
					<!-- Tasks -->
					<li class="dropdown">
						<a href="javascript:void(0);" class="dropdown-toggle" data-toggle="dropdown" role="button">
							<i class="material-icons">flag</i>
							<%--<span class="label-count">9</span>--%>
						</a>
						<ul class="dropdown-menu">
							<li class="header">TASKS</li>
							<li class="body">
							</li>
							<li class="footer">
								<a href="javascript:void(0);">View All Tasks</a>
							</li>
						</ul>
					</li>
					<!-- #END# Tasks -->
				</ul>
			</div>
		</div>
	</nav>
	<!-- #Top Bar -->
	<section>
		<!-- Left Sidebar -->
		<aside id="leftsidebar" class="sidebar">
			<!-- User Info -->
			<div class="user-info">
				<div class="image">
					<img src="images/user.png" width="48" height="48" alt="User" />
				</div>
				<div class="info-container">
					<div class="name" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">John Doe</div>
					<div class="email">john.doe@example.com</div>
					<div class="btn-group user-helper-dropdown">
						<i class="material-icons" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">keyboard_arrow_down</i>
						<ul class="dropdown-menu pull-right">
							<li><a href="javascript:void(0);"><i class="material-icons">person</i>Profile</a></li>
							<li role="separator" class="divider"></li>
							<li><a href="javascript:void(0);"><i class="material-icons">group</i>Followers</a></li>
							<li><a href="javascript:void(0);"><i class="material-icons">shopping_cart</i>Sales</a></li>
							<li><a href="javascript:void(0);"><i class="material-icons">favorite</i>Likes</a></li>
							<li role="separator" class="divider"></li>
							<li><a href="javascript:void(0);"><i class="material-icons">input</i>Sign Out</a></li>
						</ul>
					</div>
				</div>
			</div>
			<!-- #User Info -->
			<!-- Menu -->
			<div class="menu">
				<ul class="list">
					<li class="header">MAIN NAVIGATION</li>
					<li class="active">
						<a href="index.html">
							<i class="material-icons">home</i>
							<span>Home</span>
						</a>
					</li>
					<li>
						<a href="pages/typography.html">
							<i class="material-icons">text_fields</i>
							<span>Typography</span>
						</a>
					</li>
				</ul>
			</div>
			<!-- #Menu -->
			<!-- Footer -->
			<div class="legal">
				<div class="copyright">
					&copy; 2019 <a href="javascript:void(0);">SCPEDR</a>.
				</div>
				<div class="version">
					<b>Version: </b>1.0.0
				</div>
			</div>
			<!-- #Footer -->
		</aside>
		<!-- #END# Left Sidebar -->
		<!-- Right Sidebar -->
<%--		</aside>--%>
		<!-- #END# Right Sidebar -->
	</section>

	<section class="content">
		<div class="container-fluid">
		</div>
	</section>

	<!-- Jquery Core Js -->
	<script src="plugins/jquery/jquery.min.js"></script>

	<!-- Bootstrap Core Js -->
	<script src="plugins/bootstrap/js/bootstrap.js"></script>

	<!-- Select Plugin Js -->
	<script src="plugins/bootstrap-select/js/bootstrap-select.js"></script>

	<!-- Slimscroll Plugin Js -->
	<script src="plugins/jquery-slimscroll/jquery.slimscroll.js"></script>

	<!-- Waves Effect Plugin Js -->
	<script src="plugins/node-waves/waves.js"></script>

	<!-- Jquery CountTo Plugin Js -->
	<script src="plugins/jquery-countto/jquery.countTo.js"></script>

	<!-- Morris Plugin Js -->
	<script src="plugins/raphael/raphael.min.js"></script>
	<script src="plugins/morrisjs/morris.js"></script>

	<!-- ChartJs -->
	<script src="plugins/chartjs/Chart.bundle.js"></script>

	<!-- Flot Charts Plugin Js -->
	<script src="plugins/flot-charts/jquery.flot.js"></script>
	<script src="plugins/flot-charts/jquery.flot.resize.js"></script>
	<script src="plugins/flot-charts/jquery.flot.pie.js"></script>
	<script src="plugins/flot-charts/jquery.flot.categories.js"></script>
	<script src="plugins/flot-charts/jquery.flot.time.js"></script>

	<!-- Sparkline Chart Plugin Js -->
	<script src="plugins/jquery-sparkline/jquery.sparkline.js"></script>

	<!-- Custom Js -->
	<script src="js/admin.js"></script>
	<script src="js/pages/index.js"></script>

	<!-- Demo Js -->
	<script src="js/demo.js"></script>
</body>
</html>
