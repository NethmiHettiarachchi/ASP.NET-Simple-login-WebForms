﻿<html>
<head>
<title>jQuery get textbox value example</title>
 

</head>

<body>

<h1>jQuery get textbox value example</h1>

<div><div class="ads-in-post hide_if_width_less_800">
<script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
<!-- 728x90 - After1stH4 -->
<ins class="adsbygoogle hide_if_width_less_800" 
     style="display:inline-block;width:728px;height:90px"
     data-ad-client="ca-pub-2836379775501347"
     data-ad-slot="7391621200"
     data-ad-region="mkyongregion"></ins>

</div></div><h2>TextBox value : <label id="msg"></label></h2>

<div style="padding:16px;">
	TextBox : <input type="textbox" value="Type something"></input>
</div>
	
<button id="Get">Get TextBox Value</button> 
<button id="Set">Set To "ABC"</button> 
<button id="Reset">Reset It</button>

<script type="text/javascript">
    $("button:#Get").click(function () {

        $('#msg').html($('input:textbox').val());

    });

    $("button:#Reset").click(function () {

        $('#msg').html("");
        $('input:textbox').val("");

    });

    $("button:#Set").click(function () {

        $('input:textbox').val("ABC");
        $('#msg').html($('input:textbox').val());

    });

</script>

</body>
</html>
