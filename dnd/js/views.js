//Setting all views for c# button
function mobileview() {
    $("#right-copy").css("max-width", "360px");
}
function tabletview() {
    $("#right-copy").css("max-width", "760px");
}
function laptopview() {
    $("#right-copy").css("max-width", "1024px");
}
function customview(cuspixels) {
    var custompixels = cuspixels;
    if (parseInt(custompixels) < 360) {
        $("#right-copy").css("max-width", "360px");
    } else if (parseInt(custompixels) > 1920) {
        $("#right-copy").css("max-width", "");
    } else {
        $("#right-copy").css("max-width", custompixels + "px");
    }
}

//Setting views on click events
$(".mobileview").click(function() {
  $("#right-copy").css("max-width", "360px");
});
$(".tabletview").click(function() {
  $("#right-copy").css("max-width", "760px");
});
$(".laptopview").click(function() {
  $("#right-copy").css("max-width", "1024px");
});
$(".resetview").click(function() {
  $("#right-copy").css("max-width", "");
});
$(".customview").click(function() {
  var custompixels = popupfunc("Enter custom size (in pixels)");
  if (parseInt(custompixels) < 360) {
    $("#right-copy").css("max-width", "360px");
  } else if (parseInt(custompixels) > 1920) {
    $("#right-copy").css("max-width", "");
  } else {
    $("#right-copy").css("max-width", custompixels + "px");
  }
});
